using Avalonia.Threading;
using System;
using System.Threading.Tasks;

namespace AUITemplate.Core.Timers;

public class CountdownTimer
{
    private DispatcherTimer? countdownTimer;
    public bool isCounting = false;
    private TimeSpan HowLong = TimeSpan.Zero;
    private EventHandler? Type;
    private async Task TaskStartCounting()
    {
        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            countdownTimer = new()
            {
                Interval = HowLong,
            };
            countdownTimer.Tick += Type;
            countdownTimer.Start();
        });
    }
    private async Task TaskStopCounting()
    {
        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            countdownTimer?.Stop();
            countdownTimer = null;
        });
    }
    public async void StartCounting(TimeSpan howLong, EventHandler type)
    {
        HowLong = howLong;
        Type = type;
        isCounting = true;
        await Task.Run(TaskStartCounting);
    }
    public async void StopCounting()
    {
        isCounting = false;
        await Task.Run(TaskStopCounting);
    }
}
