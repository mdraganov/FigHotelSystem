namespace HotelSystemApp.Exceptions
{
    using System;

    public class ReservationException : ApplicationException
    {
        public ReservationException(string msg)
            : base(msg)
        {
        }

        public ReservationException(string msg, Exception innerEx)
            : base(msg, innerEx)
        {
        }
    }
}
