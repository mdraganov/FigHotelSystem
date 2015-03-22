using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelSystemApp.Person;

namespace HotelSystemApp
{
    public interface IReservationable
    {
        void MakeReservation(Client client, Room someRoom);
    }
}
