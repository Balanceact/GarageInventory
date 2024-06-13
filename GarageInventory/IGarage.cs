
namespace GarageInventory
{
    internal interface IGarage<T> where T : Vehicle
    {
        T this[int index] { get; }
        int Capacity { get; set; }
        int ParkingSpacesFilled { get; }
        IEnumerator<T> GetEnumerator();
    }
}