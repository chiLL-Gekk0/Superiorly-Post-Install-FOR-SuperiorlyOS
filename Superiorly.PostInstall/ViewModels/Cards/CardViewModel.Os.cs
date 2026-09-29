using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject {

    // wow64 compat lives in services.powershellhelper; path mapping here
    private static bool PreferOs64View => Services.PowerShellHelper.PreferOs64View;
    private static string PowerShellExe => Services.PowerShellHelper.ExePath;

    private static string ExpandOsPaths(string s)
    {
        // keep 64-bit intent; check (x86) first since it contains plain token
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
