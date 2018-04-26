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
            foreach(Booking b in bookings)
            {
                _BookingList.Add(b);
            }


        }


        public bool FindDate(Booking newBooking)
        {
            bool dateAvailable = true;

            foreach (Booking b in _BookingList)
            {
                if (b.BookingDate == newBooking.BookingDate)
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

        

    }
}
