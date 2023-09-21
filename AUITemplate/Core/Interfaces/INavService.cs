using AUITemplate.Core.Bases;

namespace AUITemplate.Core.Interfaces;

public interface INavService
{
    public ViewModelBase TopMenu { get; }
    public ViewModelBase SideMenu { get; }
    public ViewModelBase MainView { get; }
    void NavigateMainView<MainView>() where MainView : ViewModelBase;
    void NavigateSideMenu<SideMenu>() where SideMenu : ViewModelBase;
    void NavigateTopMenu<TopMenu>() where TopMenu : ViewModelBase;
}
