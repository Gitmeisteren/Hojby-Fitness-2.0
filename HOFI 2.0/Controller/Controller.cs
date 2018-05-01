using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class Controller : INotifyPropertyChanged
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
        BookingHandler bookingHandler = BookingHandler.GetInstance();
        Booking booking = new Booking();
        Member member = new Member();
        BookingRepository bookingRepo = new BookingRepository();

        private static Controller _Instance;

        private string _ReturnMessage;

        public Booking NewBooking { get; set; }
        public Member NewMember { get; set; }



        public string ReturnMessage
        {
            get
            {
                return _ReturnMessage;
            }
            set
            {
                _ReturnMessage = value;
                OnPropertyChanged("ReturnMessage");
            }
        }

        public Controller()
        {
            NewBooking = new Booking();
            bookingRepo = new BookingRepository();
            NewMember = new Member();
        }

        public static Controller GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Controller();
            }
            return _Instance;
        }


        public void ScheduleSession()
    {

        ReturnMessage = bookingHandler.ScheduleSession(NewBooking);
        
    }

        public void CreateNewMember()
        {
            bookingHandler.CreateNewMember(NewMember, NewBooking);
        }

        public void IntitialRepoUpdate()
        {
            bookingHandler.IntitialRepoUpdate();
        }
    }

}
