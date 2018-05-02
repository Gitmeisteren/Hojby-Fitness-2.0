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

        string label_1 = "";
        string label_2 = "";
        string label_3 = "";
        string label_4 = "";
        string label_5 = "";
        string label_6 = "";
        string label_7 = "";
        string label_8 = "";
        string label_9 = "";
        string label_10 = "";
        string label_11 = "";
        string label_12 = "";
        string label_13 = "";
        string label_14 = "";
        string label_15 = "";
        string label_16 = "";
        string label_17 = "";
        string label_18 = "";
        string label_19 = "";
        string label_20 = "";
        string label_21 = "";
        string label_22 = "";
        string label_23 = "";
        string label_24 = "";
        string label_25 = "";
        string label_26 = "";
        string label_27 = "";
        string label_28 = "";
        string label_29 = "";
        string label_30 = "";

        public string Label_1
        {
            get
            {
                return label_1;
            }
            set
            {
                label_1 = value;
                OnPropertyChanged("Label 1");
            }
        }
        public string Label_2
        {
            get
            {
                return label_2;
            }
            set
            {
                label_2 = value;
                OnPropertyChanged("Label 2");
            }
        }
        public string Label_3
        {
            get
            {
                return label_3;
            }
            set
            {
                label_3 = value;
                OnPropertyChanged("Label 3");
            }
        }
        public string Label_4
        {
            get
            {
                return label_4;
            }
            set
            {
                label_4 = value;
                OnPropertyChanged("Label 4");
            }
        }
        public string Label_5
        {
            get
            {
                return label_5;
            }
            set
            {
                label_5 = value;
                OnPropertyChanged("Label 5");
            }
        }
        public string Label_6
        {
            get
            {
                return label_6;
            }
            set
            {
                label_6 = value;
                OnPropertyChanged("Label 6");
            }
        }
        public string Label_7
        {
            get
            {
                return label_7;
            }
            set
            {
                label_7 = value;
                OnPropertyChanged("Label 7");
            }
        }
        public string Label_8
        {
            get
            {
                return label_8;
            }
            set
            {
                label_8 = value;
                OnPropertyChanged("Label 8");
            }
        }
        public string Label_9
        {
            get
            {
                return label_9;
            }
            set
            {
                label_9 = value;
                OnPropertyChanged("Label 9");
            }
        }
        public string Label_10
        {
            get
            {
                return label_10;
            }
            set
            {
                label_10 = value;
                OnPropertyChanged("Label 10");
            }
        }
        public string Label_11
        {
            get
            {
                return label_11;
            }
            set
            {
                label_11 = value;
                OnPropertyChanged("Label 11");
            }
        }
        public string Label_12
        {
            get
            {
                return label_12;
            }
            set
            {
                label_12 = value;
                OnPropertyChanged("Label 12");
            }
        }
        public string Label_13
        {
            get
            {
                return label_13;
            }
            set
            {
                label_13 = value;
                OnPropertyChanged("Label 13");
            }
        }
        public string Label_14
        {
            get
            {
                return label_14;
            }
            set
            {
                label_14 = value;
                OnPropertyChanged("Label 14");
            }
        }
        public string Label_15
        {
            get
            {
                return label_15;
            }
            set
            {
                label_15 = value;
                OnPropertyChanged("Label 15");
            }
        }
        public string Label_16
        {
            get
            {
                return label_16;
            }
            set
            {
                label_16 = value;
                OnPropertyChanged("Label 16");
            }
        }
        public string Label_17
        {
            get
            {
                return label_17;
            }
            set
            {
                label_17 = value;
                OnPropertyChanged("Label 17");
            }
        }
        public string Label_18
        {
            get
            {
                return label_18;
            }
            set
            {
                label_18 = value;
                OnPropertyChanged("Label 18");
            }
        }
        public string Label_19
        {
            get
            {
                return label_19;
            }
            set
            {
                label_19 = value;
                OnPropertyChanged("Label 19");
            }
        }
        public string Label_20
        {
            get
            {
                return label_20;
            }
            set
            {
                label_20 = value;
                OnPropertyChanged("Label 20");
            }
        }
        public string Label_21
        {
            get
            {
                return label_21;
            }
            set
            {
                label_21 = value;
                OnPropertyChanged("Label 21");
            }
        }
        public string Label_22
        {
            get
            {
                return label_22;
            }
            set
            {
                label_22 = value;
                OnPropertyChanged("Label 22");
            }
        }
        public string Label_23
        {
            get
            {
                return label_23;
            }
            set
            {
                label_23 = value;
                OnPropertyChanged("Label 23");
            }
        }
        public string Label_24
        {
            get
            {
                return label_24;
            }
            set
            {
                label_24 = value;
                OnPropertyChanged("Label 24");
            }
        }
        public string Label_25
        {
            get
            {
                return label_25;
            }
            set
            {
                label_25 = value;
                OnPropertyChanged("Label 25");
            }
        }
        public string Label_26
        {
            get
            {
                return label_26;
            }
            set
            {
                label_26 = value;
                OnPropertyChanged("Label 26");
            }
        }
        public string Label_27
        {
            get
            {
                return label_27;
            }
            set
            {
                label_27 = value;
                OnPropertyChanged("Label 27");
            }
        }
        public string Label_28
        {
            get
            {
                return label_28;
            }
            set
            {
                label_28 = value;
                OnPropertyChanged("Label 28");
            }
        }
        public string Label_29
        {
            get
            {
                return label_29;
            }
            set
            {
                label_29 = value;
                OnPropertyChanged("Label 29");
            }
        }
        public string Label_30
        {
            get
            {
                return label_30;
            }
            set
            {
                label_30 = value;
                OnPropertyChanged("Label 30");
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
            List<string> updatedCalendarDates = new List<string>();

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

            return updatedCalendarDates;

        }
    }
}
