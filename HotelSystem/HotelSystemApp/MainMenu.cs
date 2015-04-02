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
                    break;
                case Menus.StaffMenu:
                    currentMenuChoises = staffMenuChoises;
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
                case "STAFF":
                    Menu(Menus.StaffMenu);
                    break;
                case "HIRE":
                    HireStaff();
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
            WriteColorString("List of all clients", 5, 0, ConsoleColor.Black, ConsoleColor.Yellow);
            int row = 1;
            foreach (var emp in LoadTestHotel.Hotel().Clients)
            {
                WriteColorString(string.Format("{0}.{1}", row, emp.ToString()), 5, row, ConsoleColor.Black, ConsoleColor.Yellow);
                row++;
            }

            Menu(Menus.ClientsMenu);
        }

        private static void ListOfStaff()
        {
            WriteColorString("List of all employees", 20, 4, ConsoleColor.Black, ConsoleColor.DarkCyan);

            int row = 7;

            int counter = 1;

            foreach (var emp in LoadTestHotel.Hotel().Employees)
            {
                WriteColorString(string.Format("{0}.{1}", counter, emp.ToString()), 19, row, ConsoleColor.Black, ConsoleColor.Yellow);
                row++;
                counter++;
            }

            Menu(Menus.StaffMenu);
        }
        public static void HireStaff()
        {
            WriteColorString(new string('▬', 50), 19, 3, ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteColorString(new string('▬', 50), 19, 20, ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteColorString("Hire new employees", 20, 4, ConsoleColor.Black, ConsoleColor.DarkCyan);

            WriteColorString("Choose employee type :", 20, 6, ConsoleColor.Black, ConsoleColor.DarkCyan);

            WriteColorString("(Bellboy, Maid, Manager, Receptionist)", 20, 7, ConsoleColor.Black, ConsoleColor.DarkCyan);

            Console.SetCursorPosition(20, 8);
            string employeeType = Console.ReadLine();

            switch (employeeType.ToLower())
            {
                case "bellboy":
                    WriteColorString(new string('▬', 50), 20, 8, ConsoleColor.Black, ConsoleColor.White);
                    WriteColorString("HIRE New Bellboy option choosed!", 20, 9, ConsoleColor.Black, ConsoleColor.White);
                    WriteColorString(new string('▬', 50), 20, 8, ConsoleColor.Black, ConsoleColor.White);
                    Employee newBellboy = ReadHireDetails("Bellboy");
                    WriteColorString("New employee HIRED successfully!", 20, 17, ConsoleColor.Black, ConsoleColor.White);
                    WriteColorString(newBellboy.ToString(), 20, 18, ConsoleColor.Black, ConsoleColor.Gray);
                    break;
                case "maid":
                    WriteColorString(new string('▬', 50), 20, 8, ConsoleColor.Black, ConsoleColor.White);
                    WriteColorString("HIRE new Maid option choosed!", 20, 9, ConsoleColor.Black, ConsoleColor.White);
                    WriteColorString(new string('▬', 50), 20, 8, ConsoleColor.Black, ConsoleColor.White);
                    Employee newMaid = ReadHireDetails("maid");
                    WriteColorString("New employee HIRED successfully!", 20, 17, ConsoleColor.Black, ConsoleColor.White);
                    WriteColorString(newMaid.ToString(), 20, 18, ConsoleColor.Black, ConsoleColor.Gray);
                    break;
                case "manager":
                    WriteColorString(new string('▬', 50), 20, 8, ConsoleColor.Black, ConsoleColor.White);
                    WriteColorString("HIRE new Manager option choosed!", 20, 9, ConsoleColor.Black, ConsoleColor.White);
                    WriteColorString(new string('▬', 50), 20, 8, ConsoleColor.Black, ConsoleColor.White);
                    Employee newManager = ReadHireDetails("manager");
                    WriteColorString("New employee HIRED successfully!", 20, 17, ConsoleColor.Black, ConsoleColor.White);
                    WriteColorString(newManager.ToString(), 20, 18, ConsoleColor.Black, ConsoleColor.Gray);
                    break;
                case "receptionist":
                    WriteColorString(new string('▬', 50), 20, 8, ConsoleColor.Black, ConsoleColor.White);
                    WriteColorString("HIRE new Receptionist option choosed!", 20, 9, ConsoleColor.Black, ConsoleColor.White);
                    WriteColorString(new string('▬', 50), 20, 8, ConsoleColor.Black, ConsoleColor.White);
                    Employee newReceptionis = ReadHireDetails("receptionist");
                    WriteColorString("New employee HIRED successfully!", 20, 17, ConsoleColor.Black, ConsoleColor.White);
                    WriteColorString(newReceptionis.ToString(), 20, 18, ConsoleColor.Black, ConsoleColor.Gray);
                    break;
            }

            Menu(Menus.StaffMenu);

        }

        private static Employee ReadHireDetails(string personal)
        {
            WriteColorString("Enter First and Last name : ", 20, 10, ConsoleColor.Black, ConsoleColor.Gray);
            string[] name = Console.ReadLine().Split(' ');
            WriteColorString("Enter registered address : ", 20, 11, ConsoleColor.Black, ConsoleColor.Gray);
            string address = Console.ReadLine();
            WriteColorString("Enter contact phone number : ", 20, 12, ConsoleColor.Black, ConsoleColor.Gray);
            string phone = Console.ReadLine();
            WriteColorString("Enter e-mail address : ", 20, 13, ConsoleColor.Black, ConsoleColor.Gray);
            string mail = Console.ReadLine();
            WriteColorString("Enter monthly salary : ", 20, 14, ConsoleColor.Black, ConsoleColor.Gray);
            decimal salary = decimal.Parse(Console.ReadLine());
            WriteColorString("Enter yearly vacantion days : ", 20, 15, ConsoleColor.Black, ConsoleColor.Gray);
            byte vacantion = byte.Parse(Console.ReadLine());
            WriteColorString("Enter average daily work hours : ", 20, 16, ConsoleColor.Black, ConsoleColor.Gray);
            byte workHours = byte.Parse(Console.ReadLine());

            if (personal == "bellboy")
            {
                return new BellBoy(name[0], name[1], address, phone, mail, salary, vacantion, workHours);
            }
            else if (personal == "maid")
            {
                return new Maid(name[0], name[1], address, phone, mail, salary, vacantion, workHours);
            }
            else if (personal == "manager")
            {
                return new Manager(name[0], name[1], address, phone, mail, salary, vacantion, workHours);
            }
            else if (personal == "receptionist")
            {
                return new Receptionist(name[0], name[1], address, phone, mail, salary, vacantion, workHours);
            }
            else
            {
                return null;
            }

        }
    }

    public enum Menus
    {
        MainMenu,
        ClientsMenu,
        StaffMenu
    }

}
