using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model 
{
    public class Shift : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Shift

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

        string _Type = "";
        string _Date = "";
        int _Salary = 0;
        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
                OnPropertyChanged("Type");
            }
        }
        public string Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
                OnPropertyChanged("Date");

            }
        }
        public int Salary
        {
            get
            {
                return _Salary;
            }
            set
            {
                _Salary = value;
                OnPropertyChanged("Salary");
            }
        }

    }
}
