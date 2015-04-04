namespace HotelSystemApp
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using HotelSystemApp.Exceptions;
    using HotelSystemApp.Person;

    public enum MenusEnum
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
        public static bool Menu(MenusEnum currentMenu)
        {
            Console.TreatControlCAsInput = false;
            Console.CursorVisible = false;

            WriteColorString(new string('▬', 136), 2, 1, ConsoleColor.Black, ConsoleColor.Yellow);
            WriteColorString(new string('▬', 136), 2, 23, ConsoleColor.Black, ConsoleColor.Yellow);
            WriteColorString("{Team FIG} TelericAcademy 2015", 55, 2, ConsoleColor.Black, ConsoleColor.DarkGray);
            WriteColorString("use ↑ ↓ keys and press ENTER", 55, 22, ConsoleColor.Black, ConsoleColor.White);

            switch (currentMenu)
            {
                case MenusEnum.MainMenu:
                    CurrentMenuChoises = MainMenuChoises;
                    break;
                case MenusEnum.ClientsMenu:
                    CurrentMenuChoises = ClientMenuChoises;
                    WriteColorString("Clients Menu", 4, 2, ConsoleColor.Black, ConsoleColor.Yellow);
                    break;
                case MenusEnum.StaffMenu:
                    CurrentMenuChoises = StaffMenuChoises;
                    WriteColorString("Staff Menu", 5, 2, ConsoleColor.Black, ConsoleColor.Yellow);
                    break;
                case MenusEnum.Reservations:
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
                    Menu(MenusEnum.Reservations);
                    break;
                case "ROOMS INFO":
                    ListRooms();
                    break;
                case "CLIENTS":
                    Menu(MenusEnum.ClientsMenu);
                    break;
                case "STAFF":
                    Menu(MenusEnum.StaffMenu);
                    break;
                case "SERVICES":
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
                case "TASKS":
                    MaidCleanFreeRooms();
                    break;
                case "CHECK IN":
                    CheckInList();
                    break;
                case "CHECK OUT":
                    CheckOutList();
                    break;
                case "RETURN":
                    Menu(MenusEnum.MainMenu);
                    break;
                default:
                    break;
            }

            //WriteColorString("press ESC to return", 40, 22, ConsoleColor.Black, ConsoleColor.White);
            //while (true)
            //{
            //    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            //    if (pressedKey.Key == ConsoleKey.Escape)
            //    {
            //        Menu(MenusEnum.MainMenu);
            //    }
            //}
        }

        private static void CheckInList()
        {
            WriteColorString(new string('▬', 50), 19, 3, ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteColorString(new string('▬', 50), 19, 21, ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteColorString("Make new reservation", 20, 4, ConsoleColor.Black, ConsoleColor.DarkCyan);

            try
            {
                WriteColorString("Enter Room №: ", 20, 6, ConsoleColor.Black, ConsoleColor.Gray);
                int numberOfRoom = int.Parse(Console.ReadLine());

                WriteColorString("Client ID: ", 20, 7, ConsoleColor.Black, ConsoleColor.Gray);
                string clientID = Console.ReadLine().ToUpper();

                WriteColorString("Arrival date [DD.MM.YYYY]: ", 20, 8, ConsoleColor.Black, ConsoleColor.Gray);
                string date = Console.ReadLine();
                DateTime dateArrive = DateTime.ParseExact(date, "d.M.yyyy", CultureInfo.InvariantCulture);

                WriteColorString("Leaving date [DD.MM.YYYY]: ", 20, 9, ConsoleColor.Black, ConsoleColor.Gray);
                date = Console.ReadLine();
                DateTime dateLeave = DateTime.ParseExact(date, "d.M.yyyy", CultureInfo.InvariantCulture);

                WriteColorString("Number of guests: ", 20, 10, ConsoleColor.Black, ConsoleColor.Gray);
                byte numberOfGuests = byte.Parse(Console.ReadLine());

                int indexOfClient = NewHotel.Clients.FindIndex(x => x.ClientID == clientID);
                if (indexOfClient == -1)
                {
                    throw new ClientIDException("Invalid ID", clientID);
                }

                NewHotel.MakeReservation(NewHotel.Clients[indexOfClient], numberOfRoom, dateArrive, dateLeave, numberOfGuests);
            }
            catch (RoomNumberException ex)
            {
                WriteColorString(ex.Message, 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.Reservations);
            }
            catch (RoomAvailableException ex)
            {
                WriteColorString(ex.Message, 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.Reservations);
            }
            catch (ClientIDException ex)
            {
                WriteColorString(ex.Message, 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.Reservations);
            }
            catch (DateReservationException ex)
            {
                WriteColorString(ex.Message, 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.Reservations);
            }
            catch (RoomBedroomsException ex)
            {
                WriteColorString(ex.Message, 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.Reservations);
            }
            catch (FormatException)
            {
                WriteColorString("Input was not in a correct format!", 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.Reservations);
            }
            catch (Exception)
            {
                WriteColorString("Unsuccessful input!", 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.Reservations);
            }

            WriteColorString("New reservation made successfully!", 20, 17, ConsoleColor.Black, ConsoleColor.Green);
            Menu(MenusEnum.Reservations);
        }

        private static void CheckOutList()
        {
            WriteColorString(new string('▬', 50), 19, 3, ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteColorString(new string('▬', 50), 19, 21, ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteColorString("Check out rooms", 20, 4, ConsoleColor.Black, ConsoleColor.DarkCyan);

            try
            {
                WriteColorString("Enter room for checking-out: ", 20, 6, ConsoleColor.Black, ConsoleColor.White);
                int numberOfRoom = int.Parse(Console.ReadLine());
                WriteColorString("Enter Cient ID: ", 20, 7, ConsoleColor.Black, ConsoleColor.White);
                string clientID = Console.ReadLine().ToUpper();
                NewHotel.CheckOutRoom(numberOfRoom, clientID);
            }
            catch (RoomNumberException ex)
            {
                WriteColorString(ex.Message, 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.Reservations);
            }
            catch (RoomAvailableException ex)
            {
                WriteColorString(ex.Message, 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.Reservations);
            }
            catch (ClientIDException ex)
            {
                WriteColorString(ex.Message, 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.Reservations);
            }
            catch (ReservationException ex)
            {
                WriteColorString(ex.Message, 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.Reservations);
            }
            catch (FormatException)
            {
                WriteColorString("Input was not in a correct format!", 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.Reservations);
            }
            catch (Exception)
            {
                WriteColorString("Try again!", 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.Reservations);
            }

            WriteColorString("The room checked out successfully!", 20, 17, ConsoleColor.Black, ConsoleColor.Green);
            Menu(MenusEnum.Reservations);
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

            Menu(MenusEnum.ClientsMenu);
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

            Menu(MenusEnum.StaffMenu);
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

            Menu(MenusEnum.Reservations);
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

            Menu(MenusEnum.StaffMenu);
        }

        private static void AddNewClient()
        {
            WriteColorString(new string('▬', 50), 19, 3, ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteColorString(new string('▬', 50), 19, 21, ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteColorString("Add new client", 20, 4, ConsoleColor.Black, ConsoleColor.DarkCyan);
            try
            {
                WriteColorString("Enter First name : ", 20, 6, ConsoleColor.Black, ConsoleColor.Gray);
                string firstName = Console.ReadLine().Trim();
                WriteColorString("Enter Last name : ", 20, 7, ConsoleColor.Black, ConsoleColor.Gray);
                string lastName = Console.ReadLine().Trim();
                WriteColorString("Enter address : ", 20, 8, ConsoleColor.Black, ConsoleColor.Gray);
                string address = Console.ReadLine();
                WriteColorString("Enter phone number : ", 20, 9, ConsoleColor.Black, ConsoleColor.Gray);
                string phone = Console.ReadLine().Trim();
                WriteColorString("Enter e-mail address : ", 20, 10, ConsoleColor.Black, ConsoleColor.Gray);
                string mail = Console.ReadLine().Trim();
                WriteColorString("Enter IBAN : ", 20, 11, ConsoleColor.Black, ConsoleColor.Gray);
                string iban = Console.ReadLine();
                NewHotel.AddClient(new Client(firstName, lastName, address, phone, mail, iban));
            }
            catch (FormatException)
            {
                WriteColorString("Input was not in a correct format!", 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.ClientsMenu);
            }
            catch (Exception)
            {
                WriteColorString("Unsuccessful input!", 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.ClientsMenu);
            }

            WriteColorString("New client added successfully!", 20, 17, ConsoleColor.Black, ConsoleColor.Green);
            Menu(MenusEnum.ClientsMenu);
        }

        private static void HireStaff()
        {
            WriteColorString(new string('▬', 50), 19, 3, ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteColorString(new string('▬', 50), 19, 21, ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteColorString("Hire new employees", 20, 4, ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteColorString("Choose employee type :", 20, 6, ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteColorString("1 - Bellboy, 2 - Maid, 3 - Manager, 4 - Receptionist", 20, 7, ConsoleColor.Black, ConsoleColor.DarkCyan);
            Console.SetCursorPosition(20, 8);
            try
            {
                int employeeType = int.Parse(Console.ReadLine());

                WriteColorString(new string('▬', 50), 20, 9, ConsoleColor.Black, ConsoleColor.White);

                Employee newStaff = ReadHireDetails(employeeType);
                NewHotel.AddEmployee(newStaff);
            }
            catch (EmployeeTypeException ex)
            {
                WriteColorString(ex.Message, 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.StaffMenu);
            }
            catch (FormatException)
            {
                WriteColorString("Input was not in a correct format!", 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.StaffMenu);
            }
            catch (Exception)
            {
                WriteColorString("Unsuccessful input!", 20, 17, ConsoleColor.Black, ConsoleColor.Red);
                ClearConsoleException(MenusEnum.StaffMenu);
            }

            WriteColorString("New employee HIRED successfully!", 20, 17, ConsoleColor.Black, ConsoleColor.Green);
            Menu(MenusEnum.StaffMenu);
        }

        private static void ClearConsoleException(MenusEnum type)
        {
            Thread.Sleep(2500);
            Console.Clear();
            Menu(type);
        }

        private static Employee ReadHireDetails(int employeeType)
        {
            WriteColorString("Enter First name : ", 20, 10, ConsoleColor.Black, ConsoleColor.Gray);
            string firstName = Console.ReadLine().Trim();
            WriteColorString("Enter Last name : ", 20, 11, ConsoleColor.Black, ConsoleColor.Gray);
            string lastName = Console.ReadLine().Trim();
            WriteColorString("Enter address : ", 20, 12, ConsoleColor.Black, ConsoleColor.Gray);
            string address = Console.ReadLine();
            WriteColorString("Enter phone number : ", 20, 13, ConsoleColor.Black, ConsoleColor.Gray);
            string phone = Console.ReadLine().Trim();
            WriteColorString("Enter e-mail address : ", 20, 14, ConsoleColor.Black, ConsoleColor.Gray);
            string mail = Console.ReadLine().Trim();
            WriteColorString("Enter monthly salary : ", 20, 15, ConsoleColor.Black, ConsoleColor.Gray);
            decimal salary = decimal.Parse(Console.ReadLine());

            switch (employeeType)
            {
                case 1:
                    return new BellBoy(firstName, lastName, address, phone, mail, salary);
                case 2:
                    return new Maid(firstName, lastName, address, phone, mail, salary);
                case 3:
                    return new Manager(firstName, lastName, address, phone, mail, salary);
                case 4:
                    return new Receptionist(firstName, lastName, address, phone, mail, salary);
                default:
                    throw new EmployeeTypeException(employeeType);
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

            Menu(MenusEnum.MainMenu);
        }

        private static void ServicesPriceInfo()
        {
            WriteColorString("Price list of all services", 20, 4, ConsoleColor.Black, ConsoleColor.Cyan);

            int row = 7;
            var ordered = NewHotel.Services.OrderBy(x => x.Price);
            foreach (var serv in ordered)
            {
                WriteColorString(string.Format("{0}", serv.ToString()), 19, row, ConsoleColor.Black, ConsoleColor.White);
                row += 3;
            }

            Menu(MenusEnum.MainMenu);
        }

        private static void MaidCleanFreeRooms()
        {
            WriteColorString("Free rooms for maid service (cleaning, changing)", 20, 4, ConsoleColor.Black, ConsoleColor.Cyan);

            int row = 7;
            var roomsForClean = NewHotel.Rooms.Where(x => x.IsAvailable);
            foreach (var room in roomsForClean)
            {
                WriteColorString(new string('▬', 50), 19, 3, ConsoleColor.Black, ConsoleColor.DarkCyan);
                WriteColorString(string.Format("Room [{0}] needs Maid attention", room.NumberOfRoom.ToString()), 19, row, ConsoleColor.Black, ConsoleColor.White);
                row += 2;
            }
            WriteColorString(string.Format("Press ENTER to assign all free rooms to current MAIDs"), 19, row, ConsoleColor.Black, ConsoleColor.DarkCyan);

            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            if (pressedKey.Key == ConsoleKey.Enter)
            {
                foreach (var emp in NewHotel.Employees.Where(x => x.GetType().Name.ToLower() == "maid"))
                {
                    emp.ToogleCleanRoom();
                }
                Console.Clear();
                WriteColorString(string.Format("    All free rooms assigned for cleaning to active maids"), 19, 5, ConsoleColor.Black, ConsoleColor.White);
            }

            Menu(MenusEnum.StaffMenu);
        }
    }
}
