using System.Reflection;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Superiorly.PostInstall.Services;
using Superiorly.PostInstall.ViewModels;
using Superiorly.PostInstall.Views;

namespace Superiorly.PostInstall;

// entry point: baml class plus startup object
public partial class App : Application
{
    public new static App Current => (App)Application.Current;

    public IServiceProvider Services { get; }

    private static Mutex? _singleInstance;

    public App()
    {
        DispatcherUnhandledException += (_, e) => { try { System.Diagnostics.Debug.WriteLine(e.Exception.ToString()); } catch { } e.Handled = true; };
        var services = new ServiceCollection();
        services.AddSingleton<ISettingsService, JsonSettingsService>();
        services.AddSingleton<IThemeService, ThemeService>();
        services.AddSingleton<ICatalogProvider, JsonCatalogProvider>();
        services.AddSingleton<ICommandRunner, ProcessCommandRunner>();
        services.AddSingleton<IDownloadCommandRunner, DownloadCommandRunner>();
        services.AddSingleton<IStoreSearchService, StoreSearchService>();
        services.AddSingleton<IUpdateService, UpdateService>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainWindow>();
        Services = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _singleInstance = new Mutex(true, @"Local\Superiorly.PostInstall.SingleInstance", out var isNew);
        if (!isNew)
        {
            Shutdown();
            return;
        }
        base.OnStartup(e);
        try { StoreSearchService.Warmup(); } catch { }
        try { CardViewModel.WarmupPowerPlans(); } catch { }
        try
        {
            var settings = Services.GetRequiredService<ISettingsService>().Load();
            Services.GetRequiredService<IThemeService>().Apply(settings.Theme);
            Services.GetRequiredService<IThemeService>().ApplyCorners(settings.CornerStyle ?? "win10");
        }
        catch { }
        try
        {
            MainWindow = Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Startup failed: " + ex.Message, "Superiorly Community", MessageBoxButton.OK, MessageBoxImage.Error);
            Shutdown();
        }
    }
}
