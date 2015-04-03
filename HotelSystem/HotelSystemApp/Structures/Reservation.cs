namespace HotelSystemApp.Structures
{
    public struct Reservation
    {
        public Reservation(string clientID, int numberOfRoom)
            : this()
        {
            this.ClientID = clientID;
            this.NumberOfRoom = numberOfRoom;
        }

        public string ClientID { get; set; }

        public int NumberOfRoom { get; set; }
    }
}
