namespace HotelSystemApp
{
    using System;
    using System.Collections.Generic;
    using HotelSystemApp;
    using HotelSystemApp.Enumerations;
    using HotelSystemApp.Person;
    using HotelSystemApp.Rooms;
    using HotelSystemApp.Services;

    public class HotelSystemAppMain
    {
        public static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = 25;
            Console.BufferWidth = Console.WindowWidth = 140;

            Console.Title = "Hotel Application";

            MainMenu.Menu(Menus.MainMenu);

        } 
    }
}
