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
}/* Functionality:
        It should be possible to:
            Search for vehicles based on one or more properties (all possible combinations from the base class Vehicle). For example:
                All black vehicles with four wheels.
                All pink motorcycles with 3 wheels.
                All trucks.
                All red vehicles.
        The application should robustly handle input errors, so it does not crash with incorrect input or usage.
    Unit Testing:
        Tests should be created in a separate test project. We limit ourselves to testing the public methods in the Garage class.
    Extra:
        It is possible in C# to write to and read from the file system from your application. Find out how to do this to be able to save your garage and load your garage.
        (Writing tests for the entire application is considered an extra task if time permits) */