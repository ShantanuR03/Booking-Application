using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Admin
    {
        private static int currentAdminId = 1;
        public string AdminID { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public Admin(string userName, string password)
        {
            AdminID = "A" + currentAdminId++;
            UserName = userName;
            Password = password;
            Role = "Admin";
        }

        public void AddSeat(List<Seat> seats)
        {
            Seat newSeat = new Seat();
            seats.Add(newSeat);
            Console.WriteLine($"Seat {newSeat.SeatID} has been added by Admin {UserName}.");
        }

        public void ViewBookedSeats(List<Seat> seats)
        {
            var bookedSeats = seats.Where(s => s.IsBooked).ToList();
            if (bookedSeats.Count == 0)
            {
                Console.WriteLine("No seats are currently booked.");
            }
            else
            {
                Console.WriteLine("Booked Seats:");
                foreach (var seat in bookedSeats)
                {
                    Console.WriteLine($"Seat {seat.SeatID} is booked by {seat.BookedBy.UserName}.");
                }
            }
        }

        public void AddUser(List<User> users, string userName, string password)
        {
            User newUser = new User(userName, password, "User");
            newUser.Register(users);
        }
    }
}
