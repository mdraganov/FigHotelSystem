namespace HotelSystemApp.Rooms
{
    using System;
    using System.Collections.Generic;
    using HotelSystemApp.Enumerations;
    using HotelSystemApp.Interfaces;

    public abstract class Room : IAvailable, IFeatures, IPrice
    {
        private int numberOfRoom;
        private decimal price;

        public Room(int numberOfRoom, decimal initialPrice, List<Features> featuresInRoom)
        {
            this.NumberOfRoom = numberOfRoom;
            this.Price = initialPrice;
            this.AllFeaturesInRoom = new List<Features>(featuresInRoom);
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

        public List<Features> AllFeaturesInRoom { get; protected set; }

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
    }
}
