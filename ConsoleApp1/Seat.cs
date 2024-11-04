using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Seat
    {
        private static int currentSeatId = 1;
        public int SeatID { get; private set; }
        public bool IsBooked { get; private set; }
        public User BookedBy { get; private set; }

        public Seat()
        {
            SeatID = currentSeatId++;
            IsBooked = false;
            BookedBy = null;
        }

        public void BookSeat(User user)
        {
            if (!IsBooked)
            {
                IsBooked = true;
                BookedBy = user;
                Console.WriteLine($"Seat {SeatID} has been booked by {user.UserName}.");
            }
            else
            {
                Console.WriteLine($"Seat {SeatID} is already booked.");
            }
        }

        public void CancelBooking(User user)
        {
            if (IsBooked && BookedBy == user)
            {
                IsBooked = false;
                BookedBy = null;
                Console.WriteLine($"Seat {SeatID} booking has been canceled by {user.UserName}.");
            }
            else if (!IsBooked)
            {
                Console.WriteLine($"Seat {SeatID} is not booked yet.");
            }
            else
            {
                Console.WriteLine($"Seat {SeatID} cannot be canceled by {user.UserName} as it was booked by another user.");
            }
        }
    }
}
