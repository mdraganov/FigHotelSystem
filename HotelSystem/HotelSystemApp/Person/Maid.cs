﻿namespace HotelSystemApp.Person
{
    public class Maid : Employee
    {
        public Maid(string firstName, string lastName, string address, string phoneNumber, string email, decimal salary, byte vacationDays = 20, byte workHoursADay = 8)
            : base(firstName, lastName, address, phoneNumber, email, salary, vacationDays, workHoursADay)
        {
        }
    }
}
