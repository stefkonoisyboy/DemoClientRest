using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeployDemoRest.Models.Users
{
    public class CurrentUserData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
