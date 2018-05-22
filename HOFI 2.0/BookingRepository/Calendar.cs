using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Calendar
    {
        private Calendar()
        {
            
        }

        

        private static Calendar _Instance;

        public static Calendar GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Calendar();
            }
            return _Instance;
        }

        public List<string> UpdateCalendar(List<Booking> retrievedCalendarList)
        {
        List<string> updatedCalendarDates = new List<string>();
            DateTime dates;
            string stringDates = "";

            dates = DateTime.Today;

            for (int i = 0; i < 30; i++)
            {
                stringDates = dates.ToString("dd-MM-yyyy");

                foreach(Booking BookingDate in retrievedCalendarList)
                {
                    if(stringDates == BookingDate.BookingDate)
                    {
                        stringDates += " \n - optaget" + "\n" + BookingDate.MemberNumber;
                    }
                }
                updatedCalendarDates.Add(stringDates);
                
                dates = dates.AddDays(1);
            }
           
            return updatedCalendarDates;
        }
    }
}