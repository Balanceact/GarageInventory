namespace GarageInventory
{
    internal interface IGarage<T> where T : Vehicle
    {
        T this[int index] { get; set; }

        int Count { get; }
        int ParkingSpacesFilled { get; set; }

        IEnumerator<T> GetEnumerator();
        void Remove(Vehicle vehicle);
    }
}