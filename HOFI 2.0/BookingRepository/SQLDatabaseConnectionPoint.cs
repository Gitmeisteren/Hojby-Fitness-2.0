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

        public string ScheduleSession(Booking NewBooking)
        {
            string returnMessage = "";
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {

                    con.Open();

                    SqlCommand _scheduleSession = new SqlCommand("spRegisterMemberBooking", con);
                    _scheduleSession.CommandType = System.Data.CommandType.StoredProcedure;
                    _scheduleSession.Parameters.Add(new SqlParameter("@I_MemberID", NewBooking.MemberNumber));
                    _scheduleSession.Parameters.Add(new SqlParameter("@I_Date", NewBooking.BookingDate));

                    _scheduleSession.ExecuteNonQuery();

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

        public string SearchForMember(Booking NewBooking, Member NewMember)
        {
            string _ReturnMessage = "";
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
                            NewBooking.MemberNumber = reader["MemberID"].ToString();
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
                if(_ReturnMessage != "")
                {
                    _ReturnMessage += " ----- Prøv igen";
                }
            }
            return _ReturnMessage;
        }

        //string skal være en liste, og vi skal adde bookingobjekter til liste.
        public List<Booking> InitialRepoUpdate()
        {
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
                            booking.BookingDate = reader["Date"].ToString();
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
        public string RetrieveLoginInformation(string password, string memberNumber)
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
                            if (password == reader["Kodeord"].ToString())
                            {
                                truePasswordCounter++;
                            }
                            if (memberNumber == reader["medlemsnr"].ToString())
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
        public string GetMail(string memberNumber, string date)
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
                    _GetEmploymentMail.Parameters.Add(new SqlParameter("@Medlemsnr", memberNumber));

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
                    mail.Subject = "Kvittering for registrering af vagt d. " + date;
                    mail.Body = "Din vagt er nu registreret";

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
        public string RegisterShift(Shift shift, Instructor instructor, string shiftType)
        {
            string returnMessage = "";
            string mailExceptionHolder = "";

            int salary = shift.Salary;
            string hireDate = instructor.HireDate;
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand _GetEmploymentDate = new SqlCommand("spGetStartDate", con);
                    _GetEmploymentDate.CommandType = System.Data.CommandType.StoredProcedure;
                    _GetEmploymentDate.Parameters.Add(new SqlParameter("@Medlemsnr", instructor.InstructorID));

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

                    DateTime watchDate = DateTime.Parse(shift.Date);

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
                    spinningWatch.Parameters.Add(new SqlParameter("@Medlemsnr", instructor.InstructorID));
                    spinningWatch.Parameters.Add(new SqlParameter("@Type", shiftType));
                    spinningWatch.Parameters.Add(new SqlParameter("@Dato", shift.Date));
                    spinningWatch.Parameters.Add(new SqlParameter("@Honorar", salary));

                    spinningWatch.ExecuteNonQuery();

                    mailExceptionHolder = GetMail(instructor.InstructorID, shift.Date);



                }
                catch (SqlException e)
                {

                    returnMessage = "FEJL: " + e.Message;

                }
                catch (FormatException e1)
                {

                    returnMessage = "FEJL: " + e1.Message;

                }
                returnMessage = returnMessage + mailExceptionHolder;

                return returnMessage;

            }
        }
    }
}