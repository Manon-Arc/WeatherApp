using System.Net;
using System.Reactive;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;

namespace WeatherApp;

public partial class SplashWindowViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new RoutingState();
    
    // Command to navigates user to defined view model
    public static ReactiveCommand<Unit, IRoutableViewModel> GoWeather { get; set; }
    public static ReactiveCommand<Unit, IRoutableViewModel> GoSearch { get; set; }
    public static ReactiveCommand<Unit, IRoutableViewModel> GoSetting { get; set; }
    public static ReactiveCommand<Unit, IRoutableViewModel> GoNoConnection { get; set; }
    

    // Command to go back 1 time
    public ReactiveCommand<Unit, IRoutableViewModel> GoBack => Router.NavigateBack;
    
    
    public SplashWindowViewModel()
    {

        GoWeather = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new WeatherPageViewModel(this))
        );
        GoSearch = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new SearchPageViewModel(this))
        );
        GoSetting = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new SettingPageViewModel(this))
        );
        GoNoConnection = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new NoConnectionPageViewModel(this))
        );
        
    }public static bool CheckForInternetConnection()
    {
        try
        {
            using (var client = new WebClient())
            using (var stream = client.OpenRead("http://www.google.com"))
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
}