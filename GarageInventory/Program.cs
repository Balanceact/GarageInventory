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
/*
    Functionality
    It should be possible to:
        List all parked vehicles
        List vehicle types and how many of each are in the garage
        Add and remove vehicles from the garage
        Set a capacity (number of parking spaces) when instantiating a new garage
        Populate the garage with a number of vehicles from the start
        Find a specific vehicle via the registration number. It should work with both ABC123 and Abc123 or AbC123.
        Search for vehicles based on one or more properties (all possible combinations from the base class Vehicle). For example:
            All black vehicles with four wheels.
            All pink motorcycles with 3 wheels.
            All trucks
            All red vehicles
        The user should receive feedback on whether things have gone well or badly.
        For example, when we park a vehicle, we want confirmation that the vehicle is parked. 
        If it does not work, the user should know why.
    The program should be a console application with a text-based user interface.
    From the interface, it should be possible to:
        Navigate to all functionality of the garage via the interface
        Create a garage with a user-specified size
        It should be possible to shut down the application from the interface
    The application should robustly handle input errors, so it does not crash with incorrect input or usage.
 */