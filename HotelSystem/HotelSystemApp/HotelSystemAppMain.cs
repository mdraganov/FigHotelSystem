namespace HotelSystemApp
{
    using System;
    using HotelSystemApp.Enumerations;
    using HotelSystemApp.Person;
    using HotelSystemApp.Rooms;
    using HotelSystemApp.Services;

    public class HotelSystemAppMain
    {
        public static Hotel FirstTestHotel = new Hotel("Family Hotel - The Sweet Fig");

        public static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = 25;
            Console.BufferWidth = Console.WindowWidth = 140;
            Console.Title = "Hotel Application";

            #region TEST AREA
            FirstTestHotel.AddRoom(new OneBedroomRoom(11, 40));
            FirstTestHotel.AddRoom(new TwoBedroomRoom(12, 80));
            FirstTestHotel.AddRoom(new TwoBedroomRoom(13, 95));
            FirstTestHotel.AddRoom(new TwoBedroomRoom(14, 95));
            FirstTestHotel.AddRoom(new TwoBedroomRoom(21, 95));
            FirstTestHotel.AddRoom(new TwoBedroomRoom(22, 95));
            FirstTestHotel.AddRoom(new Apartment(23, 140, 2));

            var rooms = FirstTestHotel.Rooms;
            int count = 0;
            foreach (var rm in rooms)
            {
                if (count % 3 == 0)
                {
                    rm.AddFeature(Features.Jacuzzi);
                }

                if (count % 2 == 0)
                {
                    rm.AddFeature(Features.SnackBar);
                    rm.AddFeature(Features.Computer);
                }

                rm.AddFeature(Features.Bathtub);
                rm.AddFeature(Features.AC);
                count++;
            }

            Manager testManager = new Manager("Ivan", "Ivanov", "Varna", "0881234567", "test@gmail.com", 2000, 25, 12);
            Receptionist testReceptionist1 = new Receptionist("Galia", "Ivanova", "Varna", "0897654321", "rec1@gmail.com", 1200, 20, 12);
            Receptionist testReceptionist2 = new Receptionist("Mila", "Kostova", "Sofia", "0875432123", "rec2@gmail.com", 1000, 20, 12);
            Maid testMaid1 = new Maid("Ana", "Stefanova", "Plovdiv", "0896547338", "maid1@gmail.com", 500, 20, 8);
            Maid testMaid2 = new Maid("Monika", "Petrova", "Pleven", "0879632112", "maid2@gmail.com", 500, 20, 8);
            BellBoy testBellBoy = new BellBoy("Georgi", "Petrov", "Pleven", "0879632113", "bboy@gmail.com", 700, 18, 6);
            Client testClient1 = new Client("Vanq", "Nikolova", "Sofia", "0899543232", "client1@test.com", "AL90208110080000001039531801");
            Client testClient2 = new Client("Mitko", "Petrov", "Burgas", "0896432121", "client2@test.com", "BG80 BNBG 9661 1020 3456 78");

            FirstTestHotel.AddEmployee(testManager);
            FirstTestHotel.AddEmployee(testReceptionist1);
            FirstTestHotel.AddEmployee(testReceptionist2);
            FirstTestHotel.AddEmployee(testMaid1);
            FirstTestHotel.AddEmployee(testMaid2);
            FirstTestHotel.AddEmployee(testBellBoy);


            testBellBoy.ToggleSalaryTaken(); // turn ON/OFF the bool for taken salary (or not)
            testMaid2.ToggleSalaryTaken();
            testReceptionist1.ToggleSalaryTaken();

            FirstTestHotel.AddClient(testClient1);
            FirstTestHotel.AddClient(testClient2);

            FirstTestHotel.MakeReservation(testClient1, 13, new DateTime(2015, 05, 01), new DateTime(2015, 05, 07), 2);
            FirstTestHotel.MakeReservation(testClient2, 21, new DateTime(2015, 04, 10), new DateTime(2015, 04, 13), 2);
            FirstTestHotel.MakeReservation(testClient2, 12, new DateTime(2015, 04, 10), new DateTime(2015, 04, 13), 2);

            FirstTestHotel.AddService(new Spa(SpaProcedures.RomanBath, 1));
            FirstTestHotel.AddService(new Fitness());
            FirstTestHotel.AddService(new Parking());
            FirstTestHotel.AddService(new SwimmingPool());

            testClient1.AddVisitedService(new Parking());
            testClient2.AddVisitedService(new Fitness());
            #endregion

            #region Calling the menus
            MainMenu.Menu(Menus.MainMenu);
            #endregion
        }
    }
}
