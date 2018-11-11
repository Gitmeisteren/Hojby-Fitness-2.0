using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Mail;


namespace Model
{
    public class SQLDatabaseConnectionPoint
    {
        private static string _ConnectionString = "Server= den1.mssql5.gear.host; Database= hofi; User ID = hofi; Password= Qg9OG4l~v-06;";
        public string BookSession(Booking NewBooking)
        {
            DateTime NewBookingDate = DateTime.Parse(NewBooking.BookingDate.ToString());
            string returnMessage = "";
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {

                    con.Open();

                    SqlCommand _BookSession = new SqlCommand("spRegisterMemberBooking", con);
                    _BookSession.CommandType = CommandType.StoredProcedure;
                    _BookSession.Parameters.Add(new SqlParameter("@I_MemberID", NewBooking.MemberNumber));
                    _BookSession.Parameters.Add(new SqlParameter("@I_Date", NewBookingDate));

                    _BookSession.ExecuteNonQuery();

                }
                catch (SqlException e)
                {
                    returnMessage = e.Message;
                }
                catch (FormatException f)
                {

                    returnMessage += f.Message;
                }
                if (returnMessage == "")
                {
                    returnMessage = "Booking er oprettet.";
                }
                else if (returnMessage != "")
                {
                    returnMessage += " Booking er ikke oprettet.";
                }
                return returnMessage;
            }
        }

        public string CreateNonMember(int nonMemberPhoneNumber, string nonMemberName)
        {
            string errorMsg = "";
            string returnMsg = "";
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {

                try
                {


                    con.Open();

                    SqlCommand _AddNonMember = new SqlCommand("spCreateNonMember", con);
                    _AddNonMember.CommandType = CommandType.StoredProcedure;
                    _AddNonMember.Parameters.Add(new SqlParameter("@I_PhoneNumber", nonMemberPhoneNumber.ToString()));
                    _AddNonMember.Parameters.Add(new SqlParameter("@I_Name", nonMemberName));

                    _AddNonMember.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    if (e != null)
                    {
                        errorMsg = "FEJL: Ikke-medlem er ikke oprettet \n" + e.Message;

                    }
                }
                catch (FormatException e1)
                {
                    if (e1 != null)
                    {
                        errorMsg = "FEJL: Ikke-medlem er ikke oprettet \n" + e1.Message;

                    }
                }
                if (errorMsg == "")
                {
                    returnMsg = "Ikke-medlemmet " + nonMemberName + " er tilføjet";

                }
                else
                {
                    returnMsg = errorMsg;
                }

            }
            return returnMsg;
        }

        public string RegisterNonMemberBooking(int nonMemberPhoneNumber)
        {
            string errorMsg = "";
            string returnMsg = "";
            List<int> _IsEligibleForBooking = new List<int>();
            _IsEligibleForBooking = CheckIfMaximumBookingsReached(nonMemberPhoneNumber);

                if (_IsEligibleForBooking.Count >= 2)
                    {
                returnMsg = "Ikke-medlemmet har allerede haft to prøvetimer";
                    }
                else
                {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                    {
                    try
                    {

                        con.Open();

                        SqlCommand _RegisterNonMemberBooking = new SqlCommand("spRegisterNonMemberBooking", con);
                        _RegisterNonMemberBooking.CommandType = CommandType.StoredProcedure;
                        _RegisterNonMemberBooking.Parameters.Add(new SqlParameter("@I_NonMemberPhone", nonMemberPhoneNumber));

                        _RegisterNonMemberBooking.ExecuteNonQuery();

                    }
                    catch (SqlException e)
                    {
                        errorMsg = e.Message;
                    }
                    catch (FormatException f)
                    {

                        errorMsg += f.Message;
                    }
                    if (errorMsg == "")
                    {
                        returnMsg = "Booking er oprettet.";
                    }
                    else if (errorMsg != "")
                    {
                        returnMsg += " Booking er ikke oprettet.";
                    }
                }
           
            }
                return returnMsg;
        }

        private List<int> CheckIfMaximumBookingsReached(int nonMemberPhoneNumber)
        {
            int _PhoneNumberClone = 0;
            _PhoneNumberClone = nonMemberPhoneNumber;
            List<int> _NumberOfBookings = new List<int>();
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {

                try
                {

                    con.Open();

                    SqlCommand _CheckIfMaximumBookingsReached = new SqlCommand("spCheckifMaximumBookingsReached", con);
                    _CheckIfMaximumBookingsReached.CommandType = System.Data.CommandType.StoredProcedure;
                    _CheckIfMaximumBookingsReached.Parameters.Add(new SqlParameter("@I_NonMemberPhoneNumber", nonMemberPhoneNumber));


                    _CheckIfMaximumBookingsReached.ExecuteNonQuery();

                    SqlDataReader reader = _CheckIfMaximumBookingsReached.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _PhoneNumberClone = int.Parse(reader["NonMemberPhone"].ToString());
                            _NumberOfBookings.Add(_PhoneNumberClone);
                        }
                    }
                    reader.Close();

                }
                catch (SqlException e)
                {

                }
                return _NumberOfBookings;
            }
        }

        public string UpdatePhoneNumber(Instructor instructor, string _IDClone)
        {
            string _ErrorMsg = "";
            string _ReturnMsg = "";

            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {

                try
                {

                    con.Open();

                    SqlCommand _UpdatePhoneNumber = new SqlCommand("spUpdatePhoneNumber", con);
                    _UpdatePhoneNumber.CommandType = CommandType.StoredProcedure;
                    _UpdatePhoneNumber.Parameters.Add(new SqlParameter("@I_InstructorID", _IDClone));
                    _UpdatePhoneNumber.Parameters.Add(new SqlParameter("@I_TlfNr", instructor.PhoneNumber));

                    _UpdatePhoneNumber.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    if (e != null)
                    {
                        _ErrorMsg = "FEJL: Nummeret er ikke opdateret. \n" + e.Message;

                    }
                }
                catch (FormatException e1)
                {
                    if (e1 != null)
                    {
                        _ErrorMsg = "FEJL: Nummeret er ikke opdateret. \n" + e1.Message;

                    }
                }
                if (_ErrorMsg == "")
                {
                    _ReturnMsg = "Nummeret er opdateret til: " + instructor.PhoneNumber;

                }
                else
                {
                    _ReturnMsg = _ErrorMsg;
                }
            }
            return _ReturnMsg;
        }

        public string UpdateEmail(Instructor instructor, string _IDClone)
        {
            string _ErrorMsg = "";
            string _ReturnMsg = "";

            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {

                try
                {

                    con.Open();

                    SqlCommand _ChangeEmail = new SqlCommand("spChangeMail", con);
                    _ChangeEmail.CommandType = System.Data.CommandType.StoredProcedure;
                    _ChangeEmail.Parameters.Add(new SqlParameter("@I_InstructorID", _IDClone));
                    _ChangeEmail.Parameters.Add(new SqlParameter("@I_EMail", instructor.Mail));

                    _ChangeEmail.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    if (e != null)
                    {
                        _ErrorMsg = "FEJL: Email er ikke opdateret. \n" + e.Message;

                    }
                }
                catch (FormatException e1)
                {
                    if (e1 != null)
                    {
                        _ErrorMsg = "FEJL: Email er ikke opdateret. \n" + e1.Message;

                    }
                }
                if (_ErrorMsg == "")
                {
                    _ReturnMsg = "Emailen er opdateret til: " + instructor.Mail;

                }
                else
                {
                    _ReturnMsg = _ErrorMsg;
                }
            }
            return _ReturnMsg;
        }

        public string DeleteInstructor(Instructor Instructor)
        {

            string _ReturnMsg = "";

            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand _DeleteInstructor = new SqlCommand("spDeleteInstructor", con);
                    _DeleteInstructor.CommandType = CommandType.StoredProcedure;
                    _DeleteInstructor.Parameters.Add(new SqlParameter("@I_InstructorID", Instructor.InstructorID));

                    _DeleteInstructor.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    if (e != null)
                    {
                        _ReturnMsg = e.Message;
                    }

                }
                catch (FormatException e1)
                {
                    if (e1 != null)
                    {
                        _ReturnMsg += e1.Message;
                    }

                }
                if (_ReturnMsg == "")
                {
                    _ReturnMsg = Instructor.InstructorID + " er nu slettet.";
                }
                else
                {
                    _ReturnMsg += " - Prøv igen";
                }
                return _ReturnMsg;
            }
        }

        public string SearchForMember(Booking NewBooking, Member NewMember)
        {

            string _ReturnMessage = "";
            string _MemberNumberClone = "";
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {

                try
                {

                    con.Open();

                    SqlCommand _GetMemberInfo = new SqlCommand("spGetMemberInfo", con);
                    _GetMemberInfo.CommandType = System.Data.CommandType.StoredProcedure;
                    _GetMemberInfo.Parameters.Add(new SqlParameter("@I_MemberID", NewBooking.MemberNumber));
                    

                    _GetMemberInfo.ExecuteNonQuery();

                    SqlDataReader reader = _GetMemberInfo.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            NewMember.Name = reader["Name"].ToString();
                            _MemberNumberClone = reader["MemberID"].ToString();
                            NewMember.Age = int.Parse(reader["Age"].ToString());
                        }
                    }
                    reader.Close();

                }
                catch (SqlException e)
                {
                    _ReturnMessage = e.Message;
                }
                catch (FormatException f)
                {
                    _ReturnMessage += f.Message;
                }
                if (_MemberNumberClone == "")
                {
                    _ReturnMessage += "Kunne ikke finde " + NewBooking.MemberNumber + " - Prøv igen";
                }
            }
            return _ReturnMessage;
        }

        public string AddInstructor(Instructor instructor)
        {
            string errorMsg = "";
            string returnMsg = "";
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {

                try
                {


                    con.Open();

                    SqlCommand _AddInstructor = new SqlCommand("spAddInstructor", con);
                    _AddInstructor.CommandType = System.Data.CommandType.StoredProcedure;
                    _AddInstructor.Parameters.Add(new SqlParameter("@I_InstructorID", instructor.InstructorID));
                    _AddInstructor.Parameters.Add(new SqlParameter("@Navn", instructor.Name));
                    _AddInstructor.Parameters.Add(new SqlParameter("@Email", instructor.Mail));
                    _AddInstructor.Parameters.Add(new SqlParameter("@Ansat", instructor.HireDate));
                    _AddInstructor.Parameters.Add(new SqlParameter("@I_TlfNr", instructor.PhoneNumber));

                    _AddInstructor.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    if (e != null)
                    {
                        errorMsg = "FEJL: Instruktør er ikke oprettet \n" + e.Message;

                    }
                }
                catch (FormatException e1)
                {
                    if (e1 != null)
                    {
                        errorMsg = "FEJL: Instruktør er ikke oprettet \n" + e1.Message;

                    }
                }
                if (errorMsg == "")
                {
                    returnMsg = "Instruktøren " + instructor.Name + " er tilføjet";

                }
                else
                {
                    returnMsg = errorMsg;
                }

            }
            return returnMsg;
        }

        public List<Booking> InitialRepoUpdate()
        {
            DateTime tempDateHolder;
            List<Booking> bookingRepo = new List<Booking>();
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand _BookingRepoUpdate = new SqlCommand("spInitialBookingRepoUpdate", con);

                    SqlDataReader reader = _BookingRepoUpdate.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking();
                            booking.BookingID = int.Parse(reader["BookingID"].ToString());
                            tempDateHolder = DateTime.Parse(reader["Date"].ToString());
                            booking.BookingDate = tempDateHolder.ToString("dd-MM-yyyy");
                            booking.MemberNumber = reader["MemberID"].ToString();

                            bookingRepo.Add(booking);
                        }
                    }
                    reader.Close();
                }
                catch (SqlException e)
                {

                }
            }

            return bookingRepo;
        }

        public void CreateNewMember(Member newMember, Booking NewBooking)
        {
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand _CreateMember = new SqlCommand("spCreateMember", con);
                    _CreateMember.CommandType = System.Data.CommandType.StoredProcedure;
                    _CreateMember.Parameters.Add(new SqlParameter("@I_MemberID", NewBooking.MemberNumber));
                    _CreateMember.Parameters.Add(new SqlParameter("@I_Name", newMember.Name));
                    _CreateMember.Parameters.Add(new SqlParameter("@I_PhoneNumber", newMember.PhoneNumber));
                    _CreateMember.Parameters.Add(new SqlParameter("@I_Email", newMember.Email));
                    _CreateMember.Parameters.Add(new SqlParameter("@I_Age", newMember.Age));
                    _CreateMember.ExecuteNonQuery();
                }
                catch (SqlException e)
                {

                }
            }
        }
        public string RetrieveLoginInformation(string LoginCredentialsPassword, string LoginCredentials)
        {
            int truePasswordCounter = 0;
            string accesLogin = "";
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand _RetrievePassword = new SqlCommand("spGetPasswordInformation", con);
                    _RetrievePassword.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = _RetrievePassword.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            truePasswordCounter = 0;
                            if (LoginCredentialsPassword == reader["Kodeord"].ToString())
                            {
                                truePasswordCounter++;
                            }
                            if (LoginCredentials == reader["Medlemsnr"].ToString())
                            {
                                truePasswordCounter++;
                            }
                            if (truePasswordCounter == 2)
                            {
                                accesLogin = "Godkendt";
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    accesLogin = e.ToString();
                }
                return accesLogin;
            }
        }
        internal List<Statistic> UpdateStatistic()
        {

            DateTime tempDateHolder;
            List<Statistic> StatisticRepo = new List<Statistic>();
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand _StatisticRepoUpdate = new SqlCommand("spGetStatistic", con);

                    SqlDataReader reader = _StatisticRepoUpdate.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Statistic statistic = new Statistic();
                            statistic.Age = int.Parse(reader["Age"].ToString());
                            tempDateHolder = DateTime.Parse(reader["TrainingDate"].ToString());
                            statistic.Date = tempDateHolder.ToString("dd-MM-yyyy");
                            statistic.Type = reader["TrainingType"].ToString();

                            StatisticRepo.Add(statistic);
                        }
                    }
                    reader.Close();
                }
                catch (SqlException e)
                {

                }
            }

            return StatisticRepo;
        }

        public string AddStatisticToDB(Statistic statistic)
        {
            DateTime _StatisticDate = DateTime.Parse(statistic.Date.ToString());
            string _ExceptionHolder = "";
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand _UpdateStatistic = new SqlCommand("spUpdateStatistic", con);
                    _UpdateStatistic.CommandType = System.Data.CommandType.StoredProcedure;
                    _UpdateStatistic.Parameters.Add(new SqlParameter("@I_Age", statistic.Age));
                    _UpdateStatistic.Parameters.Add(new SqlParameter("@I_TrainingType", statistic.Type));
                    _UpdateStatistic.Parameters.Add(new SqlParameter("@I_TrainingDate", _StatisticDate));
                    _UpdateStatistic.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    _ExceptionHolder = e.ToString();
                }
            }
            return _ExceptionHolder;

        }

        public string GetMail(string _IDClone, string date)
        {
            string instructorEmail = "";
            string ifExceptionMessage = "";

            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {

                    con.Open();

                    SqlCommand _GetEmploymentMail = new SqlCommand("spGetMail", con);
                    _GetEmploymentMail.CommandType = System.Data.CommandType.StoredProcedure;
                    _GetEmploymentMail.Parameters.Add(new SqlParameter("@Medlemsnr", _IDClone));

                    SqlDataReader reader = _GetEmploymentMail.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            instructorEmail = reader["Email"].ToString();
                        }
                    }
                }
                catch (SqlException m)
                {
                    ifExceptionMessage = "FEJL: " + m.Message;

                }


                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);

                    mail.From = new MailAddress("hofiregistrering@gmail.com");
                    mail.To.Add(instructorEmail);
                    mail.Subject = "Kvittering for registrering af vagt";
                    mail.Body = "Din vagt er nu registreret for datoen " + date;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("Hofiregistrering@gmail.com", "hsgfitness");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);

                }
                catch (Exception e)
                {
                    ifExceptionMessage = "Der skete en uventet fejl, mailen er ikke sendt. Fejlkode: " + e.Message;
                }

                return ifExceptionMessage;


            }
        }

        public bool CheckDate(string _IDClone)
        {
            List<string> _InstructorRegistration = new List<string>();
            bool _DateAlreadyRegistered = false;
            DateTime _CheckIfDateIsToday;
            string _Date = "";
            string _InstructorID = "";
            

            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
               
                    con.Open();

                    SqlCommand _CheckifDateRegistered = new SqlCommand("spCheckDate", con);
                    _CheckifDateRegistered.CommandType = CommandType.StoredProcedure;
                    _CheckifDateRegistered.Parameters.Add(new SqlParameter("@I_InstructorID", _IDClone));


                SqlDataReader reader = _CheckifDateRegistered.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                        _InstructorID = reader["Medlemsnr"].ToString();
                            _Date = reader["Dato"].ToString();
                        _CheckIfDateIsToday = DateTime.Parse(_Date);
                        if (DateTime.Today == _CheckIfDateIsToday && _InstructorID == _IDClone)
                        {
                        _InstructorRegistration.Add(_Date);
                        }
                        
                        }
                    }
                if (_InstructorRegistration.Count == 1)
                {
                    _DateAlreadyRegistered = false;
                    _InstructorRegistration.RemoveAt(0);
                }
                else if (_InstructorRegistration.Count == 0)
                {
                    _DateAlreadyRegistered = true;
                   
                    }
                return _DateAlreadyRegistered;

            }
        } 
        public string RegisterShift(Shift shift, Instructor instructor, string shiftType, string _IDClone, DateTime dateToday)
        {
            string returnMessage = "";
            string mailExceptionHolder = "";
            int salary = shift.Salary;
            string hireDate = instructor.HireDate;
            DateTime ShiftDateTime = DateTime.Parse(dateToday.ToString());

            bool _DateRegistered = CheckDate(_IDClone);

            if (_DateRegistered == true)
            {
                
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    con.Open(); 
                    SqlCommand _GetEmploymentDate = new SqlCommand("spGetStartDate", con);
                    _GetEmploymentDate.CommandType = System.Data.CommandType.StoredProcedure;
                    _GetEmploymentDate.Parameters.Add(new SqlParameter("@Medlemsnr", _IDClone));

                    SqlDataReader reader = _GetEmploymentDate.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            hireDate = reader["Ansat"].ToString();
                        }
                    }

                    reader.Close();

                    DateTime employmentDate = DateTime.Parse(hireDate);

                    DateTime watchDate = ShiftDateTime;

                    watchDate = watchDate.AddYears(-3);

                    if (employmentDate <= watchDate)
                    {
                        salary = 100;

                    }
                    else
                    {
                        salary = 75;
                    }


                    SqlCommand spinningWatch = new SqlCommand("spRegisterWatch", con);
                    spinningWatch.CommandType = System.Data.CommandType.StoredProcedure;
                    spinningWatch.Parameters.Add(new SqlParameter("@Medlemsnr", _IDClone));
                    spinningWatch.Parameters.Add(new SqlParameter("@Type", shiftType));
                    spinningWatch.Parameters.Add(new SqlParameter("@Dato", dateToday));
                    spinningWatch.Parameters.Add(new SqlParameter("@Honorar", salary));

                    spinningWatch.ExecuteNonQuery();

                    mailExceptionHolder = GetMail(_IDClone, ShiftDateTime.ToString());



                }
                catch (SqlException e)
                {

                    returnMessage = "FEJL: " + e.Message;

                }
                catch (FormatException e1)
                {

                    returnMessage = "FEJL: " + e1.Message;

                }
                catch(Exception e2)
                {
                    returnMessage = "FEJL: Forkert indtastet - " + e2.Message;
                }
                returnMessage = returnMessage + mailExceptionHolder;
                if (returnMessage == "")
                {
                    returnMessage = "Vagt registreret og mail sendt";
                }
            }
                

            }
            else
            {
                returnMessage = "Der er allerede en vagt registreret for denne dato.";
            }
                return returnMessage;
        }
        internal string GetShiftListAll(Shift shift, Instructor instructor, string startDate, string endDate)
        {
            DateTime ShiftStartDate = DateTime.Parse(startDate.ToString());
            DateTime ShiftEndDate = DateTime.Parse(endDate.ToString());
            DateTime DT;
            string ifError = "";
            string normalRows = "";
            string shiftListFromDatabaseAll = "";

            //Variables for subtotal calculation:
            string currentName = "";
            string previousName = "";
            int i = -1;
            string subtotalRows = "";




            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {

                    con.Open();

                    SqlCommand _ShowShiftListAll = new SqlCommand("spShowShiftsFromSpecificPeriod", con);
                    _ShowShiftListAll.CommandType = CommandType.StoredProcedure;
                    _ShowShiftListAll.Parameters.Add(new SqlParameter("@startDate", ShiftStartDate));
                    _ShowShiftListAll.Parameters.Add(new SqlParameter("@endDate", ShiftEndDate));

                    SqlDataReader reader = _ShowShiftListAll.ExecuteReader();

                    List<int> subtotal = new List<int>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            currentName = reader["Navn"].ToString();
                            if (currentName != previousName)
                            {
                                if (i > -1)
                                {
                                    subtotalRows = subtotalRows + previousName + ": " + subtotal[i] + "kr." + "\n";
                                }
                                i++;
                                subtotal.Add(0);
                            }
                            instructor.InstructorID = reader["InstructorID"].ToString();
                            instructor.Name = currentName;
                            shift.Type = reader["Type"].ToString();
                            DT = DateTime.Parse(reader["Dato"].ToString());
                            shift.Date = DT.ToString("dd-MM-yyyy");
                            string salary = reader["Honorar"].ToString();
                            previousName = instructor.Name;
                            shift.Salary = int.Parse(salary);
                            subtotal[i] = subtotal[i] + shift.Salary;
                            normalRows = normalRows + (instructor.InstructorID + " | " + instructor.Name + " | " + shift.Type + " | " + shift.Date + " | " + shift.Salary + "\n");

                        }
                    }
                    subtotalRows = subtotalRows + previousName + ": " + subtotal[i] + "kr." + "\n";
                }
                catch (SqlException e)
                {

                    ifError = "FEJL: " + e.Message;

                }
                catch (FormatException e1)
                {
                    ifError = "FEJL: " + e1.Message;
                }

                shiftListFromDatabaseAll = normalRows + subtotalRows;

                if (ifError != "")
                {
                    shiftListFromDatabaseAll = ifError;
                }
                
                return shiftListFromDatabaseAll;
            }
        }

        public List<Instructor> ShowInstructors()
        {
            List<Instructor> instructorList = new List<Instructor>();
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                    
                try
                {
                    con.Open();


                    SqlCommand _GetInstructorInfo = new SqlCommand("spGetInstructorInfo", con);

                    SqlDataReader reader = _GetInstructorInfo.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Instructor instructor = new Instructor();

                            instructor.InstructorID = reader["InstructorID"].ToString();
                            instructor.Name = reader["Navn"].ToString();
                            instructor.Mail = reader["Email"].ToString();
                            instructor.HireDate = reader["Ansat"].ToString();
                            instructor.PhoneNumber = int.Parse(reader["TlfNr"].ToString());

                            instructorList.Add(instructor);
                        }
                    }
                }
                catch (SqlException e)
                {

                }
             
            }
            return instructorList;
        }

        internal string GetShiftListSingle(Shift shift, Instructor instructor,string memberNumber, string startDate, string endDate)
        {
            DateTime ShiftStartDate = DateTime.Parse(startDate.ToString());
            DateTime ShiftEndDate = DateTime.Parse(endDate.ToString());
            string ifError = "";
            string normalRows = "";
            string shiftListFromDatabase = "";

            int subtotal = 0;

            using (SqlConnection can = new SqlConnection(_ConnectionString))
            {
                try
                {
                    can.Open();

                    SqlCommand _ShowShiftListSingle = new SqlCommand("spShowShiftsFromSpecificPeriod", can);
                    _ShowShiftListSingle.CommandType = System.Data.CommandType.StoredProcedure;
                    _ShowShiftListSingle.Parameters.Add(new SqlParameter("@startDate", ShiftStartDate));
                    _ShowShiftListSingle.Parameters.Add(new SqlParameter("@endDate", ShiftEndDate));
                    _ShowShiftListSingle.Parameters.Add(new SqlParameter("@memberNumber", memberNumber));
                    SqlDataReader reader = _ShowShiftListSingle.ExecuteReader();


                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            instructor.InstructorID = reader["InstructorID"].ToString();
                            instructor.Name = reader["Navn"].ToString();
                            shift.Type = reader["Type"].ToString();
                            shift.Date = reader["Dato"].ToString();
                            string salary = reader["Honorar"].ToString();

                            shift.Salary = int.Parse(salary);

                            subtotal = subtotal + shift.Salary;

                            normalRows = normalRows + (instructor.InstructorID + " | " + instructor.Name + " | " + shift.Type + " | " + shift.Date + " | " + shift.Salary + "\n" + "\n");

                        }
                    }
                }
                catch (SqlException e)
                {
                    ifError = "FEJL: " + e.Message;
                }

                if (ifError == "")
                {
                    shiftListFromDatabase = normalRows + "Subtotal: " + subtotal + "kr.";
                }
                else
                {
                    shiftListFromDatabase = ifError;
                }
            }

            return shiftListFromDatabase;
        }
    }
}