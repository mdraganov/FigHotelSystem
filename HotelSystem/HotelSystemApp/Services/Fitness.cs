namespace HotelSystemApp.Services
{
    public class Fitness : Service
    {
        public Fitness(decimal pricePerTraining = 5, int numberOfPersons = 1)
            : base(pricePerTraining, numberOfPersons)
        {
        }
    }
}