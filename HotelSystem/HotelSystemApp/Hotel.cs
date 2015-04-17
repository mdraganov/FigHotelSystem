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
        private string address;
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

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Hotel address cannot be null or empty!");
                }

                this.address = value;
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

            this.rooms[roomIndex].CheckIn();
            client.AddRoom(this.rooms[roomIndex]);
            client.Bill = (checkOUT.Day - checkIN.Day) * this.rooms[roomIndex].Price;

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

            int indexOfReservation = this.reservations.FindIndex(x => x.NumberOfRoom == numberOfRoom);
            if (indexOfReservation == -1 || this.reservations[indexOfReservation].ClientID != clientID)
            {
                throw new ReservationException("Invalid reservation");
            }

            try
            {
                this.rooms[indexOfRoomForCheckingOut].CheckOut();
            }
            catch (Exception)
            {
                throw new RoomAvailableException("The room is already available!");
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

        public List<string> PrintInfo()
        {
            List<string> result = new List<string>();

            Console.SetCursorPosition(20, 1);
            result.Add(string.Format("*** {0} ***\n", this.Name.ToUpper()));
            result.Add(Environment.NewLine);
            result.Add(string.Format("Address: {0}", this.Address));
            result.Add(string.Format("Number of rooms: {0}", this.rooms.Count));
            result.Add(string.Format("Number of employees: {0}", this.employees.Count));
            result.Add(string.Format("Number of registered clients: {0}", this.clients.Count));
            result.Add(string.Format("Number of services: {0}", this.services.Count));
            result.Add(Environment.NewLine);

            result.Add("List of employees:");

            var sortedEmployees = this.employees.OrderBy(x => x.LastName).ToList();
            for (int i = 0; i < sortedEmployees.Count; i++)
            {
                result.Add(string.Format("Name: {0} - {1}", sortedEmployees[i].LastName.PadRight(10), sortedEmployees[i].GetType().Name));
            }

            return result;
        }
    }
}
