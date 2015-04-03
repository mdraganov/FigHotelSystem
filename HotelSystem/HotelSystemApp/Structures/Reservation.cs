namespace HotelSystemApp.Structures
{
    using System;
    using System.Linq;
    using System.Text;

    public struct Reservation
    {
        private DateTime checkIn;
        private DateTime checkOut;
        private byte numberOfGuests;

        public Reservation(string clientID, int numberOfRoom, DateTime checkIn, DateTime checkOut, byte numberOfGuests, DateTime dateOfReservation)
            : this()
        {
            this.ClientID = clientID;
            this.NumberOfRoom = numberOfRoom;
            this.CheckIn = checkIn;
            this.CheckOut = checkOut;
            this.NumberOfGuests = numberOfGuests;
            this.DateOfReservation = dateOfReservation;
        }

        public string ClientID { get; set; }

        public int NumberOfRoom { get; set; }

        public DateTime DateOfReservation { get; set; }

        public DateTime CheckIn
        {
            get
            {
                return this.checkIn;
            }

            set
            {
                if (value < DateTime.Now)
                {
                    throw new IndexOutOfRangeException("CheckIn cannot be earlier than today!");
                }

                this.checkIn = value;
            }
        }

        public DateTime CheckOut
        {
            get
            {
                return this.checkOut;
            }

            set
            {
                if (value < this.checkIn)
                {
                    throw new IndexOutOfRangeException("CheckOUT date cannot be earlier than CheckIn date!");
                }

                this.checkOut = value;
            }
        }

        public byte NumberOfGuests
        {
            get
            {
                return this.numberOfGuests;
            }

            set
            {
                int currentNumberOfRoom = this.NumberOfRoom;
                var roomIndex = HotelSystemAppMain.firstTestHotel.Rooms.FindIndex(x => x.NumberOfRoom == currentNumberOfRoom);

                if (value > HotelSystemAppMain.firstTestHotel.Rooms[roomIndex].NumberOfBeds)
                {
                    throw new IndexOutOfRangeException("The number of guests cannot be more than number of beds!");
                }

                this.numberOfGuests = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(string.Format("Room №:{0,3}", this.NumberOfRoom));
            result.Append(string.Format(" | Arrive: {0}", this.CheckIn.ToString("dd.MM.yyyy")).PadLeft(10));
            result.Append(string.Format(" | Leave: {0}", this.CheckOut.ToString("dd.MM.yyyy")).PadLeft(10));
            result.Append(string.Format(" | Guests: {0}", this.NumberOfGuests));
            result.Append(string.Format(" | Date of reservation: {0}", this.DateOfReservation.ToString("dd.MM.yyyy")).PadLeft(10));

            string currentClientID = this.ClientID;
            var clientIndex = HotelSystemAppMain.firstTestHotel.Clients.FindIndex(x => x.ID == currentClientID);
            result.Append(string.Format(" | Client: {0}", HotelSystemAppMain.firstTestHotel.Clients[clientIndex].LastName));
            return result.ToString();
        }
    }
}
