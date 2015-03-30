namespace HotelSystemApp.Services
{
    public class Sightseeing : Service
    {
        public Sightseeing(decimal pricePerTraining = 5, int numberOfPersons = 1)
            : base(pricePerTraining, numberOfPersons)
        {
        }
    }
}