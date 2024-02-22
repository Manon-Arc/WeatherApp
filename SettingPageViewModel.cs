using System;
using System.Reactive;
using ReactiveUI;
namespace WeatherApp;

public class SettingPageViewModel : ReactiveObject, IRoutableViewModel
{
    public IScreen HostScreen { get; }

    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    public SettingPageViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}