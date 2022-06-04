using DeployDemoRest.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeployDemoRest.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherData>> GetWeatherDataAsync();
    }
}
