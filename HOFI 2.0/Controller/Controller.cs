﻿using System;
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
        BookingHandler bookingHandler = BookingHandler.GetInstance(); // what
        Booking booking = new Booking();
        Member member = new Member();
        BookingRepository bookingRepo = new BookingRepository();
        FileExporter fileExporter = new FileExporter();
        SQLDatabaseConnectionPoint _DatabaseCon = new SQLDatabaseConnectionPoint();

        public void ExportToPDF()
        {
            fileExporter.ExportToPDF(Tb_MemberNumber, Tb_Name, Tb_Goal, Tb_TrainingProgram,Tb_WeeklyTrainings, Tb_TimePerTraining, Tb_Notes);
        }

        Calendar calendar = Calendar.GetInstance();
        LoginHandler loginHandler = new LoginHandler();
        private static Controller _Instance;
        private string _LoginResponse;

        private string _ReturnMessage;

        public Booking NewBooking { get; set; }
        public Member NewMember { get; set; }

        public void SearchForMember()
        {
          ReturnMessage = _DatabaseCon.SearchForMember(NewBooking, NewMember);
        }

        public Calendar CalendarDates { get; set; }
        public string LoginResponse
        {
            get
            {
                return _LoginResponse;
            }
            set
            {
                _LoginResponse = value;
                OnPropertyChanged("LoginResponse");
            }
        }
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
        //Label properties for calendar
        #region
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

        public string Label_9
        {
            get
            {
                return _Label9;
            }
            set
            {
                _Label9 = value;
                OnPropertyChanged("Label_9");
            }
        }
        public string Label_10
        {
            get
            {
                return _Label10;
            }
            set
            {
                _Label10 = value;
                OnPropertyChanged("Label_10");
            }
        }

        public string Label_11
        {
            get
            {
                return _Label11;
            }
            set
            {
                _Label11 = value;
                OnPropertyChanged("Label_11");
            }
        }



        public string Label_12
        {
            get
            {
                return _Label12;
            }
            set
            {
                _Label12 = value;
                OnPropertyChanged("Label_12");
            }
        }
        public string Label_13
        {
            get
            {
                return _Label13;
            }
            set
            {
                _Label13 = value;
                OnPropertyChanged("Label_13");
            }
        }
        public string Label_14
        {
            get
            {
                return _Label14;
            }
            set
            {
                _Label14 = value;
                OnPropertyChanged("Label_14");
            }
        }
        public string Label_15
        {
            get
            {
                return _Label15;
            }
            set
            {
                _Label15 = value;
                OnPropertyChanged("Label_15");
            }
        }

        public string Label_16
        {
            get
            {
                return _Label16;
            }
            set
            {
                _Label16 = value;
                OnPropertyChanged("Label_16");
            }
        }

        public string Label_17
        {
            get
            {
                return _Label17;
            }
            set
            {
                _Label17 = value;
                OnPropertyChanged("Label_17");
            }
        }

        public string Label_18
        {
            get
            {
                return _Label18;
            }
            set
            {
                _Label18 = value;
                OnPropertyChanged("Label_18");
            }
        }

        public string Label_19
        {
            get
            {
                return _Label19;
            }
            set
            {
                _Label19 = value;
                OnPropertyChanged("Label_19");
            }
        }

        public string Label_20
        {
            get
            {
                return _Label20;
            }
            set
            {
                _Label20 = value;
                OnPropertyChanged("Label_20");
            }
        }
        public string Label_21
        {
            get
            {
                return _Label21;
            }
            set
            {
                _Label21 = value;
                OnPropertyChanged("Label_21");
            }
        }
        public string Label_22
        {
            get
            {
                return _Label22;
            }
            set
            {
                _Label22 = value;
                OnPropertyChanged("Label_22");
            }
        }
        public string Label_23
        {
            get
            {
                return _Label23;
            }
            set
            {
                _Label23 = value;
                OnPropertyChanged("Label_23");
            }
        }

        public string Label_24
        {
            get
            {
                return _Label24;
            }
            set
            {
                _Label24 = value;
                OnPropertyChanged("Label_24");
            }
        }
        public string Label_25
        {
            get
            {
                return _Label25;
            }
            set
            {
                _Label25 = value;
                OnPropertyChanged("Label_25");
            }
        }
        public string Label_26
        {
            get
            {
                return _Label26;
            }
            set
            {
                _Label26 = value;
                OnPropertyChanged("Label_26");
            }
        }
        public string Label_27
        {
            get
            {
                return _Label27;
            }
            set
            {
                _Label27 = value;
                OnPropertyChanged("Label_27");
            }
        }
        public string Label_28
        {
            get
            {
                return _Label28;
            }
            set
            {
                _Label28 = value;
                OnPropertyChanged("Label_28");
            }
        }

        public string Label_29
        {
            get
            {
                return _Label29;
            }
            set
            {
                _Label29 = value;
                OnPropertyChanged("Label_29");
            }
        }

        public string Label_30
        {
            get
            {
                return _Label30;
            }
            set
            {
                _Label30 = value;
                OnPropertyChanged("Label_30");
            }
        }
        #endregion
        //Properties for journal
        #region
        string _TbMemberNumber = "";
        string _TbName = "";
        string _TbGoal = "";
        string _TbTrainingProgram = "";
        string _TbWeeklyTrainings = "";
        string _TbTimePerTraining = "";
        string _TbNotes = "";

        public string Tb_MemberNumber
        {
            get
            {
                return _TbMemberNumber;
            }
            set
            {
                _TbMemberNumber = value;
                OnPropertyChanged("Tb_MemberNumber");
            }
        }
        public string Tb_Name
        {
            get
            {
                return _TbName;
            }
            set
            {
                _TbName = value;
                OnPropertyChanged("Tb_Name");
            }
        }

        public string Tb_Goal
        {
            get
            {
                return _TbGoal;
            }
            set
            {
                _TbGoal = value;
                OnPropertyChanged("Tb_Goal");
            }
        }
        public string Tb_TrainingProgram
        {
            get
            {
                return _TbTrainingProgram;
            }
            set
            {
                _TbTrainingProgram = value;
                OnPropertyChanged("Tb_TrainingProgram");
            }
        }
        public string Tb_WeeklyTrainings
        {
            get
            {
                return _TbWeeklyTrainings;
            }
            set
            {
                _TbWeeklyTrainings = value;
                OnPropertyChanged("Tb_WeeklyTrainings");
            }
        }
        public string Tb_TimePerTraining
        {
            get
            {
                return _TbTimePerTraining;
            }
            set
            {
                _TbTimePerTraining = value;
                OnPropertyChanged("Tb_TimePerTraining");
            }
        }
        public string Tb_Notes
        {
            get
            {
                return _TbNotes;
            }
            set
            {
                _TbNotes = value;
                OnPropertyChanged("Tb_Notes");
            }
        }
        
        #endregion

    
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
            List<string> updatedCalendarDates = new List<string>(); 
           updatedCalendarDates = bookingHandler.UpdateCalendar();

            
            Label_1 = updatedCalendarDates[0];
            Label_2 = updatedCalendarDates[1];
            Label_3 = updatedCalendarDates[2];
            Label_4 = updatedCalendarDates[3];
            Label_5 = updatedCalendarDates[4];

            Label_6 = updatedCalendarDates[5];
            Label_7 = updatedCalendarDates[6];
            Label_8 = updatedCalendarDates[7];
            Label_9 = updatedCalendarDates[8];
            Label_10 = updatedCalendarDates[9];

            Label_11 = updatedCalendarDates[10];
            Label_12 = updatedCalendarDates[11];
            Label_13 = updatedCalendarDates[12];
            Label_14 = updatedCalendarDates[13];
            Label_15 = updatedCalendarDates[14];

            Label_16 = updatedCalendarDates[15];
            Label_17 = updatedCalendarDates[16];
            Label_18 = updatedCalendarDates[17];
            Label_19 = updatedCalendarDates[18];
            Label_20 = updatedCalendarDates[19];

            Label_21 = updatedCalendarDates[20];
            Label_22 = updatedCalendarDates[21];
            Label_23 = updatedCalendarDates[22];
            Label_24 = updatedCalendarDates[23];
            Label_25 = updatedCalendarDates[24];

            Label_26 = updatedCalendarDates[25];
            Label_27 = updatedCalendarDates[26];
            Label_28 = updatedCalendarDates[27];
            Label_29 = updatedCalendarDates[28];
            Label_30 = updatedCalendarDates[29];
        }
        public void CheckLogin(string password, string memberNumber)
        {
            LoginResponse = loginHandler.GetLoginInformation(password, memberNumber);

        }
    }
}