namespace GarageInventory
{
    internal interface IHandler
    {
        void AddVehicle(Vehicle vehicle);
        void RemoveVehicle(Vehicle vehicle);
        void Populate(int numberOfVehicles);
    }
}