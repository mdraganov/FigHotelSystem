namespace HotelSystemApp.Person
{
    using System;

    public abstract class Employee : Person
    {
        private const byte MaxWorkHoursPerDay = 12;
        private decimal salary;
        private byte vacationDays;
        private byte workHoursADay;

        public Employee(string firstName, string lastName, string address, string phoneNumber, string email, decimal salary, byte vacationDays, byte workHoursADay)
            : base(firstName, lastName, address, phoneNumber, email)
        {
            this.Salary = salary;
            this.VacationDays = vacationDays;
            this.WorkHoursADay = workHoursADay;
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("Invalid salary value");
                }

                this.salary = value;
            }
        }

        public byte VacationDays
        {
            get { return this.vacationDays; }

            protected set { this.vacationDays = value; }
        }

        public byte WorkHoursADay
        {
            get
            {
                return this.workHoursADay;
            }

            protected set
            {
                if (value > MaxWorkHoursPerDay)
                {
                    throw new ArgumentOutOfRangeException("The value cannot be bigger than " + MaxWorkHoursPerDay);
                }

                this.workHoursADay = value;
            }
        }
    }
}
