using DeployDemoRest.Models.Users;
using DeployDemoRest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeployDemoRest.Services
{
    public class UsersDataService : IUsersDataService
    {
        private readonly HttpClient httpClient;

        public UsersDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<CurrentUserData> GetCurrentUserDataAsync()
        {
            var apiResponse = await this.httpClient.GetStreamAsync($"api/user");
            return await JsonSerializer.DeserializeAsync<CurrentUserData>
                     (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<CurrentUserData> LoginAsync(LoginInputData inputData)
        {
            try
            {
                var userJson = new StringContent(JsonSerializer.Serialize(inputData), Encoding.UTF8, "application/json");

                var response = await this.httpClient.PostAsync("api/login", userJson);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<CurrentUserData>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
