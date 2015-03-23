namespace HotelSystemApp.Person
{
    public class Manager : Employee
    {
        public Manager(string firstName, string lastName, string address, string phoneNumber, string email, decimal salary, byte vacationDays, byte workHoursADay)
            : base(firstName, lastName, address, phoneNumber, email, salary, vacationDays, workHoursADay)
        {
        }
    }
}
