namespace HotelSystemApp.Services
{
    using HotelSystemApp.Enumerations;

    public class SPA : Service
    {
        public SPA(decimal pricePerVisit = 5, int numberOfPersons = 1)
            : base(pricePerVisit, numberOfPersons)
        {
        }

        public override decimal CalculatePrice(SPAProcedures someSpa)
        {
            return (int)someSpa * this.PersonsUsingService;
        }
    }
}