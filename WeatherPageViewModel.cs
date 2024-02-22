using System;
using System.Globalization;
using Avalonia.Controls;
using ReactiveUI;

namespace WeatherApp;

public class WeatherPageViewModel : ReactiveObject, IRoutableViewModel
{
    public IScreen HostScreen { get; }

    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    public WeatherPageViewModel(IScreen screen)
    {
        HostScreen = screen;
    }
}