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


}
