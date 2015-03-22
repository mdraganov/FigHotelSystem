namespace HotelSystemApp.Interfaces
{
    public interface IAvailable
    {
        bool IsAvailable { get; }
        void CheckIn();
        void CheckOut();
    }
}
