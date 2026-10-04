using System.IO;
using System.Reflection;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Superiorly.PostInstall.Services;
using Superiorly.PostInstall.Services.Execution;
using Superiorly.PostInstall.ViewModels;
using Superiorly.PostInstall.Views;

namespace Superiorly.PostInstall;

// entry point: baml class plus startup object
public partial class App : Application
{
    public new static App Current => (App)Application.Current;

    public IServiceProvider Services { get; }

    private static Mutex? _singleInstance;

    // tooltips fire on their owner, and the default 500ms is not inheritable,
    // so it cannot be lowered from a ToolTip style; inherit it down the tree instead
    static App()
    {
        try
        {
            System.Windows.Controls.ToolTipService.InitialShowDelayProperty.OverrideMetadata(
                typeof(System.Windows.FrameworkElement),
                new System.Windows.FrameworkPropertyMetadata(300, System.Windows.FrameworkPropertyMetadataOptions.Inherits));
            System.Windows.Controls.ToolTipService.BetweenShowDelayProperty.OverrideMetadata(
                typeof(System.Windows.FrameworkElement),
                new System.Windows.FrameworkPropertyMetadata(100, System.Windows.FrameworkPropertyMetadataOptions.Inherits));
        }
        catch { }
    }

    public App()
    {
        DispatcherUnhandledException += (_, e) => { try { System.Diagnostics.Debug.WriteLine(e.Exception.ToString()); try { System.IO.Directory.CreateDirectory(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Superiorly.PostInstall")); System.IO.File.AppendAllText(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Superiorly.PostInstall", "ui-error.log"), System.DateTime.UtcNow.ToString("O") + " " + e.Exception.ToString() + "\n"); } catch { } } catch { } e.Handled = true; };
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
        // install dir for file: probes (%SPIBINDIR%)
        try { System.Environment.SetEnvironmentVariable("SPIBINDIR", AppContext.BaseDirectory); } catch { }
        // bundled tools live in the DLL; write them to per-user storage before any card checks
        try { ToolAssets.Materialize(); } catch { }
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
            // full chain (type, stack, inner) lands in temp so any future startup failure names its cause
            var log = "";
            try
            {
                var dir = Path.Combine(Path.GetTempPath(), "Superiorly.PostInstall");
                Directory.CreateDirectory(dir);
                log = Path.Combine(dir, "startup-error.log");
                File.WriteAllText(log, ex.ToString());
            }
            catch { }
            MessageBox.Show("Startup failed: " + ex.Message + (log == "" ? "" : " (details: " + log + ")"), "Superiorly Community", MessageBoxButton.OK, MessageBoxImage.Error);
            Shutdown();
        }
    }
}
