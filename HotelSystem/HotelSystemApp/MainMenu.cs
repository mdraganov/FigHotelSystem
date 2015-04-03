﻿namespace HotelSystemApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HotelSystemApp.Person;

    public enum Menus
    {
        MainMenu,
        ClientsMenu,
        StaffMenu,
        Reservations
    }

    public class MainMenu
    {
        public static Hotel NewHotel = HotelSystemAppMain.FirstTestHotel;
        public static List<string> MainMenuChoises = new List<string> { "RESERVATIONS", "ROOMS INFO", "CLIENTS", "SERVICES", "STAFF", "Exit" }; 
        public static List<string> ClientMenuChoises = new List<string> { "LIST ALL", "ADD NEW", "RETURN" };
        public static List<string> StaffMenuChoises = new List<string> { "LIST ALL", "SALARIES", "HIRE", "TASKS", "RETURN" };
        public static List<string> ReservationsMenuChoises = new List<string> { "LIST ALL", "CHECK IN", "CHECK OUT", "RETURN" };
        public static List<string> CurrentMenuChoises;

        #region MainMenu
        public static bool Menu(Menus currentMenu)
        {
            Console.TreatControlCAsInput = false;
            Console.CursorVisible = false;

            WriteColorString(new string('▬', 136), 2, 1, ConsoleColor.Black, ConsoleColor.Yellow);
            WriteColorString(new string('▬', 136), 2, 23, ConsoleColor.Black, ConsoleColor.Yellow);
            WriteColorString("{Team FIG} TelericAcademy 2015", 55, 2, ConsoleColor.Black, ConsoleColor.DarkGray);
            WriteColorString("use ↑ ↓ keys and press ENTER", 55, 22, ConsoleColor.Black, ConsoleColor.White);

            switch (currentMenu)
            {
                case Menus.MainMenu:
                    CurrentMenuChoises = MainMenuChoises;
                    break;
                case Menus.ClientsMenu:
                    CurrentMenuChoises = ClientMenuChoises;
                    WriteColorString("CLients Menu", 4, 2, ConsoleColor.Black, ConsoleColor.Yellow);
                    break;
                case Menus.StaffMenu:
                    CurrentMenuChoises = StaffMenuChoises;
                    WriteColorString("Staff Menu", 5, 2, ConsoleColor.Black, ConsoleColor.Yellow);
                    break;
                case Menus.Reservations:
                    CurrentMenuChoises = ReservationsMenuChoises;
                    WriteColorString("Reservation Menu", 2, 2, ConsoleColor.Black, ConsoleColor.Yellow);
                    break;
                default:
                    break;
            }

            int choise = ChooseListBoxItem(CurrentMenuChoises, 2, 3, ConsoleColor.DarkCyan, ConsoleColor.Yellow);

            if (CurrentMenuChoises[choise - 1] != "Exit")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                SubMenu(CurrentMenuChoises[choise - 1]);
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
                if (fill)
                {
                    Console.Write(fillLine);
                }

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

        private static void PrintOnPosition(int x, int y, string c)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(c);
        }

        #endregion

        private static void SubMenu(string currentMenu)
        {
            Console.Clear();

            switch (currentMenu)
            {
                case "RESERVATIONS":
                    Menu(Menus.Reservations);
                    break;
                case "ROOMS INFO":
                    WriteColorString("Information about all hotel rooms", 30, 3, ConsoleColor.Black, ConsoleColor.Yellow);
                    ListRooms();
                    break;
                case "CLIENTS":
                    Menu(Menus.ClientsMenu);
                    break;
                case "STAFF":
                    Menu(Menus.StaffMenu);
                    break;
                case "SERVICES": // Service
                    ServicesPriceInfo();
                    break;
                case "LIST ALL":
                    if (CurrentMenuChoises == ClientMenuChoises)
                    {
                        ListOfClients();
                    }
                    else if (CurrentMenuChoises == StaffMenuChoises)
                    {
                        ListOfStaff();
                    }
                    else
                    {
                        ListOfReservations();
                    }
                    break;
                case "ADD NEW":
                    AddNewClient();
                    break;
                case "HIRE":
                    HireStaff();
                    break;
                case "SALARIES":
                    SalariesStaff();
                    break;
                case "CHECK IN":
                    WriteColorString("check in test", 30, 3, ConsoleColor.Black, ConsoleColor.Yellow);
                    break;
                case "CHECK OUT":
                    WriteColorString("check out test", 30, 3, ConsoleColor.Black, ConsoleColor.Yellow);
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
            WriteColorString("List of all clients", 20, 4, ConsoleColor.Black, ConsoleColor.DarkCyan);

            int row = 7;
            int counter = 1;
            var orderedListOfClients = NewHotel.Clients.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            foreach (var client in orderedListOfClients)
            {
                WriteColorString(string.Format("{0}.{1}", counter, client.ToString()), 19, row, ConsoleColor.Black, ConsoleColor.Yellow);
                row++;
                counter++;
            }

            Menu(Menus.ClientsMenu);
        }

        private static void ListOfStaff()
        {
            WriteColorString("List of all employees", 20, 4, ConsoleColor.Black, ConsoleColor.DarkCyan);

            int row = 7;
            int counter = 1;
            var ordered = NewHotel.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.Salary);
            foreach (var emp in ordered)
            {
                WriteColorString(string.Format("{0}.{1}", counter, emp.ToString()), 19, row, ConsoleColor.Black, ConsoleColor.Yellow);
                row++;
                counter++;
            }

            Menu(Menus.StaffMenu);
        }

        private static void ListOfReservations()
        {
            WriteColorString("List of all reservations", 20, 4, ConsoleColor.Black, ConsoleColor.DarkCyan);

            int row = 7;
            int counter = 1;
            var ordered = NewHotel.Reservations.OrderBy(x => x.NumberOfRoom);
            foreach (var res in ordered)
            {
                WriteColorString(string.Format("{0}.{1}", counter, res.ToString()), 19, row, ConsoleColor.Black, ConsoleColor.Yellow);
                row++;
                counter++;
            }

            Menu(Menus.Reservations);
        }

        private static void SalariesStaff()
        {
            WriteColorString("Salaries of employees", 20, 4, ConsoleColor.Black, ConsoleColor.DarkCyan);

            int row = 7;
            int counter = 1;
            var ordered = NewHotel.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.Salary);
            foreach (var emp in ordered)
            {
                WriteColorString(string.Format("Name: {0,15}    Salary: {1,5}     Salary Taken : {2}", emp.FirstName + " " + emp.LastName, emp.Salary, emp.SalaryTaken ? "No" : "Yes"), 19, row, ConsoleColor.Black, ConsoleColor.Yellow);
                row++;
                counter++;
            }

            Menu(Menus.StaffMenu);
        }

        private static void AddNewClient()
        {
            WriteColorString(new string('▬', 50), 19, 3, ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteColorString(new string('▬', 50), 19, 21, ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteColorString("Add new client", 20, 4, ConsoleColor.Black, ConsoleColor.DarkCyan);

            WriteColorString("Enter First and Last name : ", 20, 6, ConsoleColor.Black, ConsoleColor.Gray);
            string[] name = Console.ReadLine().Split(' ');
            WriteColorString("Enter registered address : ", 20, 7, ConsoleColor.Black, ConsoleColor.Gray);
            string address = Console.ReadLine();
            WriteColorString("Enter contact phone number : ", 20, 8, ConsoleColor.Black, ConsoleColor.Gray);
            string phone = Console.ReadLine();
            WriteColorString("Enter e-mail address : ", 20, 9, ConsoleColor.Black, ConsoleColor.Gray);
            string mail = Console.ReadLine();
            WriteColorString("Enter IBAN : ", 20, 10, ConsoleColor.Black, ConsoleColor.Gray);
            string iban = Console.ReadLine();

            NewHotel.AddClient(new Client(name[0], name[1], address, phone, mail, iban));
            WriteColorString("New client added successfully!", 20, 17, ConsoleColor.Black, ConsoleColor.White);
            Menu(Menus.ClientsMenu);
        }

        private static void HireStaff()
        {
            try
            {
                WriteColorString(new string('▬', 50), 19, 3, ConsoleColor.Black, ConsoleColor.DarkCyan);
                WriteColorString(new string('▬', 50), 19, 21, ConsoleColor.Black, ConsoleColor.DarkCyan);
                WriteColorString("Hire new employees", 20, 4, ConsoleColor.Black, ConsoleColor.DarkCyan);
                WriteColorString("Choose employee type :", 20, 6, ConsoleColor.Black, ConsoleColor.DarkCyan);
                WriteColorString("1- Bellboy, 2- Maid, 3 - Manager, 4 - Receptionist", 20, 7, ConsoleColor.Black, ConsoleColor.DarkCyan); // !!

                Console.SetCursorPosition(20, 8);
                int employeeType = int.Parse(Console.ReadLine());

                WriteColorString(new string('▬', 50), 20, 8, ConsoleColor.Black, ConsoleColor.White);
                WriteColorString(string.Format("HIRE new {0} option choosed!", employeeType), 20, 9, ConsoleColor.Black, ConsoleColor.White); // validation
                Employee newStaff = ReadHireDetails(employeeType);
                NewHotel.AddEmployee(newStaff);
            }
            catch (Exception) // ? custom exception
            {
                throw new Exception("Unsuccessful entry");
            }

            WriteColorString("New employee HIRED successfully!", 20, 17, ConsoleColor.Black, ConsoleColor.White);
            Menu(Menus.StaffMenu);
        }

        private static Employee ReadHireDetails(int employeeType)
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

            switch (employeeType)
            {
                case 1:
                    return new BellBoy(name[0], name[1], address, phone, mail, salary);
                case 2:
                    return new Maid(name[0], name[1], address, phone, mail, salary);
                case 3:
                    return new Manager(name[0], name[1], address, phone, mail, salary);
                case 4:
                    return new Receptionist(name[0], name[1], address, phone, mail, salary);
                default:
                    return null;
            }
        }

        private static void ListRooms()
        {
            WriteColorString("List of all ROOMS", 20, 4, ConsoleColor.Black, ConsoleColor.Cyan);

            int row = 6;
            var ordered = NewHotel.Rooms.OrderBy(x => x.NumberOfBeds).ThenBy(x => x.NumberOfRoom);
            foreach (var room in ordered)
            {
                WriteColorString(string.Format("{0}", room.ToString()), 19, row, ConsoleColor.Black, ConsoleColor.White);
                row += 2;
            }

            Menu(Menus.MainMenu);
        }

        private static void ServicesPriceInfo()
        {
            WriteColorString("Price list of all services", 20, 4, ConsoleColor.Black, ConsoleColor.Cyan);

            int row = 7;
            var ordered = NewHotel.Services.OrderBy(x => x.Price);
            foreach (var serv in ordered)
            {
                WriteColorString(new string('▬', 50), 19, 3, ConsoleColor.Black, ConsoleColor.DarkCyan);
                WriteColorString(string.Format("{0}", serv.ToString()), 19, row, ConsoleColor.Black, ConsoleColor.White);
                row += 3;
            }

            Menu(Menus.MainMenu);
        }
    }
}
