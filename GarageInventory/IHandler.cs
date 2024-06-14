namespace GarageInventory
{
    internal interface IHandler
    {
        List<string> IsElectric { get; }
        List<string> IsForRent { get; }
        List<Vehicle> ListOfPredefinedVehicles { get; }
        List<string> ListOfVehicleTypes { get; }
        IUI UI { get; }

        void AddVehicle(Vehicle vehicle);
        void Populate(int numberOfVehicles, int numberOfPredefined);
        void RemoveVehicle(Vehicle vehicle);
    }
}