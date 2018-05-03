using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class BookingRepository
    {
       private List<Booking> _BookingList = new List<Booking>();

        //Kunne optimere ved at fusionere til en.
        public void AddToRepo(Booking booking)
        {
            _BookingList.Add(booking);
        }

        public void AddBookingsToRepoFromDB(List<Booking> bookings)
        {
            foreach(Booking booking in bookings)
            {
                _BookingList.Add(booking);
            }
        }

        public bool FindDate(Booking newBooking)
        {
            bool dateAvailable = true;

            foreach (Booking booking in _BookingList)
            {
                if (booking.BookingDate == newBooking.BookingDate)
                {
                    dateAvailable = false;
                }
            }
            if (dateAvailable)
            {
                AddToRepo(newBooking);
            }

            return dateAvailable;
        }

        public List<string> RetrieveCalendarDates()
        {

            string[] dateTemp;
            List<string> RetrievedDates = new List<string>();
            foreach(Booking booking in _BookingList)
            {
               dateTemp = booking.BookingDate.Split('-');
                RetrievedDates.Add(dateTemp[0] + "-" + dateTemp[1]);
            }
            return RetrievedDates;
        }
    }
}