namespace HotelSystemApp.Interfaces
{
    using HotelSystemApp.Person;
    using HotelSystemApp.Rooms;

    public interface IReservationable
    {
        void MakeReservation(string clientID, int numberOfRoom);
    }
}
