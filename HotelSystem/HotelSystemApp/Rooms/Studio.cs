namespace HotelSystemApp.Rooms
{
    using System;
    using System.Collections.Generic;
    using HotelSystemApp.Enumerations;
    public class Studio : Room
    {
        public Studio(int numberOfRoom, decimal initialPrice, List<Features> featuresInRoom)
            : base(numberOfRoom, initialPrice, featuresInRoom)
        {
            this.NumberOfBeds = 3;
        }
        public override int NumberOfBeds { get; protected set; }
    }
}
