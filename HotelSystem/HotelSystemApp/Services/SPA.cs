namespace HotelSystemApp.Services
{
    using HotelSystemApp.Enumerations;

    public class Spa : Service
    {
        public Spa(SpaProcedures spaProcedure, int numberOfPersons = 1)
            : base((int)spaProcedure, numberOfPersons)
        {
            this.SpaProcedure = spaProcedure;
        }

        public SpaProcedures SpaProcedure { get; set; }

        public override decimal CalculatePrice()
        {
            return (int)this.SpaProcedure * this.PersonsUsingService;
        }
    }
}