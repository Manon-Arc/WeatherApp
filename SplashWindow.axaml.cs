using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using WeatherApp.Enum;

namespace WeatherApp;

public partial class SplashWindow : ReactiveWindow<SplashWindowViewModel>
{
    public SplashWindow()
    {
        Width = 800;
        Height = 500;
        bool network_available = SplashWindowViewModel.CheckForInternetConnection();
        AvaloniaXamlLoader.Load(this);
        Console.WriteLine(network_available);
        this.WhenActivated(disposables =>
        {
            if (network_available)
            {
                Console.WriteLine("in splash");
                ShowSplashScreen();
            }
            else
            {
                Console.WriteLine("in no connection");
                ShowNoConnectionScreen();
            }

        });
         
        async void ShowSplashScreen()
        {
             
            await Task.Delay(1000);
            await Start();
        }

        async void ShowNoConnectionScreen()
        {
            await Task.Delay(1000);
            await NoConnection();
        }

        async Task Start()
        {
            SplashWindowViewModel.GoWeather.Execute();
        }

        async Task NoConnection()
        {
            SplashWindowViewModel.GoNoConnection.Execute();
        }
    }
}