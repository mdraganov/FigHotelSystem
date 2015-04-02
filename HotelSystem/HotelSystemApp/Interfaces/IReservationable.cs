namespace HotelSystemApp.Interfaces
{
    public interface IReservationable
    {
        void MakeReservation(string clientID, int numberOfRoom);
    }
}
