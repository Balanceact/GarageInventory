namespace GarageInventory
{
    public interface IHandler
    {
        List<string> IsElectric { get; }
        List<string> IsForRent { get; }
        List<Vehicle> ListOfPredefinedVehicles { get; }
        List<string> ListOfVehicleTypes { get; }
        IUI UI { get; }

        void AddVehicle(int numberOfVehicles);
        void AddVehicleToList(Vehicle vehicle);
        Vehicle ListAllParked();
        void ListTypesAndAmounts();
        void Populate(int numberOfVehicles, int numberOfPredefined);
        void RemoveVehicle(Vehicle vehicle);
    }
}