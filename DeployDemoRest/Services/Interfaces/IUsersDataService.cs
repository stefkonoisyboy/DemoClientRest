using DeployDemoRest.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeployDemoRest.Services.Interfaces
{
    public interface IUsersDataService
    {
        Task<CurrentUserData> GetCurrentUserDataAsync();

        Task<CurrentUserData> LoginAsync(LoginInputData inputData);
    }
}
