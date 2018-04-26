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
            
            if (dateAvailable)
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
           List<Booking> bookingsFromDB = _databaseCon.InitialRepoUpdate();

            bookingRepo.AddBookingsToRepoFromDB(bookingsFromDB);

        }

        public void CreateNewMember()
        {
            _databaseCon.CreateNewMember(NewMember, NewBooking);
        }
    }
}
