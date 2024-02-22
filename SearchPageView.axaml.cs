using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Microsoft.VisualBasic.FileIO;
using ReactiveUI;

namespace WeatherApp;

public partial class SearchPageView : ReactiveUserControl<SearchPageViewModel>
{
    Api api = new Api();
    private SettingsData settings { get; set; }
    private string fileName = "../../../Json/option.json";
    
    public ListBox searchRes => this.FindControl<ListBox>("SearchRes");
    public ListBox searchRes2 => this.FindControl<ListBox>("SearchRes2");
    public TextBox citySearch => this.FindControl<TextBox>("CitySearch");
    private SearchData[] res { get; set; }
    public SearchPageView()
    {
        this.WhenActivated(disposables =>
        {
           string text = File.ReadAllText(fileName);
           settings = JsonSerializer.Deserialize<SettingsData>(text);   
        });
        AvaloniaXamlLoader.Load(this);
    }
    
    private void Start_search(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(citySearch.Text) || citySearch.Text.Contains("&appid")) return;
        
        string? searchcity = citySearch.Text;
        res = api.GetSearch(searchcity);
        int i = 0;
        SearchData[] pair = new SearchData[]{};
        SearchData[] impair = new SearchData[]{};
        foreach (var d in res)
        {
            d.weatherdata = api.GetWeather(d.lat, d.lon, d.name, settings.language_str);
            if (i % 2 == 0)
            {
                pair = pair.Append(d).ToArray();
            }
            else
            {
                impair = impair.Append(d).ToArray();
            }

            i++;
        }
        searchRes.ItemsSource = pair;
        searchRes2.ItemsSource = impair;
    }

    private void SearchRes_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        WeatherPageView.lat = ((sender as ListBox).SelectedItems[0] as SearchData).lat;
        WeatherPageView.lon = ((sender as ListBox).SelectedItems[0] as SearchData).lon;
        WeatherPageView.ville = ((sender as ListBox).SelectedItems[0] as SearchData).name.ToString();
        
        SplashWindowViewModel.GoWeather.Execute();
        Console.WriteLine(api.GetWeather(((sender as ListBox).SelectedItems[0] as SearchData).lat, ((sender as ListBox).SelectedItems[0] as SearchData).lon, ((sender as ListBox).SelectedItems[0] as SearchData).name, settings.language_str).ToString());
    }

    private void GoSetting(object? sender, RoutedEventArgs e)
    {
        SplashWindowViewModel.GoSetting.Execute();
    }

    private void GoHome(object? sender, RoutedEventArgs e)
    {
        SplashWindowViewModel.GoWeather.Execute();
    }
}