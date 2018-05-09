using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class ShiftHandler : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged ShiftHandler

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
        Shift shift = new Shift();
        SQLDatabaseConnectionPoint _DatabaseCon = new SQLDatabaseConnectionPoint();
        public string RegisterShift(Shift shift, Instructor instructor, string shiftType)
        {
            string returnMessage = "";
            Instructor instructorClone = new Instructor();
            Shift shiftClone = new Shift();
            shiftClone.Date = shift.Date;
            instructorClone.MemberNumber = instructor.MemberNumber;
            string registerShiftResponse = _DatabaseCon.RegisterShift(shiftClone, instructorClone, shiftType);
            return returnMessage;
        }
        private static ShiftHandler _Instance;

        public static ShiftHandler GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new ShiftHandler();
            }
            return _Instance;
        }

        private ShiftHandler()
        {

        }
    }
}
