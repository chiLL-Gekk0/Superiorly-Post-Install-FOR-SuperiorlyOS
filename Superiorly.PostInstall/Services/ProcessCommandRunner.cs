using System.Diagnostics;
using System.IO;

namespace Superiorly.PostInstall.Services;

public interface ICommandRunner
{
    bool RunAll(IEnumerable<string> commands);
}

public sealed class ProcessCommandRunner : ICommandRunner
{
    public bool RunAll(IEnumerable<string> commands)
    {
        var allOk = true;

        foreach (var command in commands)
        {
            var trimmed = command.TrimStart();
            var isPsScript = PowerShellHelper.IsPsScript(trimmed);
            var bestEffort = PowerShellHelper.IsBestEffortCommand(command);

            if (isPsScript)
            {
                var script = trimmed.StartsWith("powershell", StringComparison.OrdinalIgnoreCase)
                    ? PowerShellHelper.ExtractScript(trimmed) : trimmed;
                var ps1 = Path.Combine(Path.GetTempPath(), $"si_{Guid.NewGuid():N}.ps1");
                File.WriteAllText(ps1, script);

                var info = new ProcessStartInfo
                {
                    FileName = PowerShellHelper.ExePath,
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{ps1}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = AppContext.BaseDirectory
                };

                using var process = Process.Start(info);
                if (process == null) { allOk = false; continue; }
                if (!process.WaitForExit(60000)) { try { process.Kill(entireProcessTree: true); } catch { } allOk = false; continue; }
                if (!bestEffort && !PowerShellHelper.IsSuccessExitCode(process.ExitCode))
                {
                    if (script.Contains("winget install", StringComparison.OrdinalIgnoreCase) && PowerShellHelper.TryChocoFallback(script)) { }
                    else allOk = false;
                }

                try { File.Delete(ps1); } catch { }
            }
            else
            {
                var info = new ProcessStartInfo
                {
                    FileName = PowerShellHelper.ExePath,
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command.Replace("\"", "\\\"")}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = AppContext.BaseDirectory
                };

                using var process = Process.Start(info);
                if (process == null) { allOk = false; continue; }
                if (!process.WaitForExit(60000)) { try { process.Kill(entireProcessTree: true); } catch { } allOk = false; continue; }
                if (!bestEffort && !PowerShellHelper.IsSuccessExitCode(process.ExitCode))
                {
                    if (command.Contains("winget install", StringComparison.OrdinalIgnoreCase) && PowerShellHelper.TryChocoFallback(command)) { }
                    else allOk = false;
                }
            }
        }

        return allOk;
    }
}
