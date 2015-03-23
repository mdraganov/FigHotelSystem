namespace HotelSystemApp.Person
{
    using System.Collections.Generic;
    using HotelSystemApp.Rooms;
    using HotelSystemApp.Services;

    public class Client : Person
    {
        public Client(string firstName, string lastName, string address, string phoneNumber, string email)
            : base(firstName, lastName, address, phoneNumber, email)
        {
        }

        public string ID
        {
            get
            {
                return this.IBAN.GetHashCode().ToString();
            }
        }

        public string IBAN { get; set; }
        public decimal Bill { get; set; }
        public Room PaidRoom { get; set; }
        public List<Service> VisitedServices { get; set; }
    }
}
