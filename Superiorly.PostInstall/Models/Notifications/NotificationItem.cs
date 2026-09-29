using System.IO;
using System.Windows.Input;
using System.Diagnostics;

namespace Superiorly.PostInstall.Models;

public sealed class NotificationItem
{
    public string Title { get; set; } = "";
    public string Message { get; set; } = "";
    public string? FilePath { get; set; }
    public string Icon { get; set; } = "";

    public ICommand CloseCommand { get; set; } = null!;
    public ICommand OpenPathCommand { get; set; } = null!;

    public void OpenFolderPath()
    {
        if (string.IsNullOrEmpty(FilePath)) return;
        var dir = Path.GetDirectoryName(FilePath);
        if (dir != null && Directory.Exists(dir))
            Process.Start(new ProcessStartInfo("explorer.exe", dir) { UseShellExecute = true });
    }
}
