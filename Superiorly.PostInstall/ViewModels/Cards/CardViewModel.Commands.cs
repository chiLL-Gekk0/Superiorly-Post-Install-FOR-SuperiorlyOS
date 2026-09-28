using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject {

    public IAsyncRelayCommand ToggleCommand { get; }
    public IAsyncRelayCommand ApplyCommand { get; }
    public IAsyncRelayCommand LoadItemsCommand { get; }
    public IRelayCommand UnselectAllCommand { get; }
    public IRelayCommand SelectAllCommand { get; }
    public IRelayCommand ClearSearchCommand { get; }
    public IRelayCommand ResearchCommand { get; }
    public IAsyncRelayCommand Win32ApplyCommand { get; }
    public IRelayCommand Win32RestoreDefaultCommand { get; }
    public IRelayCommand Win32OpenMapCommand { get; }
    public IAsyncRelayCommand ActivatePowerPlanCommand { get; }
    public IAsyncRelayCommand DeletePowerPlanCommand { get; }
    public IAsyncRelayCommand ImportPowerPlanCommand { get; }
    public IAsyncRelayCommand ExportPowerPlanCommand { get; }
}
