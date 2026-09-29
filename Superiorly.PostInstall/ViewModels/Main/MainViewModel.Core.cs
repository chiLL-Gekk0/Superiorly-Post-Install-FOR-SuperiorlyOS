using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public sealed record QuantumRow(string Hex, string Desc, bool IsCurrent, string Dec);

    private readonly ISettingsService _settingsService;
    private readonly IThemeService _themeService;
    private readonly ICommandRunner _commandRunner;
    private readonly IDownloadCommandRunner _downloadRunner;
    private readonly IStoreSearchService _storeSearch;
    private readonly IUpdateService _updateService;
    private readonly CatalogDefinition _catalog;

}
