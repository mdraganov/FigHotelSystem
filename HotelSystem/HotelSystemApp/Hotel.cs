using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelSystemApp
{
    public struct Hotel : IReservationable
    {
        public string Name { get; set; }

        public List<Room> Rooms { get; set; }

        public List<Employee> Employees { get; set; }

        public List<Client> Client { get; set; }

        public List<Service> Services { get; set; }
        public void MakeReservation(Client client, Room someRoom)
        {
            throw new NotImplementedException();
        }
    }
}
