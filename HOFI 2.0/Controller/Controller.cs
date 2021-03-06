﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class Controller : INotifyPropertyChanged
    {
       
        #region Shift properties for ShiftWindow
        string _InstructorID = "";
        string _StartDate = "";
        string _EndDate = "";
        public string ShiftListInstructorID
        {
            get
            {
                return _InstructorID;
            }
            set
            {
                _InstructorID = value;
                OnPropertyChanged("ShiftListInstructorID");
            }
        }
        public string ShiftStartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
                OnPropertyChanged("ShiftStartDate");
            }
        }
        public string ShiftEndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
                OnPropertyChanged("ShiftEndDate");
            }
        }
        
        #endregion

        #region Instances
        BookingHandler _BookingHandler = BookingHandler.GetInstance();
        Booking _Booking = new Booking();
        Member _Member = new Member();
        StatisticHandler _StatisticHandler = StatisticHandler.GetInstance();
        BookingRepository _BookingRepo = BookingRepository.GetInstance();
        FileExporter _FileExporter = new FileExporter();
        ShiftHandler _ShiftHandler = ShiftHandler.GetInstance();
        SQLDatabaseConnectionPoint _DatabaseCon = new SQLDatabaseConnectionPoint();
        LoginHandler _LoginHandler = new LoginHandler();
        Calendar _Calendar = Calendar.GetInstance();
        #endregion


        #region Privates
        int _NonMemberPhoneNumber = 0;
        string _NonMemberName = "";
        private string _LoginCredentialsPassword;
        private string _LoginCredentials;
        private static Controller _Instance;
        private string _ReturnMessageShiftWindow;
        private List<Instructor> _InstructorsList = new List<Instructor>();
        private string _ReturnMessageBookSessionWindow;
        private string _ReturnMessageRegisterShiftWindow;
        private string _ReturnMessageMemberJournals;
        private string _ReturnMessageMemberOverlayWindow;
        private string _ReturnMessageInstructorsWindow;
        private string _ReturnMessageEditInstructorsWindow;
        private string _ReturnMessageBookingWindow;
        private string _ReturnMessageAdminInstructorWindow;
        private string _ReturnMessageLoginWindow;
        private string _ReturnMessageNonMemberBookingWindow;
        #endregion


        #region Properties

        public string NonMemberName
        {
            get
            {
                return _NonMemberName;
            }
            set
            {
                _NonMemberName = value;
                OnPropertyChanged("NonMemberName");
            }
        }
        public int NonMemberPhoneNumber
        {
            get
            {
                return _NonMemberPhoneNumber;
            }
            set
            {
                _NonMemberPhoneNumber = value;
                OnPropertyChanged("NonMemberPhoneNumber");
            }
        }
        public string ReturnMessageNonMemberBookingWindow
        {
            get
            {
                return _ReturnMessageNonMemberBookingWindow;
            }
            set
            {
                _ReturnMessageNonMemberBookingWindow = value;
                OnPropertyChanged("ReturnMessageNonMemberBookingWindow");
            }
        }
        public string ReturnMessageLoginWindow
        {
            get
            {
                return _ReturnMessageLoginWindow;
            }
            set
            {
                _ReturnMessageLoginWindow = value;
                OnPropertyChanged("ReturnMessageLoginWindow");
            }
        }
        public string ReturnMessageShiftWindow
        {
            get
            {
                return _ReturnMessageShiftWindow;
            }
            set
            {
                _ReturnMessageShiftWindow = value;
                OnPropertyChanged("ReturnMessageShiftWindow");
            }
        }
        public string ReturnMessageBookSessionWindow
        {
            get
            {
                return _ReturnMessageBookSessionWindow;
            }
            set
            {
                _ReturnMessageBookSessionWindow = value;
                OnPropertyChanged("ReturnMessageBookSessionWindow");
            }
        }
        public string ReturnMessageRegisterShiftWindow
        {
            get
            {
                return _ReturnMessageRegisterShiftWindow;
            }
            set
            {
                _ReturnMessageRegisterShiftWindow = value;
                OnPropertyChanged("ReturnMessageRegisterShiftWindow");
            }
        }
        public string ReturnMessageMemberOverlayWindow
        {
            get
            {
                return _ReturnMessageMemberOverlayWindow;
            }
            set
            {
                _ReturnMessageMemberOverlayWindow = value;
                OnPropertyChanged("ReturnMessageMemberOverlayWindow");
            }
        }
        public string ReturnMessageMemberJournals
        {
            get
            {
                return _ReturnMessageMemberJournals;
            }
            set
            {
                _ReturnMessageMemberJournals = value;
                OnPropertyChanged("ReturnMessageMemberJournals");
            }
        }
        public string ReturnMessageInstructorsWindow
        {
            get
            {
                return _ReturnMessageInstructorsWindow;
            }
            set
            {
                _ReturnMessageInstructorsWindow = value;
                OnPropertyChanged("ReturnMessageInstructorsWindow");
            }
        }
        public string ReturnMessageEditInstructorsWindow
        {
            get
            {
                return _ReturnMessageEditInstructorsWindow;
            }
            set
            {
                _ReturnMessageEditInstructorsWindow = value;
                OnPropertyChanged("ReturnMessageEditInstructorsWindow");
            }
        }
        public string ReturnMessageBookingWindow
        {
            get
            {
                return _ReturnMessageBookingWindow;
            }
            set
            {
                _ReturnMessageBookingWindow = value;
                OnPropertyChanged("ReturnMessageBookingWindow");
            }
        }
        public string ReturnMessageAdminInstructorWindow
        {
            get
            {
                return _ReturnMessageAdminInstructorWindow;
            }
            set
            {
                _ReturnMessageAdminInstructorWindow = value;
                OnPropertyChanged("ReturnMessageAdminInstructorWindow");
            }
        }
        public string LoginCredentialsPassword
        {
            get
            {
                return _LoginCredentialsPassword;
            }
            set
            {
                _LoginCredentialsPassword = value;
                OnPropertyChanged("_LoginCredentialsPassword");
            }
        }
        public string LoginCredentials
        {
            get
            {
                return _LoginCredentials;
            }
            set
            {
                _LoginCredentials = value;
                OnPropertyChanged("_LoginCredentials");
            }
        } 
        public Booking NewBooking { get; set; }
        public Member NewMember { get; set; }
        public Shift Shift { get; set; }
        public Instructor Instructor { get; set; }
        public List<string> Cmb_GoalChoices { get; } = new List<string>() { "Styrketræning", "Vægttab", "Opstramning", "Konditionstræning", "Kom-Godt-Igang" };
        public List<string> Cmb_TypeChoices { get; } = new List<string>() { "Fitness", "Spinning" };
        public List<Instructor> InstructorsList
        {
            get
            {
                return _InstructorsList;
            }
            set
            {
                _InstructorsList = value;
                OnPropertyChanged("InstructorsList");
            }
        }

        public Calendar CalendarDates { get; set; }
        
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
        string _TbMemberNumber;
        string _TbName;
        string _TbGoal;
        string _ChbTrainingProgram;
        string _TbWeeklyTrainings;
        string _TbTimePerTraining;
        string _TbNotes;
     

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
        public string Chb_TrainingProgram
        {
            get
            {
                _ChbTrainingProgram = "Ja";
                return _ChbTrainingProgram;
            }
            set
            {
                _ChbTrainingProgram = value;
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
        #endregion
        
      
        #region INotifyPropertyChanged

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


        public Controller()
        {
            NewBooking = new Booking();
            _BookingRepo = BookingRepository.GetInstance();
            NewMember = new Member();
            CalendarDates = Calendar.GetInstance();
            Shift = new Shift();
            Instructor = new Instructor();
            _StatisticHandler = StatisticHandler.GetInstance();
            StatisticRepoUpdate();
            IntitialRepoUpdate();
            _StatisticHandler.AddToExcellFromStatisticRepo();

        }
        public void DeleteInstructor()
        {
            ReturnMessageEditInstructorsWindow = _DatabaseCon.DeleteInstructor(Instructor);
            ShowInstructors();
        }
        public void RegisterNonMemberBooking()
        {
           ReturnMessageNonMemberBookingWindow = _DatabaseCon.RegisterNonMemberBooking(NonMemberPhoneNumber);
        }
        public static Controller GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Controller();
            }
            return _Instance;
        }
        public void CreateNonMember()
        {
          ReturnMessageNonMemberBookingWindow = _DatabaseCon.CreateNonMember(NonMemberPhoneNumber, NonMemberName);
        }
        public void ResetLoginCredentials()
        {
            LoginCredentialsPassword = "";


            OnPropertyChanged(LoginCredentialsPassword);

        }
        public void CreateJournal(string goal)
        {

            BookingJournal _BookingJournal = new BookingJournal();
            _BookingJournal.Goal = goal;
            _BookingJournal.TrainingProgram = Chb_TrainingProgram;
            _BookingJournal.WeeklyTrainings = Tb_WeeklyTrainings;
            _BookingJournal.TimePerTraining = Tb_TimePerTraining;
            _BookingJournal.Notes = Tb_Notes;

            _FileExporter.CreateJournal(NewBooking, NewMember, _BookingJournal);

            SaveStatistics(goal);
        }
        public void AddInstructor()
        {
           ReturnMessageEditInstructorsWindow = _DatabaseCon.AddInstructor(Instructor);
            ShowInstructors();
        }
        public void UpdatePhoneNumber()
        {
            string _IDClone = "";
            if(LoginCredentials == "hofi353")
            {
                _IDClone = Instructor.InstructorID;
                ReturnMessageEditInstructorsWindow = _DatabaseCon.UpdatePhoneNumber(Instructor, _IDClone);
            }
            else
            {
                _IDClone = LoginCredentials;
                ReturnMessageEditInstructorsWindow = _DatabaseCon.UpdatePhoneNumber(Instructor, _IDClone);
            }
            ShowInstructors();
            
        }
        public void UpdateEmail()
        {
            string _IDClone = "";
            if(LoginCredentials == "hofi353")
            {

                _IDClone = Instructor.InstructorID;
                ReturnMessageEditInstructorsWindow = _DatabaseCon.UpdateEmail(Instructor, _IDClone);
            }
            else
            {
                _IDClone = LoginCredentials;
                ReturnMessageEditInstructorsWindow = _DatabaseCon.UpdateEmail(Instructor, _IDClone);
            }
            ShowInstructors();
        }
        public void SearchForMember()
        {
          ReturnMessageMemberOverlayWindow = _DatabaseCon.SearchForMember(NewBooking, NewMember);
        }
        public void ShowInstructors()
        {       
         InstructorsList = _DatabaseCon.ShowInstructors();
        }
        public void BookSession()
        {

            ReturnMessageBookSessionWindow = _BookingHandler.BookSession(NewBooking);
        
        }
        public void CreateNewMember()
        {
            _BookingHandler.CreateNewMember(NewMember, NewBooking);
        }
         public void IntitialRepoUpdate()
        {
            
            _BookingHandler.IntitialRepoUpdate();
        }
        public void StatisticRepoUpdate()
        {
            _StatisticHandler.StatisticRepoUpdate();
        }
        public void UpdateCalendar()
        {
            List<string> updatedCalendarDates = new List<string>(); 
           updatedCalendarDates = _BookingHandler.UpdateCalendar();

            
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
        public void CheckLogin()
        {
            ReturnMessageLoginWindow = _LoginHandler.GetLoginInformation(LoginCredentials, LoginCredentialsPassword);

        }
        public void RegisterShift(string shiftType)
        {

            string _IDClone;
            if(LoginCredentials == "hofi353" || LoginCredentials == "hofi0")
            {
                DateTime dateToday = DateTime.Parse(Shift.Date);
                _IDClone = Instructor.InstructorID;
                ReturnMessageRegisterShiftWindow = _ShiftHandler.RegisterShift(Shift, Instructor, shiftType, _IDClone, dateToday);
            }
            else
            {
                 
                DateTime dateToday = DateTime.Today;
                _IDClone = LoginCredentials;
                ReturnMessageRegisterShiftWindow = _ShiftHandler.RegisterShift(Shift, Instructor, shiftType, _IDClone, dateToday);
            }
            
        }
        public void ShowShiftList()
        {
            ReturnMessageShiftWindow = _ShiftHandler.ShiftList(Shift, Instructor, ShiftListInstructorID, ShiftStartDate, ShiftEndDate);
        }
        public void ExportShiftList()
        {
            _ShiftHandler.ExportShiftList(ReturnMessageShiftWindow, ShiftStartDate, ShiftEndDate);
            ReturnMessageShiftWindow = ReturnMessageShiftWindow + "\n Fil eksporteret til skrivebordet under mappen 'HOFI'.";
        }
        public void SaveStatistics(string goal)
        {
            DateTime _DayOfJournalCreation = DateTime.Today;
            
            Statistic _Statistic = new Statistic(NewMember.Age,_DayOfJournalCreation.ToShortDateString(), goal);

            string _ExceptionMessage = _StatisticHandler.AddStatisticToDB(_Statistic);
            if ( _ExceptionMessage == "") {
                _StatisticHandler.StatisticRepoUpdate();
                _StatisticHandler.AddToExcellFromStatisticRepo();
            }
        }
    }
}