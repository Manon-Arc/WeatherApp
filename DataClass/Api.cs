using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace WeatherApp;

public class Api
{
    private dynamic configFile {get;set;}
    private string api_Key { get; set; }
    private HttpClient client = new HttpClient();

    public Api()
    {
        using StreamReader streamReader = new("./config.json");
        configFile = JObject.Parse(streamReader.ReadToEnd());
        api_Key = configFile.api_Key;
        
        string apiUrl = "https://api.openweathermap.org/";
        client.BaseAddress = new Uri(apiUrl);
    }

    public WeatherData GetWeather(float lat, float lon, string location, string lang)
    {
        string parametre = "data/2.5/weather?lat={0}&lon={1}&units=metric&lang={2}&appid={3}";
        parametre = string.Format(parametre, lat, lon, lang, api_Key);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = client.GetAsync(parametre).Result;

        if (!response.IsSuccessStatusCode) throw new Exception();

        string json = response.Content.ReadAsStringAsync().Result;
        WeatherData? weatherForecast = JsonSerializer.Deserialize<WeatherData>(json);
        weatherForecast.ville = location;
        weatherForecast.description = weatherForecast.weather[0].description;

        return weatherForecast;
    }
    
    public SearchData[] GetSearch(string input) // récupère la météo de la ville recherchée
    {
        string parametre = "geo/1.0/direct?q={0}&limit=5&appid={1}";
        parametre = String.Format(parametre,input, api_Key);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = client.GetAsync(parametre).Result;
        if (!response.IsSuccessStatusCode) throw new Exception();
        string json = response.Content.ReadAsStringAsync().Result;
        SearchData[] SearchRespond = JsonSerializer.Deserialize<SearchData[]>(json);
        return SearchRespond;
    }
    
    public WeatherData[] Get5DayForecastWeather(float lat, float lon, string location, string lang)
    {
        string parametre = "data/2.5/forecast?lat={0}&lon={1}&units=metric&lang={2}&appid={3}";
        parametre = string.Format(parametre, lat, lon, lang, api_Key);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = client.GetAsync(parametre).Result;
        if (!response.IsSuccessStatusCode) throw new Exception();
        string json = response.Content.ReadAsStringAsync().Result;
        FiveWeatherData Weathers = JsonSerializer.Deserialize<FiveWeatherData>(json);
        return Weathers.clearList();
    }
}