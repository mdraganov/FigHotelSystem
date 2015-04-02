namespace HotelSystemApp.Person
{
    using System;
    using System.Net.Mail;
    using System.Text;
    using System.Text.RegularExpressions;

    public abstract class Person
    {
        private string firstName;
        private string lastName;
        private string address;
        private string phoneNumber;
        private MailAddress email;

        public Person(string firstName, string lastName, string address, string phoneNumber, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = new MailAddress(email);
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The firstName cannot be empty");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The lastName cannot be empty");
                }

                this.lastName = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The address cannot be empty");
                }

                this.address = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            protected set
            {
                this.CheckPhone(value);

                this.phoneNumber = value;
            }
        }

        public MailAddress Email
        {
            get
            {
                if (this.email == null)
                {
                    throw new ArgumentException();
                }

                return this.email;
            }

            protected set
            {
                this.CheckEmail(value.Address);

                this.email = value;
            }
        }

        private void CheckPhone(string phone)
        {
            if (!Regex.IsMatch(phone.Trim(), @"\+?[()\d- ]+"))
            {
                throw new ArgumentException("Invalid phone!");
            }
        }

        private void CheckEmail(string email)
        {
            if (!Regex.IsMatch(email,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                throw new ArgumentException("Invalid email!");
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("{0} | address: {1} | phone: {2} | email: {3}", 
                (this.FirstName + " " + this.LastName).PadRight(14), 
                this.Address.PadLeft(8), 
                this.PhoneNumber.PadLeft(9), 
                this.Email.Address.PadLeft(15))
                );

            return result.ToString();
        }
    }
}
