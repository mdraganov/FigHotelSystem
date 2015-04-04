namespace HotelSystemApp.Exceptions
{
    using System;

    public class RoomBedroomsException : ApplicationException
    {
        private int numberOfBeds;

        public RoomBedroomsException(string msg)
            : base(msg)
        {
        }

        public RoomBedroomsException(string msg, int numberOfBeds, Exception innerEx)
            : base(msg, innerEx)
        {
            this.numberOfBeds = numberOfBeds;
        }

        public RoomBedroomsException(string msg, int numberOfBeds)
            : this(msg, numberOfBeds, null)
        {
        }

        public RoomBedroomsException(int numberOfBeds)
            : this(null, numberOfBeds)
        {
        }

        public override string Message
        {
            get
            {
                return "The guests are more than beds: " + this.numberOfBeds;
            }
        }
    }
}
