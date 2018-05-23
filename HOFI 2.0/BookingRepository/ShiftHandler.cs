using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            instructorClone.InstructorID = instructor.InstructorID;
            returnMessage = _DatabaseCon.RegisterShift(shiftClone, instructorClone, shiftType);
            return returnMessage;
        }
        public string ShiftList(Shift shift, Instructor instructor, string instructorID, string shiftStartDate, string shiftEndDate)
        {
            string returnShifts = "";
            if (instructorID == "")
            {
                returnShifts = _DatabaseCon.GetShiftListAll(shift, instructor, shiftStartDate, shiftEndDate);
            }
            else
            {
                returnShifts = _DatabaseCon.GetShiftListSingle(shift, instructor, instructorID, shiftStartDate, shiftEndDate);
            }
            return returnShifts;
        }
        public void ExportShiftList(string shiftList, string shiftStartDate, string shiftEndDate)
        {
            string folderpath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            string primaryFoldername = folderpath + "\\HøjRegistrering";
            string shiftFoldername = primaryFoldername + "\\Vagter";
            if (!Directory.Exists(primaryFoldername))
            {
                Directory.CreateDirectory(primaryFoldername);
            }
            if (!Directory.Exists(shiftFoldername))
            {
                Directory.CreateDirectory(shiftFoldername);
            }
            string filenameAll = "Vagtliste " + shiftStartDate + " til " + shiftEndDate + ".csv";
            string pathstringAll = System.IO.Path.Combine(shiftFoldername, filenameAll);
            using (StreamWriter sw = File.CreateText(pathstringAll))
            {
                sw.WriteLine(shiftList);
            }
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