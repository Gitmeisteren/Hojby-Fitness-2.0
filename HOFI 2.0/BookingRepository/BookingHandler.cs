using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class BookingHandler : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        Booking member = new Booking();

        private static BookingHandler _Instance;
        public static BookingHandler GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new BookingHandler();
            }
            return _Instance;
        }



        BookingRepository bookingRepo = new BookingRepository();
        SQLDatabaseConnectionPoint _databaseCon = new SQLDatabaseConnectionPoint();

        private BookingHandler()
        {
           
        }

        public string ScheduleSession(Booking NewBooking)
        {
            Booking bookingClone = new Booking();
            string returnMessage = "";
            bookingClone.BookingDate = NewBooking.BookingDate;
            bookingClone.MemberNumber = NewBooking.MemberNumber;

           bool dateAvailable = bookingRepo.FindDate(bookingClone);
            
            if (dateAvailable)
            {
                returnMessage = _databaseCon.ScheduleSession(bookingClone);
               
            }

            return returnMessage;

            

        }

        public void IntitialRepoUpdate()
        {
           List<Booking> bookingsFromDB = _databaseCon.InitialRepoUpdate();

            bookingRepo.AddBookingsToRepoFromDB(bookingsFromDB);

        }

        public void CreateNewMember(Member NewMember, Booking NewBooking)
        {
            _databaseCon.CreateNewMember(NewMember, NewBooking);
        }

        public List<string> UpdateCalendar()
        {
            Calendar calendar = Calendar.GetInstance();
            List<string> retrivedCalendarDates = new List<string>();
            List<string> updatedCalendarDates = new List<string>();


           retrivedCalendarDates = bookingRepo.RetrieveCalendarDates();
           updatedCalendarDates = calendar.UpdateCalendar(retrivedCalendarDates);

            return updatedCalendarDates;
        }

    }
}
