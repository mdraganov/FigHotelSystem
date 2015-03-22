using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelSystemApp
{
    public interface IReservationable
    {
        void MakeReservation(Client client, Room someRoom);
    }
}
