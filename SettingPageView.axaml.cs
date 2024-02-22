using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Microsoft.VisualBasic.FileIO;
using ReactiveUI;
using WeatherApp.Enum;

namespace WeatherApp;

public partial class SettingPageView : ReactiveUserControl<SettingPageViewModel>
{
    public Label def_city => this.FindControl<Label>("defcity");
    public MenuItem def_language => this.FindControl<MenuItem>("deflanguage");
    
    
    public Image weatherImage => this.FindControl<Image>("WeatherImage");
    public Label tempLabel => this.FindControl<Label>("TempLabel");
    public Label descriptionLabel=> this.FindControl<Label>("DescriptionLabel");
    public Label cityName=> this.FindControl<Label>("CityName");
    public Label humidityLabel => this.FindControl<Label>("HudimityLabel");
    public SettingsData settings;
    private string jsonString;

    public SettingPageView()
    {
        string fileName = "../../../Json/option.json";
        string text = File.ReadAllText(fileName);
        settings = JsonSerializer.Deserialize<SettingsData>(text);
        settings.defaultWeather = new Api().GetWeather(settings.defaultCity.lat, settings.defaultCity.lon, settings.defaultCity.city, settings.language_str);

        this.WhenActivated(disposables =>
        {
            weatherImage.Source = settings.defaultWeather.img;
            tempLabel.Content = String.Format("{0} °C", settings.defaultWeather.main.temp);
            descriptionLabel.Content = settings.defaultWeather.description;
            cityName.Content = settings.defaultCity.city;
            humidityLabel.Content = String.Format("{0}%", settings.defaultWeather.main.humidity);

        });
        AvaloniaXamlLoader.Load(this);
        

        // Ecriture des settings
        jsonString = JsonSerializer.Serialize(settings);
        File.WriteAllText(fileName, jsonString);

        def_city.DataContext = settings;
        def_language.DataContext = settings;
    }
    private void GoSearch(object? sender, RoutedEventArgs e)
    {
        SplashWindowViewModel.GoSearch.Execute();
    }

    private void GoHome(object? sender, RoutedEventArgs e)
    {
        SplashWindowViewModel.GoWeather.Execute();
    }
    
    private void SetLanguage(object? sender, RoutedEventArgs e)
    {
        string fileName = "../../../Json/option.json";
        string text = File.ReadAllText(fileName);
        SettingsData settings = JsonSerializer.Deserialize<SettingsData>(text);
        Button b = (sender as Button);
        string jsonString;
        switch (b.Name)
        {
            case "af":
                settings.language = Languages.Afrikaans;
                string jsonString1 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString1);
                break;
            case "al":
                settings.language = Languages.Albanian;
                string jsonString2 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString2);
                break;
            case "ar":
                settings.language = Languages.Arabic;
                string jsonString3 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString3);
                break;
            case "az":
                settings.language = Languages.Azerbaijani;
                string jsonString4 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString4);
                break;
            case "bg":
                settings.language = Languages.Bulgarian;
                string jsonString5 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString5);
                break;
            case "ca":
                settings.language = Languages.Catalan;
                string jsonString6 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString6);
                break;
            case "cz":
                settings.language = Languages.Czech;
                string jsonString7 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString7);
                break;
            case "da":
                settings.language = Languages.Danish;
                string jsonString8 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString8);
                break;
             case "de":
                settings.language = Languages.German;
                string jsonString9 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString9);
                break;
             case "el":
                settings.language = Languages.German;
                string jsonString10 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString10);
                break;
             case "en":
                settings.language = Languages.English;
                string jsonString11 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString11);
                break;
             case "eu":
                settings.language = Languages.Basque;
                string jsonString12 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString12);
                break;
             case "fa":
                settings.language = Languages.Persian;
                string jsonString13 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString13);
                break;
             case "fi":
                settings.language = Languages.Finnish;
                string jsonString14 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString14);
                break;
             case "fr":
                settings.language = Languages.French;
                string jsonString15 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString15);
                break;
             case "gl":
                settings.language = Languages.Galician;
                string jsonString16 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString16);
                break;
             case "he":
                settings.language = Languages.Hebrew;
                string jsonString17 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString17);
                break;
             case "hi":
                settings.language = Languages.Hindi;
                string jsonString18 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString18);
                break;
             case "hr":
                settings.language = Languages.Croatian;
                string jsonString19 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString19);
                break;
            case "hu":
                settings.language = Languages.Hungarian;
                string jsonString20 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString20);
                break;
            case "id":
                settings.language = Languages.Indonesian;
                string jsonString21 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString21);
                break;
            case "it":
                settings.language = Languages.Italian;
                string jsonString22 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString22);
                break;
            case "ja":
                settings.language = Languages.Japanese;
                string jsonString23 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString23);
                break;
            case "kr":
                settings.language = Languages.Korean;
                string jsonString24 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString24);
                break;
            case "la":
                settings.language = Languages.Latvian;
                string jsonString25 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString25);
                break;
            case "lt":
                settings.language = Languages.Lithuanian;
                string jsonString26 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString26);
                break;
            case "mk":
                settings.language = Languages.Macedonian;
                string jsonString27 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString27);
                break;
            case "no":
                settings.language = Languages.Norwegian;
                string jsonString28 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString28);
                break;
            case "nl":
                settings.language = Languages.Dutch;
                string jsonString29 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString29);
                break;
            case "pl":
                settings.language = Languages.Polish;
                string jsonString30 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString30);
                break;
            case "pt":
                settings.language = Languages.Portuguese;
                string jsonString31 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString31);
                break;
            case "pt_br":
                settings.language = Languages.Português_Brasil;
                string jsonString32 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString32);
                break;
            case "ro":
                settings.language = Languages.Romanian;
                string jsonString33 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString33);
                break;
            case "ru":
                settings.language = Languages.Russian;
                string jsonString34 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString34);
                break;
            case "se":
                settings.language = Languages.Swedish;
                string jsonString35 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString35);
                break;
            case "sk":
                settings.language = Languages.Slovak;
                string jsonString36 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString36);
                break;
            case "sl":
                settings.language = Languages.Slovenian;
                string jsonString37 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString37);
                break;
            case "es":
                settings.language = Languages.Spanish;
                string jsonString38 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString38);
                break;
            case "sr":
                settings.language = Languages.Serbian;
                string jsonString39 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString39);
                break;
            case "th":
                settings.language = Languages.Thai;
                string jsonString40 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString40);
                break;
            case "tr":
                settings.language = Languages.Turkish;
                string jsonString41 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString41);
                break;
            case "ua":
                settings.language = Languages.Ukrainian;
                string jsonString42 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString42);
                break;
            case "vi":
                settings.language = Languages.Vietnamese;
                string jsonString43 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString43);
                break;
            case "zh_cn":
                settings.language = Languages.Chinese_Simplified;
                string jsonString44 = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString44);
                break;
            case "zh_tw":
                settings.language = Languages.Chinese_Traditional;
                jsonString = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString);
                break;
            case "zu":
                settings.language = Languages.Zulu;
                jsonString = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString);
                break;
            default:
                settings.language = Languages.French;
                jsonString = JsonSerializer.Serialize(settings);
                File.WriteAllText(fileName, jsonString);
                break;
        }

        SplashWindowViewModel.GoSetting.Execute();
    }

    private void RemoveCity(object? sender, RoutedEventArgs e)
    {
        string fileName = "../../../Json/option.json";
        string text = File.ReadAllText(fileName);
        settings = JsonSerializer.Deserialize<SettingsData>(text);
        settings.defaultCity = new SettingsData.DefaultCity();
        string jsonString = JsonSerializer.Serialize(settings);
        File.WriteAllText(fileName, jsonString);
        SplashWindowViewModel.GoSetting.Execute();
    }
}