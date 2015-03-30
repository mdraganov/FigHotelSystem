namespace HotelSystemApp.Services
{
    public class SPA : Service
    {
        public SPA(decimal pricePerVisit = 5, int numberOfPersons = 1)
            : base(pricePerVisit, numberOfPersons)
        {
        }
    }
}
