namespace HotelSystemApp.Interfaces
{
    public interface IPrice
    {
        decimal Price { get; }

        decimal CalculatePrice();
    }
}
