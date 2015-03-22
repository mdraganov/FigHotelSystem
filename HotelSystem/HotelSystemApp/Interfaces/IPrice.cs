namespace HotelSystemApp.Interfaces
{
    public interface IPrice
    {
        decimal Price { get; set; }
        void CalculatePrice();
    }
}
