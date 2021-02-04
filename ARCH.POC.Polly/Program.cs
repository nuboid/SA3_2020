using System;
using System.Net.Http;
using System.Threading.Tasks;
using ARCH.Microservice001.WebAPI.Controllers;
using ARCH.Microservice001.WebAPI.Controllers.IOCDemo;
using Microsoft.VisualBasic.CompilerServices;
using Polly;

namespace ARCH.POC.Polly
{
    public class OurExceptionToRetry : Exception{

    }
    class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine("Polly");
            var httpClient = new HttpClient();
            
            var ID = Guid.NewGuid().ToString();
            httpClient.DefaultRequestHeaders.Add("id", ID);
            try
            {
                var p = Policy
                    .Handle<OurExceptionToRetry>()
                    .WaitAndRetry(new[]
                    {
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(8),
                        TimeSpan.FromSeconds(22)
                    });

                p.Execute(async () =>
                {
                    try
                    {

                        Console.WriteLine("*************************" + DateTime.Now.Second);
                        //var dto = new SomeDTO();
                        //dto.ID = ID;
                       
                        var response = await httpClient.PostAsync("URL",null);
                        response.EnsureSuccessStatusCode();
                        var json = await response.Content.ReadAsStringAsync();
                        throw new DivideByZeroException();
                    }
                    catch (Exception ex)
                    {
                        throw new OurExceptionToRetry();
                    }
                });
            }
            catch (OurExceptionToRetry ex)
            {
                Console.WriteLine(ex);
              
            }
        }
    }
}
