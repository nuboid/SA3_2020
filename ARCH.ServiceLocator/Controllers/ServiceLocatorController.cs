using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ARCH.ServiceLocator.Controllers
{
   

    [ApiController]
    [Route("[controller]")]
    public class ServiceLocatorController : ControllerBase
    {

        public string GetUrlForService(string serviceName, string version)
        {
            //DB lookup
            return "domain.com/service/v1";
        }

        public void RegisterService(string serviceName, string version, string url)
        {
            //DB 
        }
    }
}
