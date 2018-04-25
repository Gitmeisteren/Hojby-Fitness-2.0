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
        Booking member = new Booking();
        public Booking NewBooking { get; set; }
        public Member NewMember { get; set; }

        SQLDatabaseConnectionPoint _databaseCon = new SQLDatabaseConnectionPoint();

        public Controller()
        {
            NewBooking = new Booking();
            NewMember = new Member();
        }

        
        public void ScheduleSession()
        {
            _databaseCon.ScheduleSession(NewBooking);
        }
    }
}
