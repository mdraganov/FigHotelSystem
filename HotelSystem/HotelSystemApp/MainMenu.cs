namespace HotelSystemApp
{
    using System;
    using HotelSystemApp;
    using HotelSystemApp.Enumerations;
    using HotelSystemApp.Person;
    using HotelSystemApp.Rooms;
    using HotelSystemApp.Services;

    public class MainMenu
    {
        public static bool Menu()
        {
            Console.TreatControlCAsInput = false;
            Console.Clear();
            Console.CursorVisible = false;

            WriteColorString(new string('▬', 110), 5, 1, ConsoleColor.Black, ConsoleColor.Yellow);
            WriteColorString(new string('▬', 110), 5, 23, ConsoleColor.Black, ConsoleColor.Yellow);
            WriteColorString("{Team FIG} TelericAcademy 2015", 45, 2, ConsoleColor.Black, ConsoleColor.DarkGray);
            string[] menuchoice = { "CHECK IN", "CHECK OUT", "CLIENTS", "STAFF", "Exit" };
            WriteColorString("use ↑ ↓ keys and press ENTER", 45, 22, ConsoleColor.Black, ConsoleColor.White);

            int choice = ChooseListBoxItem(menuchoice, 52, 5, ConsoleColor.DarkCyan, ConsoleColor.Yellow);

            if (menuchoice[choice - 1] != "Exit")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                return SubMenu(menuchoice[choice - 1]);
            }
            else
            {
                Environment.Exit(0);
            }

            return false;
        }

        public static int ChooseListBoxItem(string[] items, int ucol, int urow, ConsoleColor back, ConsoleColor fore)
        {
            int numItems = items.Length;
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

            int lcol = ucol + maxLength + 3;
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
            for (int i = urow + 1; i < lrow; i++)
            {
                Console.SetCursorPosition(ucol, i);
                Console.Write(Vertical);
                if (fill) Console.Write(fillLine);
                Console.SetCursorPosition(lcol, i);
                Console.Write(Vertical);
            }

            // draw bottom edge 
            Console.SetCursorPosition(ucol, lrow);
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

        static bool SubMenu(string currentMenu )
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
                    MenuCLient();
                    break;
                case "STAFF":
                    PrintEmployees();
                    break;
                case "LIST STAFF":
                    WriteColorString("list of all employees", 30, 3, ConsoleColor.Black, ConsoleColor.Yellow);
                    ListStaff();
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
                    return Menu();
                }
            }
        }

        private static void MenuCLient()
        {
            WriteColorString("List of all clients", 1, 0, ConsoleColor.Black, ConsoleColor.Yellow);
            int row = 1;
            foreach (var emp in LoadTestHotel.Hotel().Clients)
            {
                WriteColorString(string.Format("{0}.{1}", row, emp.ToString()), 1, row, ConsoleColor.Black, ConsoleColor.Yellow);
                row++;
            }
        }

        private static void PrintEmployees()
        {
            Console.TreatControlCAsInput = false;
            Console.Clear();
            Console.CursorVisible = false;

            WriteColorString(new string('▬', 90), 5, 1, ConsoleColor.Black, ConsoleColor.Yellow);
            WriteColorString(new string('▬', 90), 5, 20, ConsoleColor.Black, ConsoleColor.Yellow);
            WriteColorString("{Team FIG} TelericAcademy 2015", 30, 2, ConsoleColor.Black, ConsoleColor.DarkGray);
            string[] menuchoice = { "LIST STAFF", "SALARIES", "HIRE", "TASKS", "Exit" };
            WriteColorString("use ↑ ↓ keys and press ENTER", 31, 18, ConsoleColor.Black, ConsoleColor.White);
            int choice = ChooseListBoxItem(menuchoice, 2, 5,  ConsoleColor.DarkCyan, ConsoleColor.Yellow);
            if (menuchoice[choice - 1] != "Exit")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                SubMenu(menuchoice[choice - 1]);
            }
            else
            {
                Environment.Exit(0);
            }

        }

        private static void ListStaff()
        {

            int row = 4;
            WriteColorString(new string('▬', 90), 5, 1, ConsoleColor.Black, ConsoleColor.Yellow);
            foreach (var emp in LoadTestHotel.Hotel().Employees)
            {
                WriteColorString(emp.ToString(), 18, row, ConsoleColor.Black, ConsoleColor.Yellow);
                row++;
            }
            WriteColorString(new string('▬', 90), 5, 20, ConsoleColor.Black, ConsoleColor.Yellow);
            WriteColorString(new string('▬', 90), 5, 1, ConsoleColor.Black, ConsoleColor.Yellow);

            WriteColorString("{Team FIG} TelericAcademy 2015", 30, 2, ConsoleColor.Black, ConsoleColor.DarkGray);
            string[] menuchoice = { "LIST STAFF", "SALARIES", "HIRE", "TASKS", "Exit" };
            WriteColorString("use ↑ ↓ keys and press ENTER", 31, 18, ConsoleColor.Black, ConsoleColor.White);
            int choice = ChooseListBoxItem(menuchoice, 2, 5, ConsoleColor.DarkCyan, ConsoleColor.Yellow);
            if (menuchoice[choice - 1] != "Exit")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                SubMenu(menuchoice[choice - 1]);
            }
            else
            {
                Environment.Exit(0);
            }
        }

    }
}
