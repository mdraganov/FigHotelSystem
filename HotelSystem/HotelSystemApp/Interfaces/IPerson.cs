namespace HotelSystemApp.Interfaces
{
    using System.Net.Mail;

    interface IPerson
    {
        string FirstName { get; }
        string LastName { get; }
        string Address { get; }
        string PhoneNumber { get; }
        MailAddress Email { get; }
    }
}
