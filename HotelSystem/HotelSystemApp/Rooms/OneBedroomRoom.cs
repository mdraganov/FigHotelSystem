namespace HotelSystemApp.Rooms
{
    using System;
    using System.Collections.Generic;
    using HotelSystemApp.Enumerations;
    public class OneBedroomRoom : Room
    {
        public OneBedroomRoom(int numberOfRoom, decimal initialPrice, List<Features> featuresInRoom)
            : base(numberOfRoom, initialPrice, featuresInRoom)
        {
            this.NumberOfBeds = 1;
        }
        public override int NumberOfBeds { get; protected set; }
    }
}
