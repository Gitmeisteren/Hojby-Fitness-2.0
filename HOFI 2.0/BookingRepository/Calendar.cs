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

        List<string> updatedCalendarDates = new List<string>();
        

        private static Calendar _Instance;

        public static Calendar GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Calendar();
            }
            return _Instance;
        }

        public List<string> UpdateCalendar(List<string> retrievedCalendarList)
        {
            DateTime dates;
            string stringDates = "";

            dates = DateTime.Today;

            for (int i = 0; i < 30; i++)
            {
                stringDates = dates.ToString("dd.MM");

                foreach(string date in retrievedCalendarList)
                {
                    if(stringDates == date)
                    {
                        stringDates += " - optaget";
                    }
                }
                updatedCalendarDates.Add(stringDates);
                
                dates = dates.AddDays(1);
            }
           
            return updatedCalendarDates;
        }
    }
}