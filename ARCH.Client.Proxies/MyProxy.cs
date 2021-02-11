using ARCH.Shared.APIContracts.DTOs;
using System;
using System.Threading.Tasks;
using ARCH.Shared.APIContracts;
using Refit;
using User = ARCH.Shared.APIContracts.DTOs.User;

namespace ARCH.Client.Proxies
{
    public class MyProxy
    {

        public async Task<User> GetUser(string id)
        {
            //var myApi = RestService.For<ITestApi>("http://localhost:44334");
            //var user = await myApi.GetUser("octocat");
            //return user;

            var user = new User
            {
                Name = id + " TEST"
            };

            return user;
        }
    }
}
