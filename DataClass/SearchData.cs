using System;
using System.Globalization;

namespace WeatherApp;

public class SearchData
{
    public string name { get; set; }
    public float lat { get; set; }
    public float lon { get; set; }
    public string country { get; set; }
    public string state { get; set; }
    public WeatherData weatherdata { get; set; }
    
    public Avalonia.Media.Imaging.Bitmap flag
    {
        get
        {
            return new Avalonia.Media.Imaging.Bitmap(String.Format("../../../Images/Flags/{0}.png",country.ToLower()));
        }
    }

    public string state_country
    {
        get
        {
            return String.Format("{0}; {1}", state, country);
        }
    }

    public string lat_long
    {
        get
        {
            return String.Format("{0}, {1}", lat, lon);
        }
    }
}