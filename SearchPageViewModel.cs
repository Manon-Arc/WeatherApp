using System;
using System.Net;
using System.Reactive;
using ReactiveUI;

namespace WeatherApp;

public class SearchPageViewModel : ReactiveObject, IRoutableViewModel
{
    public IScreen HostScreen { get; }

    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    public SearchPageViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}