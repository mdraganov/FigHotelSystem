namespace HotelSystemApp.Exceptions
{
    using System;

    public class RoomAvailableException : ApplicationException
    {
        public RoomAvailableException()
        {
        }

        public RoomAvailableException(string msg)
            : base(msg)
        {
        }
    }
}
