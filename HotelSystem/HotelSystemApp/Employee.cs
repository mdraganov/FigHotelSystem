using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelSystemApp
{
    public abstract class Employee : Person
    {
        public decimal Salary { get; set; }
        public int VacationDays { get; set; }
        public int WorkHoursADay { get; set; }
    }
}
