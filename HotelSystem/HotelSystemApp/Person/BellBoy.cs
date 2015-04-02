namespace HotelSystemApp.Person
{
    public class BellBoy : Employee
    {
        public BellBoy(string firstName, string lastName, string address, string phoneNumber, string email, decimal salary, byte vacationDays = 20, byte workHoursADay = 8)
            : base(firstName, lastName, address, phoneNumber, email, salary, vacationDays, workHoursADay)
        {
        }
    }
}
