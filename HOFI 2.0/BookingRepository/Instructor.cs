using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Instructor : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Instructor

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
        string _InstructorID = "";
        string _Name = "";
        string _Mail = "";
        string _HireDate = "";
        public string InstructorID
        {
            get
            {
                return _InstructorID;
            }
            set
            {
                _InstructorID = value;
                OnPropertyChanged("MemberNumber");
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Mail
        {
            get
            {
                return _Mail;
            }
            set
            {
                _Mail = value;
                OnPropertyChanged("Mail");
            }
        }
        public string HireDate
        {
            get
            {
                ;
                return _HireDate;
            }
            set
            {
                _HireDate = value;
                OnPropertyChanged("HireDate");
            }
        }
    }
}