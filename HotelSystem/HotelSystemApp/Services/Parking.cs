namespace HotelSystemApp.Services
{
    using System;

    public class Parking : Service
    {
        private int daysUsed;

        public Parking(decimal pricePerDay = 10, int daysUsed = 1)
            : base(pricePerDay)
        {
            this.DaysUsed = daysUsed;
        }

        public int DaysUsed
        {
            get
            {
                return this.daysUsed;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Parking should be used for one day at least.");
                }

                this.daysUsed = value;
            }
        }

        public override decimal CalculatePrice()
        {
            return this.Price * this.DaysUsed;
        }
    }
}
