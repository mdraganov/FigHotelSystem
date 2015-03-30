namespace HotelSystemApp.Services
{
    public class SPA : Service
    {
        public SPA(decimal pricePerTraining = 5, int numberOfPersons = 1)
            : base(pricePerTraining, numberOfPersons)
        {
        }
    }
}
