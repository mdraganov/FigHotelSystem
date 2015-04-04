namespace HotelSystemApp.Exceptions
{
    using System;

    public class RoomNumberException : Exception
    {
        private int room;

        public RoomNumberException(string msg)
            : base(msg)
        {
        }

        public RoomNumberException(string msg, int room, Exception innerEx)
            : base(msg, innerEx)
        {
            this.room = room;
        }

        public RoomNumberException(string msg, int room)
            : this(msg, room, null)
        {
        }

        public RoomNumberException(int room)
            : this(null, room)
        {
        }

        public override string Message
        {
            get
            {
                return "Invalid number of room: " + this.room;
            }
        }
    }
}
