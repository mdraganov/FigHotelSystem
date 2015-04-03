namespace HotelSystemApp.Interfaces
{
    using System;
    using HotelSystemApp.Person;

    public interface IReservationable
    {
        void MakeReservation(Client client, int numberOfRoom, DateTime checkIn, DateTime checkOut, byte numberOfGuests);
    }
}
