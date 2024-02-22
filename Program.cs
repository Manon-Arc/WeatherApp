using Avalonia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.ReactiveUI;

namespace WeatherApp;

class Program
{
    private const string FilePath = @"../../../Json/option.json";
    private const string FilePathConfig = @"../../../config.json";
    [STAThread]
    public static void Main(string[] args)
    {
        if (!Directory.Exists( @"../../../Json"))
        {
            Directory.CreateDirectory(@"../../../Json");
        }
        
        if (!File.Exists(FilePath))
        {
            CreateOptionJsonFile(FilePath);
        }
        
        if (!File.Exists(FilePathConfig))
        {
            CreateConfigJsonFile(FilePathConfig);
        }
        
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }
    
    static void CreateOptionJsonFile(string filePath)
    {
        SettingsData settings = new SettingsData();
        string jsonString = JsonSerializer.Serialize(settings);
        File.WriteAllText(filePath, jsonString);
    }
    
    static void CreateConfigJsonFile(string filePath)
    {
        File.WriteAllText(filePath, "");
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UseReactiveUI()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}