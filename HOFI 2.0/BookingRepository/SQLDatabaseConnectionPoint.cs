using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    public class SQLDatabaseConnectionPoint
    {
        private static string connectionString = "Server= den1.mssql5.gear.host; Database= hofi; User ID = hofi; Password= Qg9OG4l~v-06;";

        public void ScheduleSession(Booking NewBooking)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
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
                    //Recall exception message
                }

            }
        }

        //string skal være en liste, og vi skal adde bookingobjekter til liste.
        public List<Booking> InitialRepoUpdate()
        {
           List<Booking> bookingRepo = new List<Booking>();
            using (SqlConnection con = new SqlConnection(connectionString))
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
                using (SqlConnection con = new SqlConnection(connectionString))
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
        }
    }

