using AUITemplate.Core.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using AUITemplate.Core.Bases;

namespace AUITemplate.Core.Services;

public partial class NavService : ObservableObject, INavService
{
    private readonly Func<Type, ViewModelBase> _viewModelFactory;
    [ObservableProperty] ViewModelBase? topMenu;
    [ObservableProperty] ViewModelBase? sideMenu;
    [ObservableProperty] ViewModelBase? mainView;

    public NavService(Func<Type, ViewModelBase> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }
    public void NavigateSideMenu<Side>() where Side : ViewModelBase
    {
        ViewModelBase viewModel = _viewModelFactory.Invoke(typeof(Side));
        SideMenu = viewModel;
    }
    public void NavigateTopMenu<Top>() where Top : ViewModelBase
    {
        ViewModelBase viewModel = _viewModelFactory.Invoke(typeof(Top));
        TopMenu = viewModel;
    }
    public void NavigateMainView<Main>() where Main : ViewModelBase
    {
        ViewModelBase viewModel = _viewModelFactory.Invoke(typeof(Main));
        MainView = viewModel;
    }
}
