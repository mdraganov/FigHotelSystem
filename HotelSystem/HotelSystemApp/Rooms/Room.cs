namespace HotelSystemApp.Rooms
{
    using System;
    using System.Collections.Generic;
    using HotelSystemApp.Enumerations;
    using HotelSystemApp.Interfaces;

    public abstract class Room : IAvailable, IFeatures, IPrice
    {
        public int NumberOfRoom { get; set; }
        public int NumberOfBeds { get; set; }

        public bool IsAvailable
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public decimal Price
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public List<Features> AllFeaturesInRoom
        {
            get { throw new NotImplementedException(); }
        }

        public void AddFeature(Features someFeature)
        {
            throw new NotImplementedException();
        }

        public void RemoveFeature(Features someFeature)
        {
            throw new NotImplementedException();
        }


        public void CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}
