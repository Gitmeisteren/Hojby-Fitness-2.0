using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Calendar : INotifyPropertyChanged
    {
        private Calendar()
        {
            
        }
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
        List<string> updatedCalendarDates = new List<string>();
        public string Label_1
        {
            get
            {
                return updatedCalendarDates[0];
            }
            set
            {
                updatedCalendarDates[0] = value;
                OnPropertyChanged("Label_1");
            }
        }
        public string Label_2
        {
            get
            {
                return updatedCalendarDates[1];
            }
            set
            {
                updatedCalendarDates[1] = value;
                OnPropertyChanged("Label_2");
            }
        }
        public string Label_3
        {
            get
            {
                return updatedCalendarDates[2];
            }
            set
            {
                updatedCalendarDates[2] = value;
                OnPropertyChanged("Label_3");
            }
        }
        public string Label_4
        {
            get
            {
                return updatedCalendarDates[3];
            }
            set
            {
                updatedCalendarDates[3] = value;
                OnPropertyChanged("Label_4");
            }
        }
        public string Label_5
        {
            get
            {
                return updatedCalendarDates[4];
            }
            set
            {
                updatedCalendarDates[4] = value;
                OnPropertyChanged("Label_5");
            }
        }
        public string Label_6
        {
            get
            {
                return updatedCalendarDates[5];
            }
            set
            {
                updatedCalendarDates[5] = value;
                OnPropertyChanged("Label_6");
            }
        }
        public string Label_7
        {
            get
            {
                return updatedCalendarDates[6];
            }
            set
            {
                updatedCalendarDates[6] = value;
                OnPropertyChanged("Label_7");
            }
        }
        public string Label_8
        {
            get
            {
                return updatedCalendarDates[7];
            }
            set
            {
                updatedCalendarDates[7] = value;
                OnPropertyChanged("Label_8");
            }
        }
        public string Label_9
        {
            get
            {
                return updatedCalendarDates[8];
            }
            set
            {
                updatedCalendarDates[8] = value;
                OnPropertyChanged("Label_9");
            }
        }
        public string Label_10
        {
            get
            {
                return updatedCalendarDates[9];
            }
            set
            {
                updatedCalendarDates[9] = value;
                OnPropertyChanged("Label_10");
            }
        }
        public string Label_11
        {
            get
            {
                return updatedCalendarDates[10];
            }
            set
            {
                updatedCalendarDates[10] = value;
                OnPropertyChanged("Label_11");
            }
        }
        public string Label_12
        {
            get
            {
                return updatedCalendarDates[11];
            }
            set
            {
                updatedCalendarDates[11] = value;
                OnPropertyChanged("Label_12");
            }
        }
        public string Label_13
        {
            get
            {
                return updatedCalendarDates[12];
            }
            set
            {
                updatedCalendarDates[12] = value;
                OnPropertyChanged("Label_13");
            }
        }
        public string Label_14
        {
            get
            {
                return updatedCalendarDates[13];
            }
            set
            {
                updatedCalendarDates[13] = value;
                OnPropertyChanged("Label_14");
            }
        }
        public string Label_15
        {
            get
            {
                return updatedCalendarDates[14];
            }
            set
            {
                updatedCalendarDates[14] = value;
                OnPropertyChanged("Label_15");
            }
        }
        public string Label_16
        {
            get
            {
                return updatedCalendarDates[15];
            }
            set
            {
                updatedCalendarDates[15] = value;
                OnPropertyChanged("Label_16");
            }
        }
        public string Label_17
        {
            get
            {
                return updatedCalendarDates[16];
            }
            set
            {
                updatedCalendarDates[16] = value;
                OnPropertyChanged("Label_17");
            }
        }
        public string Label_18
        {
            get
            {
                return updatedCalendarDates[17];
            }
            set
            {
                updatedCalendarDates[17] = value;
                OnPropertyChanged("Label_18");
            }
        }
        public string Label_19
        {
            get
            {
                return updatedCalendarDates[18];
            }
            set
            {
                updatedCalendarDates[18] = value;
                OnPropertyChanged("Label_19");
            }
        }
        public string Label_20
        {
            get
            {
                return updatedCalendarDates[19];
            }
            set
            {
                updatedCalendarDates[19] = value;
                OnPropertyChanged("Label_20");
            }
        }
        public string Label_21
        {
            get
            {
                return updatedCalendarDates[20];
            }
            set
            {
                updatedCalendarDates[20] = value;
                OnPropertyChanged("Label_21");
            }
        }
        public string Label_22
        {
            get
            {
                return updatedCalendarDates[21];
            }
            set
            {
                updatedCalendarDates[21] = value;
                OnPropertyChanged("Label_22");
            }
        }
        public string Label_23
        {
            get
            {
                return updatedCalendarDates[22];
            }
            set
            {
                updatedCalendarDates[22] = value;
                OnPropertyChanged("Label_23");
            }
        }
        public string Label_24
        {
            get
            {
                return updatedCalendarDates[23];
            }
            set
            {
                updatedCalendarDates[23] = value;
                OnPropertyChanged("Label_24");
            }
        }
        public string Label_25
        {
            get
            {
                return updatedCalendarDates[24];
            }
            set
            {
                updatedCalendarDates[24] = value;
                OnPropertyChanged("Label_25");
            }
        }
        public string Label_26
        {
            get
            {
                return updatedCalendarDates[25];
            }
            set
            {
                updatedCalendarDates[25] = value;
                OnPropertyChanged("Label_26");
            }
        }
        public string Label_27
        {
            get
            {
                return updatedCalendarDates[26];
            }
            set
            {
                updatedCalendarDates[26] = value;
                OnPropertyChanged("Label_27");
            }
        }
        public string Label_28
        {
            get
            {
                return updatedCalendarDates[27];
            }
            set
            {
                updatedCalendarDates[27] = value;
                OnPropertyChanged("Label_28");
            }
        }
        public string Label_29
        {
            get
            {
                return updatedCalendarDates[28];
            }
            set
            {
                updatedCalendarDates[28] = value;
                OnPropertyChanged("Label_29");
            }
        }
        public string Label_30
        {
            get
            {
                return updatedCalendarDates[29];
            }
            set
            {
                updatedCalendarDates[29] = value;
                OnPropertyChanged("Label_30");
            }
        }


        private static Calendar _Instance;

        public static Calendar GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Calendar();
            }
            return _Instance;
        }

        public List<string> UpdateCalendar(List<string> retrievedCalendarList)
        {
            DateTime dates;
            string stringDates = "";



            dates = DateTime.Today;


            for (int i = 0; i < 30; i++)
            {

                stringDates = dates.ToString("dd/MM");

                foreach(string date in retrievedCalendarList)
                {
                    if(stringDates == date)
                    {
                        stringDates += " - optaget";
                    }
                }
                updatedCalendarDates.Add(stringDates);

                dates = dates.AddDays(1);
            }
            for (int i = 0; i < 30; i++)
            {
                OnPropertyChanged("Label_" + i + 1);
            }

            return updatedCalendarDates;

        }
    }
}
