using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using AUITemplate.Core.Interfaces;
using AUITemplate.Core.Services;
using AUITemplate.Core.Bases;
using AUITemplate.ViewModels;
using AUITemplate.ViewModels.Defaults;
using AUITemplate.ViewModels.Menus;
using AUITemplate.Views;
using System;

namespace AUITemplate;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    private readonly ServiceProvider _serviceProvider;
    public App()
    {
        //Generate ServiceCollection
        IServiceCollection services = new ServiceCollection();

        //MainWindow
        services.AddSingleton(provider => new MainWindow
        {
            DataContext = provider.GetRequiredService<MainWindowViewModel>()
        });

        //ViewModels
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<DefaultSideMenuViewModel>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddSingleton<AppsViewModel>();

        //NavigationService
        services.AddSingleton<INavService, NavService>();
        services.AddSingleton<Func<Type, ViewModelBase>>(provider => VMType => (ViewModelBase)provider.GetRequiredService(VMType)); //VM = ViewModel

        //Build _serviceProvider
        _serviceProvider = services.BuildServiceProvider();
    }
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
            desktop.MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}