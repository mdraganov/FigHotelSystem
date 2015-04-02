namespace HotelSystemApp
{
    using System;
    using System.Collections.Generic;
    using HotelSystemApp;
    using HotelSystemApp.Enumerations;
    using HotelSystemApp.Person;
    using HotelSystemApp.Rooms;
    using HotelSystemApp.Services;

    public class MainMenu
    {
        public static List<string> mainMenuChoises = new List<string> { "CHECK IN", "CHECK OUT", "CLIENTS", "STAFF", "Exit" };
        public static List<string> clientMenuChoises = new List<string> { "LIST ALL", "ADD NEW", "RETURN" };
        public static List<string> staffMenuChoises = new List<string> { "LIST ALL", "SALARIES", "HIRE", "TASKS", "RETURN" };
        public static List<string> currentMenuChoises;

        public static bool Menu(Menus currentMenu)
        {
            Console.TreatControlCAsInput = false;
            Console.CursorVisible = false;

            WriteColorString(new string('▬', 116), 2, 1, ConsoleColor.Black, ConsoleColor.Yellow);
            WriteColorString(new string('▬', 116), 2, 23, ConsoleColor.Black, ConsoleColor.Yellow);
            WriteColorString("{Team FIG} TelericAcademy 2015", 45, 2, ConsoleColor.Black, ConsoleColor.DarkGray);
            WriteColorString("use ↑ ↓ keys and press ENTER", 45, 22, ConsoleColor.Black, ConsoleColor.White);

            switch (currentMenu)
            {
                case Menus.MainMenu:
                    currentMenuChoises = mainMenuChoises;
                    break;
                case Menus.ClientsMenu:
                    currentMenuChoises = clientMenuChoises;
                    WriteColorString("Menu CLients", 4, 2, ConsoleColor.Black, ConsoleColor.Yellow);
                    break;
                case Menus.StaffMenu:
                    currentMenuChoises = staffMenuChoises;
                    WriteColorString("Menu Staff", 5, 2, ConsoleColor.Black, ConsoleColor.Yellow);
                    break;
                default:
                    break;
            }

            int choise = ChooseListBoxItem(currentMenuChoises, 2, 3, ConsoleColor.DarkCyan, ConsoleColor.Yellow);

            if (currentMenuChoises[choise - 1] != "Exit")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                SubMenu(currentMenuChoises[choise - 1]);
            }
            else
            {
                Environment.Exit(0);
            }

            return false;
        }

        public static int ChooseListBoxItem(List<string> items, int ucol, int urow, ConsoleColor back, ConsoleColor fore)
        {
            int numItems = items.Count;
            int maxLength = items[0].Length;
            for (int i = 1; i < numItems; i++)
            {
                if (items[i].Length > maxLength)
                {
                    maxLength = items[i].Length;
                }
            }

            int[] rightSpaces = new int[numItems];
            for (int i = 0; i < numItems; i++)
            {
                rightSpaces[i] = maxLength - items[i].Length + 1;
            }

            int lcol = ucol + 15;
            int lrow = urow + numItems + 1;

            DrawBox(ucol, urow, lcol, lrow, back, fore, true);

            WriteColorString(" " + items[0] + new string(' ', rightSpaces[0]), ucol + 1, urow + 1, fore, back);

            for (int i = 2; i <= numItems; i++)
            {
                WriteColorString(items[i - 1], ucol + 2, urow + i, back, fore);
            }

            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo();
            int choice = 1;

            while (true)
            {
                pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.Enter)
                {
                    return choice;
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    WriteColorString(" " + items[choice - 1] + new string(' ', rightSpaces[choice - 1]), ucol + 1, urow + choice, back, fore);
                    if (choice < numItems)
                    {
                        choice++;
                    }
                    else
                    {
                        choice = 1;
                    }

                    WriteColorString(" " + items[choice - 1] + new string(' ', rightSpaces[choice - 1]), ucol + 1, urow + choice, fore, back);
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    WriteColorString(" " + items[choice - 1] + new string(' ', rightSpaces[choice - 1]), ucol + 1, urow + choice, back, fore);
                    if (choice > 1)
                    {
                        choice--;
                    }
                    else
                    {
                        choice = numItems;
                    }

                    WriteColorString(" " + items[choice - 1] + new string(' ', rightSpaces[choice - 1]), ucol + 1, urow + choice, fore, back);
                }
            }
        }

        public static void DrawBox(int ucol, int urow, int lcol, int lrow, ConsoleColor back, ConsoleColor fore, bool fill)
        {
            const char Horizontal = '\u2500';
            const char Vertical = '\u2502';
            const char UpperLeftCorner = '\u250c';
            const char UpperRightCorner = '\u2510';
            const char LowerLeftCorner = '\u2514';
            const char LowerRightCorner = '\u2518';
            string fillLine = fill ? new string(' ', lcol - ucol - 1) : "";

            SetColors(back, fore);
            // draw top edge 
            Console.SetCursorPosition(ucol, urow);
            Console.Write(UpperLeftCorner);
            for (int i = ucol + 1; i < lcol; i++)
            {
                Console.Write(Horizontal);
            }

            Console.Write(UpperRightCorner);
            // draw sides 
            for (int i = urow + 1; i < 21; i++)
            {
                Console.SetCursorPosition(ucol, i);
                Console.Write(Vertical);
                if (fill) Console.Write(fillLine);
                Console.SetCursorPosition(lcol, i);
                Console.Write(Vertical);
            }

            // draw bottom edge 
            Console.SetCursorPosition(ucol, 21);
            Console.Write(LowerLeftCorner);
            for (int i = ucol + 1; i < lcol; i++)
            {
                Console.Write(Horizontal);
            }

            Console.Write(LowerRightCorner);
        }

        public static void WriteColorString(string s, int col, int row, ConsoleColor back, ConsoleColor fore)
        {
            SetColors(back, fore);
            // write string 
            Console.SetCursorPosition(col, row);
            Console.Write(s);
        }

        public static void SetColors(ConsoleColor back, ConsoleColor fore)
        {
            Console.BackgroundColor = back;
            Console.ForegroundColor = fore;
        }

        public static void CleanUp()
        {
            Console.ResetColor();
            Console.CursorVisible = true;
            Console.Clear();
        }

        static void PrintOnPosition(int x, int y, string c)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(c);
        }

        static void SubMenu(string currentMenu)
        {
            Console.Clear();

            switch (currentMenu)
            {
                case "CHECK IN":
                    WriteColorString("check in test", 30, 3, ConsoleColor.Black, ConsoleColor.Yellow);
                    break;
                case "CHECK OUT":
                    WriteColorString("check out test", 30, 3, ConsoleColor.Black, ConsoleColor.Yellow);
                    break;
                case "CLIENTS":
                    Menu(Menus.ClientsMenu);
                    break;
                case "LIST ALL":
                    if (currentMenuChoises == clientMenuChoises)
                    {
                        ListOfClients();
                    }
                    else
                    {
                        ListOfStaff();
                    }
                    break;
                case "ADD NEW":
                    AddNewClient();
                    break;
                case "STAFF":
                    Menu(Menus.StaffMenu);
                    break;
                case "RETURN":
                    Menu(Menus.MainMenu);
                    break;
                default:
                    break;
            }

            WriteColorString("press ESC to return", 40, 22, ConsoleColor.Black, ConsoleColor.White);
            while (true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.Escape)
                {
                    Menu(Menus.MainMenu);
                }
            }
        }

        private static void ListOfClients()
        {
            WriteColorString("List of all clients", 20, 3, ConsoleColor.Black, ConsoleColor.Yellow);
            int row = 4;
            int counter = 1;

            foreach (var emp in LoadTestHotel.Hotel().Clients)
            {
                WriteColorString(string.Format("{0}.{1}", counter, emp.ToString()), 20, row, ConsoleColor.Black, ConsoleColor.Yellow);
                row++;
                counter++;
            }

            Menu(Menus.ClientsMenu);
        }

        private static void AddNewClient()
        {
            // Client newClient = new Client();
            //LoadTestHotel.Hotel().AddClient(newClient);
            WriteColorString("First name: ", 30, 5, ConsoleColor.Black, ConsoleColor.White);
            string firstName = Console.ReadLine();
            WriteColorString("Last name: ", 30, 6, ConsoleColor.Black, ConsoleColor.White);
            string lastName = Console.ReadLine();
            Console.ReadLine();
            Menu(Menus.ClientsMenu);
        }

        private static void ListOfStaff()
        {
            WriteColorString("List of all employees", 5, 11, ConsoleColor.Black, ConsoleColor.Yellow);
            int row = 1;
            foreach (var emp in LoadTestHotel.Hotel().Employees)
            {
                WriteColorString(string.Format("{0}.{1}", row, emp.ToString()), 5, row, ConsoleColor.Black, ConsoleColor.Yellow);
                row++;
            }

            Menu(Menus.StaffMenu);
        }

    }

    public enum Menus
    {
        MainMenu,
        ClientsMenu,
        StaffMenu
    }

}
