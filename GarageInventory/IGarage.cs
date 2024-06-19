namespace GarageInventory
{
    public interface IGarage<T> where T : Vehicle
    {
        T this[int index] { get; set; }

        int Count { get; }
        int ParkingSpacesFilled { get; set; }
        bool IsFull { get; }

        IEnumerator<T> GetEnumerator();
        List<string> AllParkedToString();
        void Remove(Vehicle vehicle);
    }
}