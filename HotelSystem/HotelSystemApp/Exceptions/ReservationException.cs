using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystemApp.Exceptions
{
    public class ReservationException : ApplicationException
    {
        public ReservationException(string msg)
            :base(msg)
        {
        }

        public ReservationException(string msg, Exception innerEx)
            : base(msg, innerEx)
        {
        }
    }
}
