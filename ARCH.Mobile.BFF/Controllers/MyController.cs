using ARCH.Shared.APIContracts.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARCH.Shared.APIContracts;

namespace ARCH.Mobile.BFF.Controllers
{
    [ApiController]
    [Route("API")]
    public class MyController : ControllerBase, ITestApi
    {
       
        [HttpGet("/users/{user}")]
        public async Task<User> GetUser(string user)
        {
            return new User
            {
                ID = user,
                Name = "TEST"
            };
        }
    }
}
