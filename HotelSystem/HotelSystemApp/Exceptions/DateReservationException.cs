namespace HotelSystemApp.Exceptions
{
    using System;

    public class DateReservationException : ApplicationException
    {
        public DateReservationException()
        {
        }

        public DateReservationException(string msg)
            : base(msg)
        {
        }

        public DateReservationException(string msg, Exception innerEx)
            : base(msg, innerEx)
        {
        }
    }
}
