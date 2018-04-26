using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class BookingController : INotifyPropertyChanged
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

        private static BookingController _Instance;
        public static BookingController GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new BookingController();
            }
            return _Instance;
        }

        private string _ReturnMessage;

        
        public Booking NewBooking { get; set; }
        public Member NewMember { get; set; }

      

        public string ReturnMessage {
            get {
                return _ReturnMessage;
            }set {
                _ReturnMessage = value;
                OnPropertyChanged("ReturnMessage");
            } }


        BookingRepository bookingRepo;
        SQLDatabaseConnectionPoint _databaseCon = new SQLDatabaseConnectionPoint();

        private BookingController()
        {
            NewBooking = new Booking();
            bookingRepo = new BookingRepository();
            NewMember = new Member();
        }

        public void ScheduleSession()
        {
            Booking bookingClone = new Booking();
            bookingClone.BookingDate = NewBooking.BookingDate;
            bookingClone.MemberNumber = NewBooking.MemberNumber;

           bool dateAvailable = bookingRepo.FindDate(bookingClone);
            
            if (dateAvailable)
            {
                _databaseCon.ScheduleSession(bookingClone);
                ReturnMessage = "Booking Oprettet.";
            }
            else
            {
                ReturnMessage = "Dagen er optaget.";
            }
            

        }

        public void IntitialRepoUpdate()
        {
           List<Booking> bookingsFromDB = _databaseCon.InitialRepoUpdate();

            bookingRepo.AddBookingsToRepoFromDB(bookingsFromDB);

        }

        public void CreateNewMember()
        {
            _databaseCon.CreateNewMember(NewMember, NewBooking);
        }
    }
}
