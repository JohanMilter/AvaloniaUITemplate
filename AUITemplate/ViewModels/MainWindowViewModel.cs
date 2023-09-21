using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using AUITemplate.Core.Bases;
using AUITemplate.Core.Interfaces;
using AUITemplate.Core.Messages;
using AUITemplate.Core.Timers;
using AUITemplate.Info;
using AUITemplate.ViewModels.Defaults;
using AUITemplate.ViewModels.Menus;
using System;
using System.Collections.ObjectModel;

namespace AUITemplate.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase, IRecipient<FailMessage>
    {
        [ObservableProperty] INavService navService;
        public MainWindowViewModel(INavService navService)
        {
            NavService = navService;
            NavService.NavigateSideMenu<DefaultSideMenuViewModel>();
            NavService.NavigateMainView<MainViewModel>();

            WeakReferenceMessenger.Default.Register<FailMessage>(this);
        }
        public static InfoUI InfoUI { get; } = new();

        ObservableCollection<Border> FailBorders { get; } = new();
        #region Fail Message
        public void Receive(FailMessage message)
        {
            TextBlock showHeader = new()
            {
                Text = message.Value.header,
                FontFamily = "Georgia",
                FontSize = 25,
                FontWeight = FontWeight.SemiBold,
            };
            Grid.SetRow(showHeader, 0);
            TextBlock showMessage = new()
            {
                Text = message.Value.fail,
                FontFamily = "Georgia",
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
            };
            Grid.SetRow(showMessage, 1);
            Border border = new()
            {
                CornerRadius = CornerRadius.Parse("20"),
                Opacity = 0,
                Margin = new Thickness(0,0,15,15),
                Background = Brush.Parse(message.Value.color),
                Child = new Grid
                {
                    MaxWidth = 250,
                    Margin = new Thickness(10),
                    RowDefinitions =
                    {
                        new RowDefinition(),
                        new RowDefinition(),
                    },
                    Children =
                    {
                        showHeader,
                        showMessage,
                    },
                },

                Effect = new DropShadowEffect()
                {
                    BlurRadius = 10,
                    Color = Colors.Black,
                    OffsetX = 8,
                    OffsetY = 8,
                    Opacity = 0.4,
                },
                Transitions = new Transitions()
                {
                    new DoubleTransition()
                    {
                        Duration = InfoUI.FailMessageAppearTime,
                        Property = Visual.OpacityProperty,
                    },
                },
            };
            FailBorders.Add(border);
            border.Opacity = 1;
            CountdownTimer counter = new();
            counter.StartCounting(TimeSpan.FromMilliseconds(InfoUI.FailMessageShowTime.TotalMilliseconds + 100), (object? sender, EventArgs e) =>
            {
                border.Opacity = 0;
                counter.StopCounting();
                CountdownTimer counter2 = new();
                counter2.StartCounting(InfoUI.FailMessageAppearTime, (object? sender, EventArgs e) =>
                {
                    //Only clear all fails if all is not visible
                    if (FailBorders[^1].Opacity == 0)
                        FailBorders.Clear();
                    counter2.StopCounting();
                });
            });
        }
        #endregion
    }
}