using DeployDemoRest.Services;
using DeployDemoRest.Services.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DeployDemoRest
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddOidcAuthentication(options =>
            {
                // Configure your authentication provider options here.
                // For more information, see https://aka.ms/blazor-standalone-auth
                builder.Configuration.Bind("Local", options.ProviderOptions);
            });

            builder.Services.AddHttpClient<IUsersDataService, UsersDataService>(x => x.BaseAddress = new Uri("https://demo-server-rest.herokuapp.com/"));
            builder.Services.AddHttpClient<IWeatherForecastService, WeatherForecastService>(x => x.BaseAddress = new Uri("https://demo-server-rest.herokuapp.com/"));

            await builder.Build().RunAsync();
        }
    }
}
