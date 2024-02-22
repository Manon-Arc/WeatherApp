using System;
using ReactiveUI;

namespace WeatherApp;

public class AppViewLocator : ReactiveUI.IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
    {
        NoConnectionPageViewModel context => new NoConnectionPageView { DataContext = context },
        SettingPageViewModel context => new SettingPageView { DataContext = context },
        WeatherPageViewModel context => new WeatherPageView { DataContext = context },
        SearchPageViewModel context => new SearchPageView { DataContext = context },
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel)),
    };
}