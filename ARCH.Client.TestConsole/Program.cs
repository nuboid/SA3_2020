using System;
using System.Threading.Tasks;
using ARCH.Client.Proxies;

namespace ARCH.Client.TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press key to test");
            Console.ReadKey();
            var p = new MyProxy();
            var user = await p.GetUser("test");
            Console.WriteLine(user.Name);

            Console.ReadKey();
        }
    }
}
