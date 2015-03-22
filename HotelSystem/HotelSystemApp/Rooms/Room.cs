namespace HotelSystemApp.Rooms
{
    using System;
    using System.Collections.Generic;
    using HotelSystemApp.Enumerations;
    using HotelSystemApp.Interfaces;

    public abstract class Room : IAvailable, IFeatures, IPrice
    {
        private int numberOfBeds;
        private int numberOfRoom;
        private decimal price;
        public Room()
        {

        }
        public Room(int numberOfBeds, int numberOfRoom, decimal initialPrice, List<Features> featuresInRoom)
        {
            this.NumberOfBeds = numberOfBeds;
            this.NumberOfRoom = numberOfRoom;
            this.Price = initialPrice;
            this.AllFeaturesInRoom = new List<Features>(featuresInRoom);
            this.IsAvailable = true;
            CalculatePrice();
        }
        public int NumberOfRoom
        {
            get
            {
                return this.numberOfRoom;
            }
            set
            {
                if (value < 100 || value > 1000)
                {
                    throw new ArgumentException("Invalid room number");
                }
                this.numberOfRoom = value;
            }
        }
        public int NumberOfBeds 
        { 
            get
            {
                return this.numberOfBeds;
            }
            set
            {
                if (value < 1 || value > 4)
                {
                    throw new ArgumentException("Too many beds");
                }
                this.numberOfBeds = value;
            }
        }
        public bool IsAvailable { get; protected set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
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

        public void CalculatePrice()
        {
            foreach (var feature in AllFeaturesInRoom)
            {
                this.Price += (int)feature;
            }
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
