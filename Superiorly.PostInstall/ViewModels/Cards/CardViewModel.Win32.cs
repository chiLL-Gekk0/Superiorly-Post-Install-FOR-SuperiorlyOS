using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject {

    partial void OnWin32SelectedPsChanged(string value) => UpdateWin32Preview();
    partial void OnWin32LengthFixedChanged(bool value) => UpdateWin32Preview();
    partial void OnWin32IntervalLongChanged(bool value) => UpdateWin32Preview();

    private void Win32Refresh()
    {
        try
        {
            using var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\PriorityControl");
            object? raw = key?.GetValue("Win32PrioritySeparation");
            int val = 2;
            if (raw is int ii) val = ii;
            else if (raw is byte bb) val = bb;
            else if (raw is uint uu) val = (int)uu;
            else if (raw is long ll) val = (int)ll;
            Win32CurrentHex = $"0x{val:X2}";
            Win32CurrentBinary = Convert.ToString(val, 2).PadLeft(6, '0');
            int boost = val & 0x3;
            bool isFixed = (val & 0x4) != 0;
            bool isLong = (val & 0x8) != 0;
            Win32CurrentPs = boost == 0 ? "1:1" : boost == 1 ? "2:1" : "3:1";
            Win32CurrentQuantum = $"{TranslationService.GetUi(isFixed ? "fixed" : "variable", Lang)} · {TranslationService.GetUi(isLong ? "long" : "short", Lang)} · {Win32CurrentPs}";
        }
        catch { }
    }

    private void UpdateWin32Preview()
    {
        int boost = Win32SelectedPs == "2:1" ? 1 : Win32SelectedPs == "3:1" ? 2 : 0;
        int type = Win32LengthFixed ? 1 : 0;
        int length = Win32IntervalLong ? 1 : 0;
        int psMap = Win32SelectedPs == "1:1" ? 2 : Win32SelectedPs == "2:1" ? 1 : 0;
        int val = (psMap << 4) | (length << 3) | (type << 2) | boost;
        Win32PreviewHex = $"0x{val:X2}";
        Win32PreviewBinary = Convert.ToString(val, 2).PadLeft(6, '0');
    }

    private async Task Win32ApplyAsync()
    {
        if (Running) return;
        Running = true;
        try
        {
            var hex = Win32PreviewHex;
            int dec = Convert.ToInt32(hex.Replace("0x",""), 16);
            var cmd = $"reg add \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl\" /v Win32PrioritySeparation /t REG_DWORD /d {dec} /f";
            var ok = await Task.Run(() => _runner.RunAll(new[] { cmd }));
            _owner.Notify(ok ? string.Format(TranslationService.GetUi("win32_set", Lang), hex) : TranslationService.GetUi("failed", Lang), null, Title, ok ? char.ConvertFromUtf32(0xE73E) : char.ConvertFromUtf32(0xE711));
            Win32Refresh();
        }
        finally { Running = false; }
    }

    private void Win32RestoreDefault()
    {
        Win32SelectedPs = "2:1";
        Win32LengthFixed = false;
        Win32IntervalLong = false;
        UpdateWin32Preview();
    }
}
