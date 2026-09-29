using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject {

    private string Lang => _owner.SelectedLanguage.Code;

    public string SelectedLanguageCode => _owner.SelectedLanguage.Code;

    public bool HasToggle => _enableOption != null && _disableOption != null;
    public bool IsCombo => !HasToggle && Options.Count > 1;
    public bool IsPresetCombo => IsCombo && !IsDownloadCard;
    private static readonly System.Collections.Generic.HashSet<string> DestructiveIds = new() { "smb2", "system-restore", "modern-standby" };
    private static readonly System.Collections.Generic.HashSet<string> ConfirmIds = new() { "brave-debloat", "edge-debloat", "chrome-debloat", "firefox-debloat", "office-debloat", "nvidia-telemetry" };
    public bool IsDestructive => DestructiveIds.Contains(_action.Id);
    public bool IsSearchCard => _action.Type == "search";
    public string ActionId => _action.Id;
    public bool IsListCard => _action.Type == "list";
    public bool IsWin32Card => _action.Id == "win32priorityseparation";
    public bool IsPowerPlanCard => _action.Id == "powerplan-manager";
    public CardViewModel? CpuIdleCard => _owner.GetCardById("cpu-idle");
    public bool IsGroupHeader => _action.Type == "group-header";
    public bool HideGroupHeader { get; set; }

    [ObservableProperty]
    private string _groupTitle = "";
    [ObservableProperty]
    private string _groupDescription = "";

    public bool HasTip => _action.Tip != null;
    public bool IsDownloadCard => _actionType == "download";
    public bool HasInfo => !string.IsNullOrEmpty(InfoText) || _action.Tip != null;
    [ObservableProperty]
    private string _infoText = "";
    public string TipControversy => TipText(_action.Tip?.Controversy);
    public string TipData => TipText(_action.Tip?.Data);
    public int TipSecurity => _action.Tip?.Security ?? 0;
    public string TipSecurityText => $"{TipSecurity}/10";
    // debloat has no security score; hide ranking there
    public bool ShowSecurity => HasTip && TipSecurity > 0 && ActionId is not "brave-debloat" and not "edge-debloat";
}
