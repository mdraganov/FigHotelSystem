namespace HotelSystemApp.Services
{
    public class SwimmingPool : Service
    {
        public SwimmingPool(decimal pricePerVisit = 10, int numberOfPersons = 1)
            : base(pricePerVisit, numberOfPersons)
        {
        }
    }
}
