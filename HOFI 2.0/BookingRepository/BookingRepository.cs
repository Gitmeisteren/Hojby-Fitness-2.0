using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class BookingRepository
    {
       private List<Booking> bookingList = new List<Booking>();



        public void AddToRepo(Booking booking)
        {
            bookingList.Add(booking);
        }

        public bool FindDate(Booking newBooking)
        {
            bool dateAvailable = true;

            foreach(Booking b in bookingList)
            {
                if(b.BookingDate == newBooking.BookingDate)
                {
                    dateAvailable = false;
                    AddToRepo(newBooking);
                    
                }
                

                
            }


            return true;
        }

        

    }
}
