namespace HotelSystemApp.Services
{
    using System;

    public class SwimmingPool : Service
    {
        private int sunBedsUsed;
        private decimal sunBedPrice;

        public SwimmingPool(decimal pricePerVisit = 10, int numberOfPersons = 1, decimal sunBedPrice = 5)
            : base(pricePerVisit, numberOfPersons)
        {
            this.SunBedPrice = sunBedPrice;
        }

        public int SunBedsUsed
        {
            get
            {
                return this.sunBedsUsed;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input.");
                }

                this.sunBedsUsed = value;
            }
        }

        public decimal SunBedPrice
        {
            get
            {
                return this.sunBedPrice;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input.");
                }

                this.sunBedPrice = value;
            }
        }
        
        public override decimal CalculatePrice()
        {
            return this.Price * this.PersonsUsingService + this.SunBedsUsed * this.SunBedPrice;
        }
    }
}