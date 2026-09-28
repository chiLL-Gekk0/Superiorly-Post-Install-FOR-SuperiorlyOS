using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class StoreResultItem : ObservableObject
{
    [ObservableProperty]
    private string _name = "";

    [ObservableProperty]
    private string _packageId = "";

    [ObservableProperty]
    private string _publisher = "";

    [ObservableProperty]
    private bool _isSelected;

    public string Source { get; set; } = "msstore";
}
