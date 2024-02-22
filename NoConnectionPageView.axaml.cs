using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Microsoft.VisualBasic.FileIO;
using ReactiveUI;

namespace WeatherApp;

public partial class NoConnectionPageView : ReactiveUserControl<NoConnectionPageViewModel>
{

    public NoConnectionPageView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
        ReCheck();
    }

    async void ReCheck()
    {
        if (!Refresh_bool())
        {
            await Task.Delay(2000);
            ReCheck();
        }
    }

    public void Refresh(object? sender, RoutedEventArgs routedEventArgs)
    {
        Refresh_bool();
    }

    public bool Refresh_bool()
    {
        if (SplashWindowViewModel.CheckForInternetConnection())
        {
            SplashWindowViewModel.GoWeather.Execute();
            return true;
        }
        return false;
    }
}