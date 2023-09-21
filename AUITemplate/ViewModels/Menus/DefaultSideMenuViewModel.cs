using AUITemplate.Core.Fails;
using AUITemplate.Core.Interfaces;
using AUITemplate.Core.Messages;
using AUITemplate.Info;
using AUITemplate.ViewModels.Defaults;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using AUITemplate.Core.Bases;
using System.Diagnostics;
using System.Drawing;

namespace AUITemplate.ViewModels.Menus;

public partial class DefaultSideMenuViewModel : ViewModelBase
{
    [ObservableProperty] INavService navService;
    public DefaultSideMenuViewModel(INavService navService)
    {
        NavService = navService;
    }

    public void HomeCommand()
    {
        NavService.NavigateMainView<HomeViewModel>();
    }
    public void AppsCommand()
    {
        NavService.NavigateMainView<AppsViewModel>();
    }
    public void SettingsCommand()
    {
        WeakReferenceMessenger.Default.Send(new FailMessage(new FailItem()
        {
            header = "Test fail",
            fail = "Failure...",
            color = InfoUI.FailMessageColor.ToString(),
        }));
    }
    public void UserCommand()
    {

        WeakReferenceMessenger.Default.Send(new FailMessage(new FailItem()
        {
            header = "Test Succes Message",
            fail = "Succes Message...",
            color = InfoUI.SuccesMessageColor.ToString(),
        }));
    }
    
}
