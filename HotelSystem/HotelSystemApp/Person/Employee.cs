namespace HotelSystemApp.Person
{
    using System;
    using HotelSystemApp.Enumerations;
    using HotelSystemApp.Interfaces;

    public abstract class Employee : Person, IHire
    {
        private const byte MaxWorkHoursPerDay = 12;
        private decimal salary;
        private byte vacationDays;
        private byte workHoursADay;

        public Employee(string firstName, string lastName, string address, string phoneNumber, string email, decimal salary, byte vacationDays = 20, byte workHoursADay = 8)
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

        public void Hire(Person person, Employees type)
        {
            //switch (type)
            //{
            //    case Employees.BellBoy: person = new BellBoy(person); break;
            //    case Employees.Maid: person = new Maid(person); break;
            //    case Employees.Manager: person = new Manager(person); break;
            //    case Employees.Receptionist: person = new Receptionist(person); break;
            //}
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" | Position: {0} | Salary: ${1:2}", this.GetType().Name.PadRight(12), this.Salary.ToString().PadRight(10));
        }
    }
}
