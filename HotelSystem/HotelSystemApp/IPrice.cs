using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelSystemApp
{
    public interface IPrice
    {
        decimal Price { get; set; }
        void CalculatePrice();
    }
}
