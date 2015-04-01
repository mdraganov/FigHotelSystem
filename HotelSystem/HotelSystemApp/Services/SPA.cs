namespace HotelSystemApp.Services
{
    using HotelSystemApp.Enumerations;

    public class Spa : Service
    {
        public Spa(SpaProcedures spaProcedure, int numberOfPersons = 1)
            : base((int)spaProcedure, numberOfPersons)
        {
            this.SPAProcedure = spaProcedure;
        }

        public SpaProcedures SPAProcedure { get; set; }

        public override decimal CalculatePrice()
        {
            return (int)this.SPAProcedure * this.PersonsUsingService;
        }
    }
}