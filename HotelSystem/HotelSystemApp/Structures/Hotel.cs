namespace HotelSystemApp.Structures
{
    using System;
    using System.Collections.Generic;
    using HotelSystemApp.Interfaces;
    using HotelSystemApp.Person;
    using HotelSystemApp.Rooms;
    using HotelSystemApp.Services;

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
