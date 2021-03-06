﻿namespace HotelSystemApp.Person
{
    using System;
    using System.Net.Mail;
    using System.Text;
    using System.Text.RegularExpressions;
    using HotelSystemApp.Interfaces;

    public abstract class Person : IPerson
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

                this.firstName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
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

                this.lastName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
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

                this.address = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
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

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("{0}", (this.FirstName + " " + this.LastName).PadRight(18)));
            result.Append(string.Format(" | {0}", this.Address.PadRight(8)));
            result.Append(string.Format(" | Contact:"));
            result.Append(string.Format(" {0} /", this.PhoneNumber.PadRight(11)));
            result.Append(string.Format(" {0}", this.Email.Address.PadLeft(18)));

            return result.ToString();
        }

        private void CheckPhone(string phone)
        {
            if (!Regex.IsMatch(phone.Trim(), @"\+?[()\d- ]+"))
            {
                throw new FormatException("Invalid phone!");
            }
        }

        private void CheckEmail(string email)
        {
            if (!Regex.IsMatch(email,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                throw new FormatException("Invalid email!");
            }
        }
    }
}
