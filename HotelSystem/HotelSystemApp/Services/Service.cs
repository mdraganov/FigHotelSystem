namespace HotelSystemApp.Services
{
    using System;
    using HotelSystemApp.Interfaces;

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
