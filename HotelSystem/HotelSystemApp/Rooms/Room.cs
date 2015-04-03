namespace HotelSystemApp.Rooms
{
    using System;
    using System.Collections.Generic;
    using HotelSystemApp.Enumerations;
    using HotelSystemApp.Interfaces;
    using System.Text;

    public abstract class Room : IAvailable, IFeatures, IPrice
    {
        private int numberOfRoom;
        private decimal price;
        private List<Features> featuresInRoom;

        public Room(int numberOfRoom, decimal initialPrice)
        {
            this.NumberOfRoom = numberOfRoom;
            this.Price = initialPrice;
            this.AllFeaturesInRoom = new List<Features>();
            this.IsAvailable = true;
        }

        public int NumberOfRoom
        {
            get
            {
                return this.numberOfRoom;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid room number");
                }
                this.numberOfRoom = value;
            }
        }

        public abstract int NumberOfBeds { get; protected set; }

        public bool IsAvailable { get; protected set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid price");
                }
                this.price = value;
            }
        }

        public List<Features> AllFeaturesInRoom
        {
            get { return this.featuresInRoom; }
            set { this.featuresInRoom = value; }
        }


        public void AddFeature(Features someFeature)
        {
            this.AllFeaturesInRoom.Add(someFeature);
        }

        public void RemoveFeature(Features someFeature)
        {
            this.AllFeaturesInRoom.Remove(someFeature);
        }

        public decimal CalculatePrice()
        {
            var totalPrice = this.Price;

            if (this.AllFeaturesInRoom != null || this.AllFeaturesInRoom.Count == 0)
            {
                foreach (var feature in this.AllFeaturesInRoom)
                {
                    totalPrice += (int)feature;
                }
            }

            return totalPrice;
        }

        public void CheckIn()
        {
            this.IsAvailable = false;
        }

        public void CheckOut()
        {
            this.IsAvailable = true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            List<string> stringedFeatures = new List<string>();
            foreach (var ft in this.AllFeaturesInRoom)
            {
                stringedFeatures.Add(ft.ToString());
            }

            sb.Append(string.Format("Room[{0}] ", this.NumberOfRoom));
            sb.Append(string.Format("   Type: {0,5} ", this.GetType().Name));
            sb.Append(string.Format("   Price/Day: ${0,2} ", this.Price));
            sb.AppendLine(string.Format("   Available: {0,5} ", this.IsAvailable ? "YES" : "NO"));
            sb.AppendLine(string.Format("                   Extra features: {0}", stringedFeatures.Count == 0 ? "None" : string.Join(", ", stringedFeatures))); // this is not showing properly

            return sb.ToString();
        }
    }
}
