using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Booking
    {
        private static int currentBookingId = 1;
        public int BookingID { get; private set; }
        public User BookedBy { get; private set; }
        public Seat BookedSeat { get; private set; }
        public DateTime BookingTime { get; private set; }

        public Booking(User user, Seat seat)
        {
            BookingID = currentBookingId++;
            BookedBy = user;
            BookedSeat = seat;
            BookingTime = DateTime.Now;
        }

        public void DisplayBookingDetails()
        {
            Console.WriteLine($"Booking ID: {BookingID}");
            Console.WriteLine($"Seat ID: {BookedSeat.SeatID}");
            Console.WriteLine($"Booked By: {BookedBy.UserName}");
            Console.WriteLine($"Booking Time: {BookingTime}");
        }
    }
}
