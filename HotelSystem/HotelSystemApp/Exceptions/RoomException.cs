namespace HotelSystemApp.Exceptions
{
    using System;

    public class RoomException : Exception
    {
        private int availableRooms;

        public RoomException(string message, int availableRooms):base(message)
        {
            this.AvailableRooms = availableRooms;
        }

        public int AvailableRooms
        {
            get { return this.availableRooms; }
            private set { this.availableRooms = value; }
        }
    }
}
