using System;
using System.Collections.Generic;
using Avalonia.Controls;

namespace WeatherApp;

public class WeatherData
{
    
    public Coord coord { get; set; }
    public Weather[] weather { get; set; }
    public Releve main { get; set; }
    public string description { get; set; }
    public string ville { get; set; }
    public string dt_txt { get; set; }
    public override string ToString()
    {
        return String.Format("name : {0}, description: {1}", ville, description);
    }
    public Avalonia.Media.Imaging.Bitmap img
    {
        get
        {
            return new Avalonia.Media.Imaging.Bitmap(String.Format("../../../Images/{0}.png", weather[0].icon));
        }
    }
}

public class Coord
{
    public double lon { get; set; }
    public double lat { get; set; }
    
    public Coord()
    {
        
    }
}

public class Weather
{
    public string description { get; set; }
    public string _icon;

    public string icon
    {
        get
        {
            return _icon.Replace("n", "d");
        }
        set
        {
            _icon = value;
        }
    }

    public Weather()
    {
        
    }
}

public class Releve
{
    public double temp { get; set; }
    public double temp_min { get; set; }
    public double temp_max { get; set; }
    public double humidity { get; set; }
    
    public Releve()
    {
        
    }
}