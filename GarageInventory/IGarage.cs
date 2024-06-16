
namespace GarageInventory
{
    internal interface IGarage<T> where T : Vehicle
    {
        T this[int index] { get; set; }

        int Count { get; }
        int ParkingSpacesFilled { get; set; }
        bool IsFull { get; }

        IEnumerator<T> GetEnumerator();
        List<string> GetRange(int start, int end);
        void Remove(Vehicle vehicle);
    }
}