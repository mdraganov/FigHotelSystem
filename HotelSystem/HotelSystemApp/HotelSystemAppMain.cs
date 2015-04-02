namespace HotelSystemApp
{
    using System;

    public class HotelSystemAppMain
    {
        public static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = 25;
            Console.BufferWidth = Console.WindowWidth = 120;

            Console.Title = "Hotel Application";

            MainMenu.Menu(Menus.MainMenu);

        } 
    }
}
