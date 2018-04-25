using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class Controller
    {
        public Booking NewBooking { get; set; }
        Booking member = new Booking();
        SQLDatabaseConnectionPoint _databaseCon = new SQLDatabaseConnectionPoint();

        public Controller()
        {
            NewBooking = new Booking();
        }

        
        public void ScheduleSession()
        {
            _databaseCon.ScheduleSession(NewBooking);
        }
    }
}
