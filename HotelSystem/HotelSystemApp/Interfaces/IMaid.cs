namespace HotelSystemApp.Interfaces
{
    public interface IMaid
    {
        bool CleanRoom { get; set; }

        void ToogleCleanRoom();
    }
}
