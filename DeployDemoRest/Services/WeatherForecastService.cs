using DeployDemoRest.Models;
using DeployDemoRest.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeployDemoRest.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient httpClient;

        public WeatherForecastService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<WeatherData>> GetWeatherDataAsync()
        {
            var apiResponse = await this.httpClient.GetStreamAsync("WeatherForecast");
            return await JsonSerializer.DeserializeAsync<IEnumerable<WeatherData>>
                     (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
