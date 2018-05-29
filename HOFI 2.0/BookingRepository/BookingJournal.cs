using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class BookingJournal : INotifyPropertyChanged
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

        string _Goal = "";
        string _TrainingProgram = "";
        string _WeeklyTrainings = "";
        string _TimePerTraining = "";
        string _Notes = "";

        public string Goal
        {
            get
            {
                return _Goal;
            }
            set
            {
                _Goal = value;
                OnPropertyChanged("Goal");
            }
        }

        public string TrainingProgram
        {
            get
            {
                return _TrainingProgram;
            }
            set
            {
                _TrainingProgram = value;
                OnPropertyChanged("TrainingProgram");
            }
        }

        public string WeeklyTrainings
        {
            get
            {
                return _WeeklyTrainings;
            }
            set
            {
                _WeeklyTrainings = value;
                OnPropertyChanged("WeeklyTrainings");
            }
        }

        public string TimePerTraining
        {
            get
            {
                return _TimePerTraining;
            }
            set
            {
                _TimePerTraining = value;
                OnPropertyChanged("TimePerTraining");
            }
        }

        public string Notes
        {
            get
            {
                return _Notes;
            }
            set
            {
                _Notes = value;
                OnPropertyChanged("Notes");
            }
        }

    }
}
