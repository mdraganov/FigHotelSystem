namespace HotelSystemApp.Person
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using HotelSystemApp.Rooms;
    using HotelSystemApp.Services;

    public class Client : Person
    {
        private string iban;
        private decimal bill;
        private List<Service> visitedServices;
        private List<Room> rooms;

        public Client(string firstName, string lastName, string address, string phoneNumber, string email, string iban)
            : base(firstName, lastName, address, phoneNumber, email)
        {
            this.IBAN = iban;
            this.Bill = 0;
            this.visitedServices = new List<Service>();
            this.rooms = new List<Room>();
        }

        public string ID
        {
            get
            {
                return (this.FirstName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.IBAN.GetHashCode()).ToString();
            }
        }

        public string IBAN
        {
            get
            {
                return this.iban;
            }

            private set
            {
                if (!this.ValidateBankAccount(value))
                {
                    throw new ArgumentException("IBAN is invalid!");
                }

                this.iban = value;
            }
        }

        public decimal Bill
        {
            get { return this.bill; }

            private set { this.bill = value; }
        }

        public List<Room> PaidRooms
        {
            get
            {
                return new List<Room>(this.rooms);
            }
        }

        public void AddRoom(Room room)
        {
            this.rooms.Add(room);
            this.Bill += room.Price;
        }

        public List<Service> VisitedServices
        {
            get
            {
                return new List<Service>(this.visitedServices);
            }
        }

        public void AddVisitedService(Service service)
        {
            this.visitedServices.Add(service);
            this.Bill += service.Price;
        }

        public void RemoveVisitedService(Service service)
        {
            this.visitedServices.Remove(service);
            this.bill -= service.Price;
        }

        private bool ValidateBankAccount(string bankAccount)
        {
            bankAccount = bankAccount.ToUpper(); // IN ORDER TO COPE WITH THE REGEX BELOW
            if (string.IsNullOrEmpty(bankAccount))
            {
                return false;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(bankAccount, "^[A-Z0-9]"))
            {
                bankAccount = bankAccount.Replace(" ", string.Empty);
                string bank = bankAccount.Substring(4, bankAccount.Length - 4) + bankAccount.Substring(0, 4);
                int asciiShift = 55;

                StringBuilder sb = new StringBuilder();
                foreach (char c in bank)
                {
                    int v;
                    if (char.IsLetter(c))
                    {
                        v = c - asciiShift;
                    }
                    else
                    {
                        v = int.Parse(c.ToString());
                    }

                    sb.Append(v);
                }

                string checkSumString = sb.ToString();
                int checksum = int.Parse(checkSumString.Substring(0, 1));
                for (int i = 1; i < checkSumString.Length; i++)
                {
                    int v = int.Parse(checkSumString.Substring(i, 1));
                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }

                return checksum == 1;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("Name {0} {1}, Bill = {2}", this.FirstName, this.LastName, this.Bill);
            //return base.ToString();
        }
    }
}
