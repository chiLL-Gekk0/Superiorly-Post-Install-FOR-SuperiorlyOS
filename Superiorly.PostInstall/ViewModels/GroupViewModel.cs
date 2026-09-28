using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Superiorly.PostInstall.ViewModels;

public partial class GroupViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "";
    [ObservableProperty]
    private string _description = "";
    public bool ShowHeader { get; set; } = true;
    public bool HasChrome { get; set; } = true;
    public ObservableCollection<CardViewModel> Members { get; } = new();
}
