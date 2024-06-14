using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace GarageInventory
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var host = Host.CreateDefaultBuilder(args)
               .ConfigureServices(services =>
               {
                   services.AddSingleton<IUI, UI>();
                   //services.AddSingleton<IGarage<Vehicle>>(new Garage<Vehicle>(0));
                   services.AddSingleton<Manager>();
               })
               .UseConsoleLifetime()
               .Build();

            host.Services.GetRequiredService<Manager>().Run();
        }
    }
}
