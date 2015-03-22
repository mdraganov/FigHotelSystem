using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelSystemApp
{
    public class Client : Person
    {
        public string ID { get; set; }
        public string IBAN { get; set; }
        public decimal Bill { get; set; }
        public Room PaidRoom { get; set; }
        public List<Service> VisitedServices { get; set; }
    }
}
