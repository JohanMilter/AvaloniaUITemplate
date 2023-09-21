using Avalonia.Media;
using Avalonia.Media.Imaging;
using System;

namespace AUITemplate.Info;

public class InfoUI : InfoUI_Methods
{
    //Root
    public static readonly string Root = @"..\..\..\";
    //TitleBar Buttons
    public static Bitmap CloseIconPath => new(@$"{Root}Assets\Close.ico");
    public static Bitmap MinimizeIconPath => new (@$"{Root}Assets\Minimize.ico");
    public static Bitmap VisibleIconPath => new(@$"{Root}Assets\Visible.ico");
    //Side Menu
    public static Bitmap MenuIconPath => new(@$"{Root}Assets\Menu.ico");
    //Fails
    public static TimeSpan FailMessageAppearTime => TimeSpan.FromMilliseconds(800);
    public static TimeSpan FailMessageShowTime => TimeSpan.FromMilliseconds(5000);
    public static Color FailMessageShadowColor => Colors.Black;
    public static Color FailMessageColor => Colors.IndianRed;
    public static Color SuccesMessageColor => Colors.Green;
}
