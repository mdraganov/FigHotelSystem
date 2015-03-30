namespace HotelSystemApp.Exceptions
{
    using System;

    public class VacationDaysException:Exception
    {
        private int vacationDays;

        public VacationDaysException(string message, int vacationDays)
            : base(message)
        {
            this.VacationDays = vacationDays;
        }

        public int VacationDays
        {
            get { return this.vacationDays; }
            private set { this.vacationDays = value; }
        }
    }
}
