namespace ConsoleApp1
{
    internal class Program
    {

        private static List<User> users = new List<User>();
        private static List<Seat> seats = new List<Seat>();
        private static List<Booking> bookings = new List<Booking>();
        static void Main(string[] args)
        {
            Admin admin = new Admin("admin", "admin123");
            admin.Register(users);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n--- Seat Booking Application ---");
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                User loggedInUser = Login(username, password);

                if (loggedInUser == null)
                {
                    Console.WriteLine("Invalid credentials. Please try again.");
                    continue;
                }

                if (loggedInUser.Role == "Admin")
                {
                    AdminMenu(loggedInUser as Admin);
                }
                else
                {
                    UserMenu(loggedInUser);
                }
            }
        }
        public static User Login(string username, string password)
        {
            return users.Find(user => user.UserName == username && user.Password == password);
        }

        public static void AdminMenu(Admin admin)
        {
            while (true)
            {
                Console.WriteLine("\n--- Admin Menu ---");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Add Seat");
                Console.WriteLine("3. Book Seat");
                Console.WriteLine("4. Cancel Booking");
                Console.WriteLine("5. View Booked Seats");
                Console.WriteLine("6. Logout");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddUser(admin);
                        break;
                    case "2":
                        admin.AddSeat(seats);
                        break;
                    case "3":
                        BookSeat(admin);
                        break;
                    case "4":
                        CancelBooking(admin);
                        break;
                    case "5":
                        admin.ViewBookedSeats(seats);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        public static void UserMenu(User user)
        {
            while (true)
            {
                Console.WriteLine("\n--- User Menu ---");
                Console.WriteLine("1. Book Seat");
                Console.WriteLine("2. Cancel Booking");
                Console.WriteLine("3. Logout");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BookSeat(user);
                        break;
                    case "2":
                        CancelBooking(user);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        public static void AddUser(Admin admin)
        {
            Console.Write("Enter new username: ");
            string newUsername = Console.ReadLine();
            Console.Write("Enter password: ");
            string newPassword = Console.ReadLine();
            Console.Write("Enter role (Admin/User): ");
            string role = Console.ReadLine();

            admin.AddUser(users, newUsername, newPassword);
        }

        public static void BookSeat(User user)
        {
            Console.WriteLine("\n--- Available Seats ---");
            foreach (var seat in seats)
            {
                if (!seat.IsBooked)
                {
                    Console.WriteLine($"Seat {seat.SeatID} is available.");
                }
            }

            Console.Write("Enter Seat ID to book: ");
            int seatID;
            if (int.TryParse(Console.ReadLine(), out seatID))
            {
                Seat seat = seats.Find(s => s.SeatID == seatID);
                if (seat != null && !seat.IsBooked)
                {
                    seat.BookSeat(user);
                    bookings.Add(new Booking(user, seat));
                }
                else
                {
                    Console.WriteLine("Invalid seat ID or seat is already booked.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid seat ID.");
            }
        }

        public static void CancelBooking(User user)
        {
            Console.WriteLine("\n--- Your Bookings ---");
            var userBookings = bookings.FindAll(b => b.BookedBy.UserID == user.UserID);
            if (userBookings.Count == 0)
            {
                Console.WriteLine("No bookings found.");
                return;
            }

            foreach (var booking in userBookings)
            {
                Console.WriteLine($"Booking ID: {booking.BookingID}, Seat ID: {booking.BookedSeat.SeatID}, Time: {booking.BookingTime}");
            }

            Console.Write("Enter Booking ID to cancel: ");
            int bookingID;
            if (int.TryParse(Console.ReadLine(), out bookingID))
            {
                var bookingToCancel = userBookings.Find(b => b.BookingID == bookingID);
                if (bookingToCancel != null)
                {
                    bookingToCancel.BookedSeat.CancelBooking(user);
                    bookings.Remove(bookingToCancel);
                }
                else
                {
                    Console.WriteLine("Invalid Booking ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Booking ID.");
            }
        }
    }
    
}
