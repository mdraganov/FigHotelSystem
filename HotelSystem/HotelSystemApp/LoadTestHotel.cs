namespace HotelSystemApp
{
    using System.Collections.Generic;
    using HotelSystemApp.Enumerations;
    using HotelSystemApp.Person;
    using HotelSystemApp.Rooms;
    using HotelSystemApp.Structures;
    using HotelSystemApp.Services;

    public class LoadTestHotel
    {
        public Hotel Start()
        {
            Hotel hotelFig = new Hotel("Family Hotel - The Sweet Fig");

            hotelFig.AddRoom(new OneBedroomRoom(11, 40, new List<Features> { Features.None }));
            hotelFig.AddRoom(new TwoBedroomRoom(12, 80, new List<Features> { Features.None }));
            hotelFig.AddRoom(new TwoBedroomRoom(13, 95, new List<Features> { Features.AC, Features.Bathtub }));
            hotelFig.AddRoom(new TwoBedroomRoom(14, 95, new List<Features> { Features.AC }));
            hotelFig.AddRoom(new TwoBedroomRoom(21, 95, new List<Features> { Features.AC }));
            hotelFig.AddRoom(new TwoBedroomRoom(22, 95, new List<Features> { Features.None }));
            hotelFig.AddRoom(new Apartment(23, 140, new List<Features> { Features.AC, Features.Bathtub }, 2));

            Manager testManager = new Manager("Ivan", "Ivanov", "Varna", "0881234567", "test@gmail.com", 2000, 25, 12);
            Receptionist testReceptionist1 = new Receptionist("Galia", "Ivanova", "Varna", "0897654321", "rec1@gmail.com", 1200, 20, 12);
            Receptionist testReceptionist2 = new Receptionist("Mila", "Kostova", "Sofia", "0875432123", "rec2@gmail.com", 1000, 20, 12);
            Maid testMaid1 = new Maid("Ana", "Stefanova", "Plovdiv", "0896547338", "maid1@gmail.com", 500, 20, 8);
            Maid testMaid2 = new Maid("Monika", "Petrova", "Pleven", "0879632112", "maid2@gmail.com", 500, 20, 8);
            BellBoy testBellBoy = new BellBoy("Georgi", "Petrov", "Pleven", "0879632113", "bboy@gmail.com", 700, 18, 6);
            Client testClient1 = new Client("Vanq", "Nikolova", "Sofia", "0899543232", "test@test.com", "bg123456765489");

            hotelFig.AddEmployee(testManager);
            hotelFig.AddEmployee(testReceptionist1);
            hotelFig.AddEmployee(testReceptionist2);
            hotelFig.AddEmployee(testMaid1);
            hotelFig.AddEmployee(testMaid2);
            hotelFig.AddEmployee(testBellBoy);
            hotelFig.AddClient(testClient1);

            hotelFig.MakeReservation(testClient1.ID, 13); 

            hotelFig.AddService(new SPA(30));
            hotelFig.AddService(new Fitness());
            hotelFig.AddService(new Parking());
            hotelFig.AddService(new SwimmingPool());

            testClient1.AddVisitedService(new Parking());

            return hotelFig;
        }
    }
}
