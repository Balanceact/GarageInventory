namespace GarageInventory
{
    internal interface IHandler
    {
        List<string> ListOfVehicleTypes { get; }
        IUI UI { get; }

        void AddVehicle(Vehicle vehicle);
        void RemoveVehicle(Vehicle vehicle);
        void Populate(int prepopulated, int predefined);
    }
}