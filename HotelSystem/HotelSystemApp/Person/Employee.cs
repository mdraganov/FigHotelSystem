namespace HotelSystemApp.Person
{
    public abstract class Employee : Person
    {
        public decimal Salary { get; set; }
        public int VacationDays { get; set; }
        public int WorkHoursADay { get; set; }
    }
}
