namespace HotelSystemApp.Interfaces
{
    using HotelSystemApp.Person;
    using HotelSystemApp.Enumerations;

    public interface IHire
    {
      void Hire(Person person, Employees type);
    }
}
