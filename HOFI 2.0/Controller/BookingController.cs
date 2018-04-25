using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class BookingController
    {
        Booking member = new Booking();
        public Booking NewBooking { get; set; }
        public Member NewMember { get; set; }

        public string ReturnMessage { get; set; }

        BookingRepository bookingRepo = new BookingRepository();
        SQLDatabaseConnectionPoint _databaseCon = new SQLDatabaseConnectionPoint();

        public BookingController()
        {
            NewBooking = new Booking();
            NewMember = new Member();
        }

        public void ScheduleSession()
        {
           bool dateAvailable = bookingRepo.FindDate(NewBooking);
            
            if (!dateAvailable)
            {
                _databaseCon.ScheduleSession(NewBooking);
                ReturnMessage = "Booking Oprettet.";
            }
            else
            {
                ReturnMessage = "Dagen er optaget.";
            }
            

        }

        public void IntitialRepoUpdate()
        {
            _databaseCon.InitialRepoUpdate();

        }

        public void CreateNewMember()
        {
            _databaseCon.CreateNewMember(NewMember, NewBooking);
        }
    }
}
