namespace HotelSystemApp
{
    using System.Collections.Generic;
    using HotelSystemApp.Enumerations;
    using HotelSystemApp.Person;
    using HotelSystemApp.Rooms;
    using HotelSystemApp.Services;

    public class LoadTestHotel
    {
        public static Hotel Hotel()
        {
            Hotel firstTestHotel = new Hotel("Family Hotel - The Sweet Fig");

            firstTestHotel.AddRoom(new OneBedroomRoom(11, 40, new List<Features> { Features.None }));
            firstTestHotel.AddRoom(new TwoBedroomRoom(12, 80, new List<Features> { Features.None }));
            firstTestHotel.AddRoom(new TwoBedroomRoom(13, 95, new List<Features> { Features.AC, Features.Bathtub }));
            firstTestHotel.AddRoom(new TwoBedroomRoom(14, 95, new List<Features> { Features.AC }));
            firstTestHotel.AddRoom(new TwoBedroomRoom(21, 95, new List<Features> { Features.AC }));
            firstTestHotel.AddRoom(new TwoBedroomRoom(22, 95, new List<Features> { Features.None }));
            firstTestHotel.AddRoom(new Apartment(23, 140, new List<Features> { Features.AC, Features.Bathtub }, 2));

            Manager testManager = new Manager("Ivan", "Ivanov", "Varna", "0881234567", "test@gmail.com", 2000, 25, 12);
            Receptionist testReceptionist1 = new Receptionist("Galia", "Ivanova", "Varna", "0897654321", "rec1@gmail.com", 1200, 20, 12);
            Receptionist testReceptionist2 = new Receptionist("Mila", "Kostova", "Sofia", "0875432123", "rec2@gmail.com", 1000, 20, 12);
            Maid testMaid1 = new Maid("Ana", "Stefanova", "Plovdiv", "0896547338", "maid1@gmail.com", 500, 20, 8);
            Maid testMaid2 = new Maid("Monika", "Petrova", "Pleven", "0879632112", "maid2@gmail.com", 500, 20, 8);
            BellBoy testBellBoy = new BellBoy("Georgi", "Petrov", "Pleven", "0879632113", "bboy@gmail.com", 700, 18, 6);
            Client testClient1 = new Client("Vanq", "Nikolova", "Sofia", "0899543232", "client1@test.com", "AL90208110080000001039531801");
            Client testClient2 = new Client("Mitko", "Nikolov", "Burgas", "0896432121", "client2@test.com", "BG80 BNBG 9661 1020 3456 78");

            firstTestHotel.AddEmployee(testManager);
            firstTestHotel.AddEmployee(testReceptionist1);
            firstTestHotel.AddEmployee(testReceptionist2);
            firstTestHotel.AddEmployee(testMaid1);
            firstTestHotel.AddEmployee(testMaid2);
            firstTestHotel.AddEmployee(testBellBoy);
            firstTestHotel.AddClient(testClient1);
            firstTestHotel.AddClient(testClient2);

            //firstTestHotel.MakeReservation(testClient1, 13); 

            firstTestHotel.AddService(new Spa(SpaProcedures.RomanBath, 1));
            firstTestHotel.AddService(new Fitness());
            firstTestHotel.AddService(new Parking());
            firstTestHotel.AddService(new SwimmingPool());

            testClient1.AddVisitedService(new Parking());
            testClient2.AddVisitedService(new Fitness());

            return firstTestHotel;
        }
    }
}
