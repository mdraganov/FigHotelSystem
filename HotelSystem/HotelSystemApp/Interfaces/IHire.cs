namespace HotelSystemApp.Interfaces
{
    using HotelSystemApp.Enumerations;
    using HotelSystemApp.Person;

    public interface IHire
    {
      void Hire(Person person, Employees type);
    }
}
