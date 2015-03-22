using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelSystemApp
{
    public abstract class Service : IPrice
    {

        public decimal Price
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}
