namespace HotelSystemApp.Rooms
{
    using System;
    using System.Collections.Generic;
    using HotelSystemApp.Enumerations;
    public class TwoBedroomRoom : Room
    {
        public TwoBedroomRoom(int numberOfRoom, decimal initialPrice, List<Features> featuresInRoom)
            : base(numberOfRoom, initialPrice, featuresInRoom)
        {
            this.NumberOfBeds = 2;
        }
        public override int NumberOfBeds { get; protected set; }
    }
}
