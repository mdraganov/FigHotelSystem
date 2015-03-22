namespace HotelSystemApp.Interfaces
{
    using HotelSystemApp.Person;
    using HotelSystemApp.Rooms;

    public interface IReservationable
    {
        void MakeReservation(Client client, Room someRoom);
    }
}
