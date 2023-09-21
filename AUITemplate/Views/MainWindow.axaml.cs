using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace AUITemplate.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        #region TitleBar
        private void CloseApp(object sender, RoutedEventArgs e)
        { Close(); }
        private void VisibleApp(object sender, RoutedEventArgs e)
        { this.WindowState = WindowState.Minimized; }
        private void MinimizeApp(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }
        #endregion
        #region Move UI
        private void DragMove(object sender, PointerPressedEventArgs e)
        { BeginMoveDrag(e); }
        #endregion
    }
}