namespace HotelSystemApp.Interfaces
{
    using HotelSystemApp.Person;

    public interface IReservationable
    {
        void MakeReservation(Client client, int numberOfRoom);
    }
}
