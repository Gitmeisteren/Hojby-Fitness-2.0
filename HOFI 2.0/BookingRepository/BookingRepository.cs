﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class BookingRepository
    {
       private List<Booking> _BookingList = new List<Booking>();

        private static BookingRepository _Instance;

        public static BookingRepository GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new BookingRepository();
            }
            return _Instance;
        }

        private BookingRepository()
        {

        }

        //Kunne optimere ved at fusionere til en.
        public void AddToRepo(Booking booking)
        {
            _BookingList.Add(booking);
        }

        public void AddBookingsToRepoFromDB(List<Booking> bookings)
        {
                foreach (Booking booking in bookings)
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

        public List<Booking> RetrieveCalendarDates()
        {
            
            return _BookingList;
        }
    }
}