namespace HotelSystemApp.Person
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HotelSystemApp;
    using HotelSystemApp.Rooms;
    using HotelSystemApp.Services;

    public class Client : Person
    {
        private string iban;
        private decimal bill;
        private List<Service> visitedServices;
        private Room room;

        public Client(string firstName, string lastName, string address, string phoneNumber, string email, string iban)
            : base(firstName, lastName, address, phoneNumber, email)
        {
            this.IBAN = iban;
            this.Bill = 0;
            this.visitedServices = new List<Service>();
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

        public string ClientID
        {
            get
            {
                if (this.room != null)
                {
                    return this.room.NumberOfRoom.ToString() + this.FirstName.Substring(0, 1) + this.LastName.Substring(0, 1);
                }
                else
                {
                    return "CL" + this.FirstName.Substring(0, 1) + this.LastName.Substring(0, 1);
                }
            }
        }

        public string ReservedRoom
        {
            get
            {
                if (this.room != null)
                {
                    return this.room.NumberOfRoom.ToString();
                }
                else
                {
                    return "none";
                }
            }
        }

        public List<Service> VisitedServices
        {
            get
            {
                return new List<Service>(this.visitedServices);
            }
        }

        public void AddRoom(Room room)
        {
            this.room = room;
            this.Bill += room.Price;
        }

        public void RemoveRoom(Room room)
        {
            this.bill -= room.Price; // ??
            this.room = null;
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

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.Append(string.Format("| Room: {0,4}", this.ReservedRoom));
            result.Append(string.Format(" | Bill = {0}", this.Bill.ToString(string.Format("C2")).PadLeft(10)));
            result.Append(string.Format(" | ID: {0,4}", this.ClientID));

            return result.ToString();
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
    }
}
