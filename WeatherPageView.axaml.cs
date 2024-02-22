using System;
using System.Globalization;
using System.IO;
using System.Text.Json;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using WeatherApp.Enum;

namespace WeatherApp;

public partial class WeatherPageView : ReactiveUserControl<WeatherPageViewModel>
{
    public static float lat { get; set; }
    public static float lon { get; set; }
    public static string ville { get; set; } = String.Empty;

    public Label currentHumidityLabel => this.FindControl<Label>("CurrentHumidityLabel");
    public Label currentTempLabel => this.FindControl<Label>("CurrentTempLabel");
    public Label currentLocationLabel => this.FindControl<Label>("CurrentLocationLabel");
    public Label currentWeatherLabel => this.FindControl<Label>("CurrentWeatherLabel");
    public Image currentWeatherImage => this.FindControl<Image>("CurrentWeatherImage");
    public Image defaultSetimage => this.FindControl<Image>("DefaultSetImage");

    private static Api a { get; } = new Api();
    private WeatherData[] fiveDays { get; set; }
    private WeatherData CurrentWeather { get; set; }

    private SettingsData settings { get; set; }
    private string fileName = "../../../Json/option.json";

    public void Info()
    {
        int i = 0;
        foreach (var item in fiveDays)
        {
            Label? h = this.FindControl<Label>(String.Format("hour{0}", i+1));
            Label? hDay = this.FindControl<Label>(String.Format("HDay{0}", i+1));
            Label? tmpDay = this.FindControl<Label>(String.Format("TmpDay{0}", i+1));
            Label? stDay = this.FindControl<Label>(String.Format("StDay{0}", i+1));
            Label? day = this.FindControl<Label>(String.Format("Day{0}", i+1));
            Image? im = this.FindControl<Image>(String.Format("Im{0}", i+1));
            
            DateTime D = DateTime.Parse(item.dt_txt);
            
            h.Content = D.ToString("hh:mm");
            day.Content = D.DayOfWeek.ToString();
            stDay.Content = item.weather[0].description;
            hDay.Content = "Humidity : " + item.main.humidity + "%";
            tmpDay.Content = Math.Round(item.main.temp) + "°";
            im.Source = item.img;
            
            i++;
        }
    }

    public WeatherPageView()
    {
        string text = File.ReadAllText(fileName);
        settings = JsonSerializer.Deserialize<SettingsData>(text);
        if (ville == String.Empty)
        {
            lat = settings.defaultCity.lat;
            lon = settings.defaultCity.lon;
            ville = settings.defaultCity.city;
        }

        Api a = new Api();
        CurrentWeather = a.GetWeather(lat, lon, ville, settings.language_str);
        fiveDays = a.Get5DayForecastWeather(lat, lon, ville, settings.language_str);

        this.WhenActivated(disposables =>
        {
            if (lat == settings.defaultCity.lat && lon == settings.defaultCity.lon)
            {
                defaultSetimage.Source = new Avalonia.Media.Imaging.Bitmap("../../../Images/bookmarkcheck.png");
            }
            else
            {
                defaultSetimage.Source = new Avalonia.Media.Imaging.Bitmap("../../../Images/bookmark.png");
            }
            Info();
            currentTempLabel.Content = Math.Round(CurrentWeather.main.temp) + "°C";
            currentLocationLabel.Content = CurrentWeather.ville;
            currentHumidityLabel.Content = CurrentWeather.main.humidity + "%";

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            currentWeatherLabel.Content = textInfo.ToTitleCase(CurrentWeather.weather[0].description);

            currentWeatherImage.Source = CurrentWeather.img;
        });
        AvaloniaXamlLoader.Load(this);
    }

    private void SetDefaultCity(object? sender, RoutedEventArgs e)
    {
        if (lat == settings.defaultCity.lat && lon == settings.defaultCity.lon)
        {
            
            settings.defaultCity = new SettingsData.DefaultCity();
        }
        else
        {
            settings.defaultCity = new SettingsData.DefaultCity(lat, lon, ville);
        }
        string jsonString = JsonSerializer.Serialize(settings);
        File.WriteAllText(fileName, jsonString);
        SplashWindowViewModel.GoWeather.Execute();
    }

    private void GoSetting(object? sender, RoutedEventArgs e)
    {
        SplashWindowViewModel.GoSetting.Execute();
    }

    private void GoSearch(object? sender, RoutedEventArgs e)
    {
        SplashWindowViewModel.GoSearch.Execute();
    }
}