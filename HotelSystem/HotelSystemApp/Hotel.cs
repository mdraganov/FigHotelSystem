namespace HotelSystemApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HotelSystemApp.Exceptions;
    using HotelSystemApp.Interfaces;
    using HotelSystemApp.Person;
    using HotelSystemApp.Rooms;
    using HotelSystemApp.Services;
    using HotelSystemApp.Structures;

    public class Hotel : IReservationable
    {
        private string name;
        private List<Room> rooms;
        private List<Employee> employees;
        private List<Client> clients;
        private List<Service> services;
        private List<Reservation> reservations;

        public Hotel(string name)
        {
            this.Name = name;
            this.rooms = new List<Room>();
            this.employees = new List<Employee>();
            this.clients = new List<Client>();
            this.services = new List<Service>();
            this.reservations = new List<Reservation>();
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

                this.name = value;
            }
        }

        public List<Room> Rooms
        {
            get
            {
                return new List<Room>(this.rooms);
            }
        }

        public List<Employee> Employees
        {
            get
            {
                return new List<Employee>(this.employees);
            }
        }

        public List<Client> Clients
        {
            get
            {
                return new List<Client>(this.clients);
            }
        }

        public List<Service> Services
        {
            get { return new List<Service>(this.services); }

        }

        public List<Reservation> Reservations
        {
            get
            {
                return new List<Reservation>(this.reservations);
            }
        }

        public List<Room> AvailableRooms()
        {
            var result = this.Rooms.Where(x => x.IsAvailable == true).ToList();

            return result;
        }

        public void MakeReservation(Client client, int numberOfRoom, DateTime checkIN, DateTime checkOUT, byte numberOfGuests)
        {
            Reservation newReservation = new Reservation();

            int roomIndex = this.rooms.FindIndex(x => x.NumberOfRoom == numberOfRoom);
            if (roomIndex == -1)
            {
                throw new RoomNumberException(numberOfRoom);
            }

            client.AddRoom(this.rooms[roomIndex]);
            client.Bill = (checkOUT.Day - checkIN.Day) * this.rooms[roomIndex].Price;
            this.rooms[roomIndex].CheckIn();

            newReservation.ClientID = client.ClientID;
            newReservation.NumberOfRoom = numberOfRoom;
            newReservation.CheckIn = checkIN;
            newReservation.CheckOut = checkOUT;
            newReservation.NumberOfGuests = numberOfGuests;
            newReservation.DateOfReservation = DateTime.Now;

            this.reservations.Add(newReservation);
        }

        public void CheckOutRoom(int numberOfRoom, string clientID)
        {
            int indexOfRoomForCheckingOut = this.rooms.FindIndex(x => x.NumberOfRoom == numberOfRoom);
            if (indexOfRoomForCheckingOut == -1)
            {
                throw new RoomNumberException(numberOfRoom);
            }

            int indexOfClient = this.clients.FindIndex(x => x.ClientID == clientID);
            if (indexOfClient == -1)
            {
                throw new ClientIDException(clientID);
            }
            try
            {
                this.rooms[indexOfRoomForCheckingOut].CheckOut();
            }
            catch (Exception)
            {
                throw new RoomAvailableException("The room is already available!");
            }

            int indexOfReservation = this.reservations.FindIndex(x => x.NumberOfRoom == numberOfRoom);
            if (this.reservations[indexOfReservation].ClientID != clientID)
            {
                throw new ReservationException("Invalid reservation");
            }

            this.reservations.RemoveAt(indexOfReservation);
            this.clients.RemoveAt(indexOfClient);

        }

        public void AddClient(Client newClient)
        {
            this.clients.Add(newClient);
        }

        public void AddEmployee(Employee newEmployee)
        {
            this.employees.Add(newEmployee);
        }

        public void AddRoom(Room newRoom)
        {
            this.rooms.Add(newRoom);
        }

        public void AddService(Service newService)
        {
            this.services.Add(newService);
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

            //foreach (var client in this.Clients)
            //{
            //    var name = client.FirstName + " " + client.LastName;
            //    hotel.AppendFormat("Name: {0,-25} ID: {1,-12} Bill: {2}\n", name, client.ID, client.Bill);
            //}

            hotel.AppendLine("Services:");

            foreach (var service in this.Services)
            {
                hotel.AppendFormat("Service: {0,-15} Price per hour: {1,-10}\n", service.GetType().Name, service.Price);
            }

            return hotel.ToString();
        }
    }
}
