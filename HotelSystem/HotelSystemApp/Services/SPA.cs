namespace HotelSystemApp.Services
{
    using HotelSystemApp.Enumerations;

    public class SPA : Service
    {
        public SPA(SPAProcedures spaProcedure, int numberOfPersons = 1)
            : base((int)spaProcedure, numberOfPersons)
        {
            this.SPAProcedure = spaProcedure;
        }

        public SPAProcedures SPAProcedure { get; set; }

        public override decimal CalculatePrice()
        {
            return (int)this.SPAProcedure * this.PersonsUsingService;
        }
    }
}