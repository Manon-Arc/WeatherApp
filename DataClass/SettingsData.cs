using System;
using WeatherApp.Enum;

namespace WeatherApp;

public class SettingsData
{
    public WeatherData defaultWeather { get; set; }
    public Languages language { get; set; } = Languages.French;
    public DefaultCity defaultCity { get; set; } = new DefaultCity();

    public string language_str
    {
        get
        {
            switch (language)
            {
                case Languages.Afrikaans:
                    return "af";
                case Languages.Albanian:
                    return "al";
                case Languages.Arabic:
                    return "ar";
                case Languages.Azerbaijani:
                    return "az";
                case Languages.Bulgarian:
                    return "bg";
                case Languages.Catalan:
                    return "ca";
                case Languages.Czech:
                    return "cz";
                case Languages.Danish:
                    return "da";
                case Languages.German:
                    return "de";
                case Languages.Greek:
                    return "el";
                case Languages.English:
                    return "en";
                case Languages.Basque:
                    return "eu";
                case Languages.Persian:
                    return "fa";
                case Languages.Finnish:
                    return "fi";
                case Languages.French:
                    return "fr";
                case Languages.Galician:
                    return "gl";
                case Languages.Hebrew:
                    return "he";
                case Languages.Hindi:
                    return "hi";
                case Languages.Croatian:
                    return "hr";
                case Languages.Hungarian:
                    return "hu";
                case Languages.Indonesian:
                    return "id";
                case Languages.Italian:
                    return "it";
                case Languages.Japanese:
                    return "ja";
                case Languages.Korean:
                    return "kr";
                case Languages.Latvian:
                    return "la";
                case Languages.Lithuanian:
                    return "lt";
                case Languages.Macedonian:
                    return "mk";
                case Languages.Norwegian:
                    return "no";
                case Languages.Dutch:
                    return "nl";
                case Languages.Polish:
                    return "pl";
                case Languages.Portuguese:
                    return "pt"; 
                case Languages.Português_Brasil:
                    return "pt_br";
                case Languages.Romanian:
                    return "ro";
                case Languages.Russian:
                    return "ru";
                case Languages.Swedish:
                    return "se";
                case Languages.Slovak:
                    return "sk";
                case Languages.Slovenian:
                    return "sl";
                case Languages.Spanish:
                    return "es";
                case Languages.Serbian:
                    return "sr";
                case Languages.Thai:
                    return "th";
                case Languages.Turkish:
                    return "tr";
                case Languages.Ukrainian:
                    return "ua";
                case Languages.Vietnamese:
                    return "vi";
                case Languages.Chinese_Simplified:
                    return "zh_cn";
                case Languages.Chinese_Traditional:
                    return "zh_tw";
                case Languages.Zulu:
                    return "zu";
                default:
                    return "fr";
            }
        }
    }

    public SettingsData()
    {
        
    }
    
    public class DefaultCity
    {
        public float lat { get; set; } = 44.7938f;
        public float lon { get; set; } = -0.6063f;
        public string city { get; set; } = "Bordeaux";

        public WeatherData defaultWeather { get; set; }

        public DefaultCity()
        {
            
        }

        public DefaultCity(float lat, float lon, string city)
        {
            this.lat = lat;
            this.lon = lon;
            this.city = city;
        }
    }
}