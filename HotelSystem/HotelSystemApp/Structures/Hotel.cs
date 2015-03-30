namespace HotelSystemApp.Structures
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using HotelSystemApp.Interfaces;
    using HotelSystemApp.Person;
    using HotelSystemApp.Rooms;
    using HotelSystemApp.Services;

    public struct Hotel : IReservationable
    {
        private string name;
        private List<Room> rooms;
        private List<Employee> employees;
        private List<Client> clients;
        private List<Service> services;

        public Hotel(string name, List<Room> rooms)
            : this()
        {
            this.Name = name;
            this.rooms = new List<Room>(rooms);
        }

        public Hotel(string name, List<Room> rooms, List<Employee> employees)
            : this(name, rooms)
        {
            this.employees = new List<Employee>(employees);
        }

        public Hotel(string name, List<Room> rooms, List<Employee> employees, List<Client> clients)
            : this(name, rooms, employees)
        {
            this.clients = new List<Client>(clients);
        }

        public Hotel(string name, List<Room> rooms, List<Employee> employees, List<Client> clients, List<Service> services)
            : this(name, rooms, employees, clients)
        {
            this.services = new List<Service>(services);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Hotel name can't be empty!");
                }

                foreach (char ch in value)
                {
                    if (!char.IsLetter(ch) || !char.IsWhiteSpace(ch))
                    {
                        throw new ArgumentException("Incorrect parameter hotel name!");
                    }

                    this.name = value;
                }
            }
        }

        public List<Room> Rooms
        {
            get
            {
                return this.rooms;
            }
        }

        public List<Employee> Employees
        {
            get
            {
                return this.employees;
            }
        }

        public List<Client> Clients
        {
            get
            {
                return this.clients;
            }
        }

        public List<Service> Services
        {
            get
            {
                return this.services;
            }
        }

        public void MakeReservation(Client client, Room someRoom)
        {
            this.Clients.Add(client);
            someRoom.CheckIn();
        }

        public List<Room> AvailableRooms()
        {
            var result = this.Rooms.Where(x => x.IsAvailable == true).ToList();

            return result;
        }

        public override string ToString()
        {
            StringBuilder hotel = new StringBuilder();

            Console.SetCursorPosition(20, 1);
            hotel.AppendFormat("*** {0} ***\n", this.Name.ToUpper());
            hotel.AppendLine("Rooms:");

            foreach (var room in this.Rooms)
            {
                hotel.AppendFormat("Number: {0,-5} Price: {1,-5} Type: {2,-10}\n", room.NumberOfRoom, room.Price, room.GetType().Name);
            }

            hotel.AppendLine("Employees:");

            foreach (var employee in this.Employees)
            {
                var name = employee.FirstName + " " + employee.LastName;
                hotel.AppendFormat("Name: {0,-25} Position: {1,-10}\n", name, employee.GetType().Name);
            }

            hotel.AppendLine("Clients:");

            foreach (var client in this.Clients)
            {
                var name = client.FirstName + " " + client.LastName;
                hotel.AppendFormat("Name: {0,-25} ID: {1,-12} Bill: {2}\n", name, client.ID, client.Bill);
            }

            hotel.AppendLine("Services:");

            foreach (var service in this.Services)
            {
                hotel.AppendFormat("Service: {0,-15} Price per hour: {1,-10}\n", service.GetType().Name, service.Price);
            }

            return hotel.ToString();
        }
    }
}
