using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Booking : INotifyPropertyChanged
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

        int _BookingID = 0;
        string _MemberNumber = "";
        DateTime _BookingDate = DateTime.Today;


        public int BookingID
        {
            get
            {
                return _BookingID;
            }
            set
            {
                _BookingID = value;
                OnPropertyChanged("BookingID");
            }
        }

        public string MemberNumber
        {
            get
            {
                return _MemberNumber;
            }
            set
            {
                _MemberNumber = value;
                OnPropertyChanged("Member Number");
            }
        }

        public DateTime BookingDate
        {
            get
            {
                return _BookingDate;
            }
            set
            {
                _BookingDate = value;
                OnPropertyChanged("Booking Date");
            }
        }
    }
}