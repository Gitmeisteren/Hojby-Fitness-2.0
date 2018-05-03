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
        Calendar calendar = Calendar.GetInstance();

        private static Controller _Instance;

        private string _ReturnMessage;

        public Booking NewBooking { get; set; }
        public Member NewMember { get; set; }

        public Calendar CalendarDates { get; set; }

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

        string _Label1 = "";
        string _Label2 = "";
        string _Label3 = "";
        string _Label4 = "";
        string _Label5 = "";
        string _Label6 = "";
        string _Label7 = "";
        string _Label8 = "";
        string _Label9 = "";
        string _Label10 = "";
        string _Label11 = "";
        string _Label12 = "";
        string _Label13 = "";
        string _Label14 = "";
        string _Label15 = "";
        string _Label16 = "";
        string _Label17 = "";
        string _Label18 = "";
        string _Label19 = "";
        string _Label20 = "";
        string _Label21 = "";
        string _Label22 = "";
        string _Label23 = "";
        string _Label24 = "";
        string _Label25 = "";
        string _Label26 = "";
        string _Label27 = "";
        string _Label28 = "";
        string _Label29 = "";
        string _Label30 = "";



        public string Label_1
        {
            get
            {
                return _Label1;
            }
            set
            {
                _Label1 = value;
                OnPropertyChanged("Label_1");
            }
        }

        public string Label_2
        {
            get
            {
                return _Label2;
            }
            set
            {
                _Label2 = value;
                OnPropertyChanged("Label_2");
            }
        }

        public string Label_3
        {
            get
            {
                return _Label3;
            }
            set
            {
                _Label3 = value;
                OnPropertyChanged("Label_3");
            }
        }

        public string Label_4
        {
            get
            {
                return _Label4;
            }
            set
            {
                _Label4 = value;
                OnPropertyChanged("Label_4");
            }
        }

        public string Label_5
        {
            get
            {
                return _Label5;
            }
            set
            {
                _Label5 = value;
                OnPropertyChanged("Label_5");
            }
        }
        public string Label_6
        {
            get
            {
                return _Label6;
            }
            set
            {
                _Label6 = value;
                OnPropertyChanged("Label_6");
            }
        }
        public string Label_7
        {
            get
            {
                return _Label7;
            }
            set
            {
                _Label7 = value;
                OnPropertyChanged("Label_7");
            }
        }
        public string Label_8
        {
            get
            {
                return _Label8;
            }
            set
            {
                _Label8 = value;
                OnPropertyChanged("Label_8");
            }
        }





        public Controller()
        {
            NewBooking = new Booking();
            bookingRepo = new BookingRepository();
            NewMember = new Member();
            CalendarDates = Calendar.GetInstance();
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

        public void UpdateCalendar()
        {
            bookingHandler.UpdateCalendar();
        }
    }
}