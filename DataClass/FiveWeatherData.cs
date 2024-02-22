using System;
using System.Linq;

namespace WeatherApp;

public class FiveWeatherData
{
    public WeatherData[] list { get; set; }

    public WeatherData[] clearList()
    {
        WeatherData[] nlist = new WeatherData[] { };
        foreach (var weather in list)
        {
            if (DateTime.Parse(weather.dt_txt).Hour == 12)
            {
                nlist = nlist.Append(weather).ToArray();
            }
        }

        return nlist;
    }
}