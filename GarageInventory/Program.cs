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
                   services.AddSingleton<Manager>();
                   services.AddSingleton<IHandler, Handler>();
               })
               .UseConsoleLifetime()
               .Build();

            host.Services.GetRequiredService<Manager>().Run();
        }
    }
}/* Unit Testing:
        Tests should be created in a separate test project. We limit ourselves to testing the public methods in the Garage class.
    Extra:
        (Writing tests for the entire application is considered an extra task if time permits) */