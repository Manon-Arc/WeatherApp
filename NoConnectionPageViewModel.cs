using System;
using System.Reactive;
using ReactiveUI;

namespace WeatherApp;

public partial class NoConnectionPageViewModel : ReactiveObject, IRoutableViewModel
{
    public IScreen HostScreen { get; }

    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    public NoConnectionPageViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}