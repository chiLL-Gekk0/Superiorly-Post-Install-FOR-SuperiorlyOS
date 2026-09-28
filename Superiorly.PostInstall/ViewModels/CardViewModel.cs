using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject
{
    private readonly ICommandRunner _runner;
    private readonly IDownloadCommandRunner _downloadRunner;
    private readonly IStoreSearchService _storeSearch;
    private readonly IReadOnlyList<string> _checks;
    private readonly IReadOnlyList<string> _launch;
    private readonly string _actionType;
    private readonly ActionOption? _enableOption;
    private readonly ActionOption? _disableOption;
    private readonly MainViewModel _owner;
    private readonly ActionItem _action;
    private CancellationTokenSource? _cts;
    private static List<string>? _uninstallNamesCache;
    private static DateTime _uninstallCacheExpiry;
    private static readonly object _uninstallLock = new();
    private static readonly System.Threading.SemaphoreSlim _stateSemaphore = new(3);

    // ponytail: WOW64 compat lives in Services.PowerShellHelper (shared by all launchers); path intent here.
    private static bool PreferOs64View => Services.PowerShellHelper.PreferOs64View;
    private static string PowerShellExe => Services.PowerShellHelper.ExePath;

    private static string ExpandOsPaths(string s)
    {
        // Catalog authors mean the native 64-bit dir; preserve that intent. (x86) token first: it contains the plain token as prefix.
        if (PreferOs64View)
        {
            s = s.Replace("$env:ProgramFiles(x86)", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), StringComparison.OrdinalIgnoreCase);
            var w6432 = Environment.GetEnvironmentVariable("ProgramW6432");
            if (!string.IsNullOrEmpty(w6432))
                s = s.Replace("$env:ProgramFiles", w6432, StringComparison.OrdinalIgnoreCase)
                     .Replace("%ProgramFiles%", w6432, StringComparison.OrdinalIgnoreCase);
        }
        return Environment.ExpandEnvironmentVariables(s);
    }

    private static Microsoft.Win32.RegistryKey? OpenOsView(Microsoft.Win32.RegistryKey hive, string path)
    {
        if (!PreferOs64View) return hive.OpenSubKey(path);
        var h = ReferenceEquals(hive, Microsoft.Win32.Registry.LocalMachine) ? Microsoft.Win32.RegistryHive.LocalMachine
            : ReferenceEquals(hive, Microsoft.Win32.Registry.CurrentUser) ? Microsoft.Win32.RegistryHive.CurrentUser
            : ReferenceEquals(hive, Microsoft.Win32.Registry.ClassesRoot) ? Microsoft.Win32.RegistryHive.ClassesRoot
            : ReferenceEquals(hive, Microsoft.Win32.Registry.Users) ? Microsoft.Win32.RegistryHive.Users
            : Microsoft.Win32.RegistryHive.CurrentConfig;
        return Microsoft.Win32.RegistryKey.OpenBaseKey(h, Microsoft.Win32.RegistryView.Registry64).OpenSubKey(path);
    }

}
