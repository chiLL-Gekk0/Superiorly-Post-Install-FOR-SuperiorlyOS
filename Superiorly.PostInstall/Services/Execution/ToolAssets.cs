using System.IO;
using System.Reflection;

namespace Superiorly.PostInstall.Services.Execution;

/// Bundled tools ship inside the assembly, so the install folder only ever holds the app.
/// Windows can only run a file that exists on disk, so they are written once to per-user
/// storage; .nip profiles are never written, they go straight to a temp file on demand.
public static class ToolAssets
{
    public const string Prefix = "tools/";

    public static string Root { get; } = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Superiorly", "Tools");

    /// Absolute path of a bundled file, whether or not it has been written yet.
    public static string PathFor(string relative) => Path.Combine(Root, relative.Replace('/', '\\'));

    public static string? Resolve(string relative)
    {
        var p = PathFor(relative);
        return File.Exists(p) ? p : null;
    }

    public static void Materialize()
    {
        try
        {
            var asm = typeof(ToolAssets).Assembly;
            foreach (var name in asm.GetManifestResourceNames())
            {
                if (!name.StartsWith(Prefix, StringComparison.Ordinal)) continue;
                var relative = name[Prefix.Length..];
                if (relative.EndsWith(".pdb", StringComparison.OrdinalIgnoreCase)) continue;

                var dest = PathFor(relative);
                using (var probe = asm.GetManifestResourceStream(name))
                {
                    if (probe == null) continue;
                    if (File.Exists(dest) && new FileInfo(dest).Length == probe.Length) continue;

                    var dir = Path.GetDirectoryName(dest);
                    if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);
                    using var fs = File.Create(dest);
                    probe.CopyTo(fs);
                }
            }
        }
        catch { }
    }

    /// Writes one embedded resource to a temp file and hands back the path. Used for the
    /// .nip profiles, which NVIDIA Profile Inspector has to read from disk.
    public static string? MaterializeTemp(string resourceName)
    {
        try
        {
            var dir = Path.Combine(Path.GetTempPath(), "Superiorly", "nip");
            Directory.CreateDirectory(dir);
            var tempFile = Path.Combine(dir, Guid.NewGuid().ToString("N") + ".nip");

            using (var s = typeof(ToolAssets).Assembly.GetManifestResourceStream(resourceName))
            {
                if (s == null) return null;
                using var fs = File.Create(tempFile);
                s.CopyTo(fs);
            }
            return tempFile;
        }
        catch { return null; }
    }
}