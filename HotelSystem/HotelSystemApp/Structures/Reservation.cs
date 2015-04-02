namespace HotelSystemApp.Structures
{
    public struct Reservation
    {
        private string clientID;
        private int numberOfRoom;

        public Reservation(string clientID, int numberOfRooms)
            : this()
        {
            this.ClientID = clientID;
            this.NumberOfRoom = numberOfRoom;
        }

        public string ClientID
        {
            get { return this.clientID; }

            set { this.clientID = value; }
        }

        public int NumberOfRoom
        {
            get { return this.numberOfRoom; }

            set { this.numberOfRoom = value; }
        }
    }
}
