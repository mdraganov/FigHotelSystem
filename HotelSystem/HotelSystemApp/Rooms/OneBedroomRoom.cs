namespace HotelSystemApp.Rooms
{
    public class OneBedroomRoom : Room
    {
        public OneBedroomRoom(int numberOfRoom, decimal initialPrice)
            : base(numberOfRoom, initialPrice)
        {
            this.NumberOfBeds = 1;
        }

        public override int NumberOfBeds { get; protected set; }
    }
}
