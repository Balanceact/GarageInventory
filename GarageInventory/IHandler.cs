namespace GarageInventory
{
    public interface IHandler
    {
        List<string> IsElectric { get; }
        List<string> IsForRent { get; }
        List<Vehicle> ListOfPredefinedVehicles { get; }
        IGarage<Vehicle> ListOfVehicles { get; }
        List<string> ListOfVehicleTypes { get; }
        IUI UI { get; }
        List<string> VehicleProperties { get; }

        void AddVehicle(int numberOfVehicles);
        void AddVehicleToList(Vehicle vehicle);
        Vehicle ListAllParked();
        void ListTypesAndAmounts();
        void Populate(int numberOfVehicles, int numberOfPredefined);
        void RemoveVehicle(Vehicle vehicle);
        void Search();
        Vehicle SearchByLicensePlateNumber(string searchParameter);
    }
}