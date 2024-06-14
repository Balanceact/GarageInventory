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
                   services.AddSingleton<IHandler, Handler>();
               })
               .UseConsoleLifetime()
               .Build();

            host.Services.GetRequiredService<Manager>().Run();
        }
    }
}
/*  Requirements Specification
        The registration number is unique.
    Functionality
        It should be possible to:
            List all parked vehicles
            List vehicle types and how many of each are in the garage
            Add and remove vehicles from the garage
            Find a specific vehicle via the registration number. It should work with both ABC123 and Abc123 or AbC123.
            Search for vehicles based on one or more properties (all possible combinations from the base class Vehicle). For example:
                All black vehicles with four wheels.
                All pink motorcycles with 3 wheels.
                All trucks
                All red vehicles
            It should be possible to shut down the application from the interface
        The application should robustly handle input errors, so it does not crash with incorrect input or usage.
 */