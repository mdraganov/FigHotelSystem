namespace HotelSystemApp.Exceptions
{
    using System;

    public class EmployeeTypeException : Exception
    {
        private int employeeType;

        public EmployeeTypeException(string msg)
            : base(msg)
        {
        }

        public EmployeeTypeException(string msg, int empType, Exception innerEx)
            : base(msg, innerEx)
        {
            this.employeeType = empType;
        }

        public EmployeeTypeException(string msg, int empType)
            : this(msg, empType, null)
        {
        }

        public EmployeeTypeException(int empType)
            : this(null, empType)
        {
        }

        public override string Message
        {
            get
            {
                return "Invalid employee type: " + this.employeeType;
            }
        }
    }
}
