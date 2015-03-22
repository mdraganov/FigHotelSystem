namespace HotelSystemApp.Person
{
    using System.Collections.Generic;
    using HotelSystemApp.Rooms;
    using HotelSystemApp.Services;

    public class Client : Person
    {
        public string ID { get; set; }
        public string IBAN { get; set; }
        public decimal Bill { get; set; }
        public Room PaidRoom { get; set; }
        public List<Service> VisitedServices { get; set; }
    }
}
