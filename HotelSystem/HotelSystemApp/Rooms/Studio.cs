namespace HotelSystemApp.Rooms
{
    public class Studio : Room
    {
        public Studio(int numberOfRoom, decimal initialPrice)
            : base(numberOfRoom, initialPrice)
        {
            this.NumberOfBeds = 3;
        }

        public override int NumberOfBeds { get; protected set; }
    }
}
