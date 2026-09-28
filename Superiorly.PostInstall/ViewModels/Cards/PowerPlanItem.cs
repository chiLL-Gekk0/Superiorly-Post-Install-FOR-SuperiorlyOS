using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class PowerPlanItem : ObservableObject
{
    [ObservableProperty]
    private string _guid = "";

    [ObservableProperty]
    private string _name = "";

    [ObservableProperty]
    private bool _isActive;

    [ObservableProperty]
    private bool _isChecked;

    [ObservableProperty]
    private bool _isOfficial;

    [ObservableProperty]
    private string _groupName = "";

    public string DisplayName => Name;
    public string Detail => Guid;
}
