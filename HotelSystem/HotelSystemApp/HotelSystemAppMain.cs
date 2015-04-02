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

            MainMenu.Menu();

            #region Methods
            //    StartupScreen();

            //}

            //public static void StartupScreen()
            //{
            //    char[,] bordersArray = new char[Console.BufferHeight, Console.BufferWidth];

            //    for (int col = 0; col < bordersArray.GetLength(1); col++)
            //    {
            //        Console.ForegroundColor = ConsoleColor.DarkCyan;
            //        bordersArray[Console.BufferHeight - 1, col] = border;
            //        bordersArray[1, col] = border;
            //    }

            //    for (int row = 0; row < bordersArray.GetLength(0); row++)
            //    {
            //        Console.ForegroundColor = ConsoleColor.DarkCyan;
            //        bordersArray[row, 0] = border;
            //        bordersArray[row, Console.BufferWidth - 1] = border;
            //    }


            //    PrintBorders(bordersArray);

            //    Console.BackgroundColor = ConsoleColor.DarkYellow;
            //    Console.ForegroundColor = ConsoleColor.White;
            //    PrintHeader();
            //    SetPosition(0, 6);
            //    Line(border, 59);
            //    PrintMenu();
            //    Line(border, 59);
            //    Console.ResetColor();


            //}

            //public static void PrintMenu()
            //{
            //    char[,] bordersArray = new char[Console.BufferHeight, Console.BufferWidth];

            //    for (int col = 0; col < bordersArray.GetLength(1); col++)
            //    {
            //        Console.ForegroundColor = ConsoleColor.White;
            //        bordersArray[Console.BufferHeight - 1, col] = border;
            //        bordersArray[1, col] = border;
            //    }

            //    for (int row = 0; row < bordersArray.GetLength(0); row++)
            //    {
            //        Console.ForegroundColor = ConsoleColor.White;
            //        bordersArray[row, 0] = border;
            //        bordersArray[row, Console.BufferWidth - 1] = border;
            //    }

            //    SetPosition(0, 6);
            //    Console.BackgroundColor = ConsoleColor.DarkYellow;
            //    Line(border, 59);
            //    Console.WriteLine("# Accomodation # Checkout # Staff # Administration # Help #");
            //    Line(border, 59);
            //    Console.ResetColor();

            //    int pressedKeyValue = 0;

            //    var someKey = Console.ReadKey(true).Key;

            //    if (pressedKeyValue == 0 && someKey == ConsoleKey.Enter) //The ">>" is initially set at New Game, 
            //    {                                                        //hence if {ENTER} is pressed game will start.
            //        Console.Beep();
            //        return;
            //    }
            //    else
            //    {
            //        bool check = pressedKeyValue != 0 || pressedKeyValue != 1;

            //        while (check)
            //        {
            //            var key = Console.ReadKey(true).Key;

            //            if (key == ConsoleKey.LeftArrow)
            //            {
            //                pressedKeyValue -= 1;

            //            }
            //            else if (key == ConsoleKey.RightArrow)
            //            {
            //                pressedKeyValue += 1;
            //            }

            //            switch (pressedKeyValue)
            //            {
            //                case 0: //Case 0 moves ">>" to "Accomodation"

            //                    PrintBorders(bordersArray);
            //                    PrintHeader();
            //                    SetPosition(0, 6);
            //                    Console.BackgroundColor = ConsoleColor.DarkYellow;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Line(border, 59);
            //                    Console.BackgroundColor = ConsoleColor.DarkRed;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Console.Write("> ACCOMODATION <");
            //                    Console.BackgroundColor = ConsoleColor.DarkYellow;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Console.WriteLine(" Checkout # Staff # Administration # Help #");
            //                    Line(border, 59);
            //                    Console.ResetColor();
            //                    break;

            //                case 1: //Case 1 moves ">>" to "Checkout"

            //                    PrintBorders(bordersArray);
            //                    PrintHeader();
            //                    SetPosition(0, 6);
            //                    Console.BackgroundColor = ConsoleColor.DarkYellow;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Line(border, 59);
            //                    Console.Write("# Accomodation ");
            //                    Console.BackgroundColor = ConsoleColor.DarkRed;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Console.Write("> CHECKOUT <");
            //                    Console.BackgroundColor = ConsoleColor.DarkYellow;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Console.WriteLine(" Staff # Administration # Help #");
            //                    Line(border, 59);
            //                    Console.ResetColor();
            //                    break;

            //                case 2: //Case 2 moves ">>" to "Staff"

            //                    PrintBorders(bordersArray);
            //                    PrintHeader();
            //                    SetPosition(0, 6);
            //                    Console.BackgroundColor = ConsoleColor.DarkYellow;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Line(border, 59);
            //                    Console.Write("# Accomodation # Checkout ");
            //                    Console.BackgroundColor = ConsoleColor.DarkRed;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Console.Write("> STAFF <");
            //                    Console.BackgroundColor = ConsoleColor.DarkYellow;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Console.WriteLine(" Administration # Help #");
            //                    Line(border, 59);
            //                    Console.ResetColor();
            //                    break;

            //                case 3: //Case 2 moves ">>" to "Administration"

            //                    PrintBorders(bordersArray);
            //                    PrintHeader();
            //                    SetPosition(0, 6);
            //                    Console.BackgroundColor = ConsoleColor.DarkYellow;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Line(border, 59);
            //                    Console.Write("# Accomodation # Checkout # Staff ");
            //                    Console.BackgroundColor = ConsoleColor.DarkRed;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Console.Write("> Administration <");
            //                    Console.BackgroundColor = ConsoleColor.DarkYellow;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Console.WriteLine(" Help #");
            //                    Line(border, 59);
            //                    Console.ResetColor();
            //                    break;

            //                case 4: //Case 2 moves ">>" to "Administration"

            //                    PrintBorders(bordersArray);
            //                    PrintHeader();
            //                    SetPosition(0, 6);
            //                    Console.BackgroundColor = ConsoleColor.DarkYellow;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Line(border, 59);
            //                    Console.Write("# Accomodation # Checkout # Staff # Administration ");
            //                    Console.BackgroundColor = ConsoleColor.DarkRed;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Console.WriteLine("> HELP <");
            //                    Console.BackgroundColor = ConsoleColor.DarkYellow;
            //                    Console.ForegroundColor = ConsoleColor.White;
            //                    Line(border, 59);
            //                    Console.ResetColor();
            //                    break;

            //            }

            //            if (pressedKeyValue == 0 && key == ConsoleKey.Enter) //">" will be at "[select]" and afterpresing {Enter} Instructions submenu will appear.
            //            {
            //                Console.Beep(); // add real action here (ACCOMODATION)
            //                break;
            //            }

            //            if (pressedKeyValue == 1 && key == ConsoleKey.Enter) //">" will be at "[select]" and afterpresing {Enter} Instructions submenu will appear.
            //            {
            //                Console.Beep();     // add real action here (CHECKOUT)
            //                Console.Clear();    // for test - remove this after aaction is added
            //                PrintBorders(bordersArray);

            //                if (key == ConsoleKey.Escape) //Goes back to main start menu
            //                {
            //                    pressedKeyValue = 0;
            //                }
            //            }
            //            if (pressedKeyValue == 2 && key == ConsoleKey.Enter) //">" will be at "[select]" and afterpresing {Enter} Instructions submenu will appear.
            //            {
            //                Console.Beep();     // add real action here (CHECKOUT)
            //                Console.Clear();    // for test - remove this after aaction is added
            //                PrintBorders(bordersArray);

            //                if (key == ConsoleKey.Escape) //Goes back to main start menu
            //                {
            //                    pressedKeyValue = 0;
            //                }
            //            }
            //            if (pressedKeyValue == 3 && key == ConsoleKey.Enter) //">" will be at "[select]" and afterpresing {Enter} Instructions submenu will appear.
            //            {
            //                Console.Beep();     // add real action here (CHECKOUT)
            //                Console.Clear();    // for test - remove this after aaction is added
            //                PrintBorders(bordersArray);

            //                if (key == ConsoleKey.Escape) //Goes back to main start menu
            //                {
            //                    pressedKeyValue = 0;
            //                }
            //            }
            //            if (pressedKeyValue == 4 && key == ConsoleKey.Enter) //">" will be at "[select]" and afterpresing {Enter} Instructions submenu will appear.
            //            {
            //                Console.Beep();     // add real action here (CHECKOUT)
            //                Console.Clear();    // for test - remove this after aaction is added
            //                PrintBorders(bordersArray);

            //                if (key == ConsoleKey.Escape) //Goes back to main start menu
            //                {
            //                    pressedKeyValue = 0;
            //                }
            //            }
            //        }
            //    }
            //}

            //public static void PrintHeader()
            //{
            //    SetPosition(0, 1);
            //    Console.BackgroundColor = ConsoleColor.DarkYellow;
            //    Line(border, 59);
            //    Console.WriteLine("                                                           ");
            //    Console.WriteLine("              HOTEL FIG Administration Panel               ");
            //    Console.WriteLine("                                                           ");
            //    Line(border, 59);
            //    Console.ResetColor();
            //}

            //public static void PrintBorders(char[,] bordersArray)
            //{
            //    Console.ForegroundColor = ConsoleColor.White;
            //    for (int row = 0; row < bordersArray.GetLength(0); row++)
            //    {
            //        for (int col = 0; col < bordersArray.GetLength(1); col++)
            //        {
            //            Console.Write(bordersArray[row, col]);
            //        }
            //    }
            //}

            //public static void Line(char symbol, int lenght)
            //{
            //    Console.WriteLine(new string(symbol, lenght));
            //}

            //public static void SetPosition(int x, int y)
            //{
            //    Console.SetCursorPosition(x, y);
        }
            #endregion
    }
}
