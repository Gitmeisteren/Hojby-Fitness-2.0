using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
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

        Booking _Member = new Booking();
        SQLDatabaseConnectionPoint _DatabaseCon = new SQLDatabaseConnectionPoint();
        BookingRepository _BookingRepo = BookingRepository.GetInstance();

        private static BookingHandler _Instance;
        
        public static BookingHandler GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new BookingHandler();
            }
            return _Instance;
        }

        private BookingHandler()
        {
           
        }

        public string BookSession(Booking NewBooking)
        {
            Booking bookingClone = new Booking();
            string _ReturnMessage = "";
            bookingClone.BookingDate = NewBooking.BookingDate;
            bookingClone.MemberNumber = NewBooking.MemberNumber;

           bool _DateAvailable = _BookingRepo.FindDate(bookingClone);
            
            if (_DateAvailable)
            {
                _ReturnMessage = _DatabaseCon.BookSession(bookingClone);

            }
            else
            {
                _ReturnMessage = "Dagen er optaget";
            }

            return _ReturnMessage;

            

        }

        public void IntitialRepoUpdate()
        {
           List<Booking> _BookingsFromDB = _DatabaseCon.InitialRepoUpdate();

            _BookingRepo.AddBookingsToRepoFromDB(_BookingsFromDB);

        }

        public void CreateNewMember(Member NewMember, Booking NewBooking)
        {
            _DatabaseCon.CreateNewMember(NewMember, NewBooking);
        }

        public List<string> UpdateCalendar()
        {
            Calendar _Calendar = Calendar.GetInstance();
            List<Booking> _RetrivedCalendarDates = new List<Booking>();
            List<string> _UpdatedCalendarDates = new List<string>();


           _RetrivedCalendarDates = _BookingRepo.RetrieveCalendarDates();
           _UpdatedCalendarDates = _Calendar.UpdateCalendar(_RetrivedCalendarDates);

            return _UpdatedCalendarDates;
        }

    }
}
