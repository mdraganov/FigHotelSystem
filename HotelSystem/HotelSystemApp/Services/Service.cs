namespace HotelSystemApp.Services
{
    using System;
    using HotelSystemApp.Interfaces;

    public abstract class Service : IPrice
    {
        private int personsUsingService; //How many persons are using the service on behalf of the client's account.
        private decimal price;

        public Service(decimal price, int numberOfPersons = 1)
        {
            this.PersonsUsingService = numberOfPersons;
            this.Price = price;
        }

        public virtual int PersonsUsingService
        {
            get
            {
                return this.personsUsingService;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("At least one person should be using the service.");
                }

                this.personsUsingService = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price should be zero or more.");
                }

                this.price = value;
            }
        }

        public virtual decimal CalculatePrice()
        {
            return this.Price * PersonsUsingService;
        }
    }
}