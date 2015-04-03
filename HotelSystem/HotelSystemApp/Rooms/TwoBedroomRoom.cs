namespace HotelSystemApp.Rooms
{
    public class TwoBedroomRoom : Room
    {
        public TwoBedroomRoom(int numberOfRoom, decimal initialPrice)
            : base(numberOfRoom, initialPrice)
        {
            this.NumberOfBeds = 2;
        }

        public override int NumberOfBeds { get; protected set; }
    }
}
