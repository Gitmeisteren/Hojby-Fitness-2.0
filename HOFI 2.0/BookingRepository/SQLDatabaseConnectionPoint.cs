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
        Booking _Booking = new Booking();
        private static string connectionString = "Server= den1.mssql5.gear.host; Database= hofi; User ID = hofi; Password= Qg9OG4l~v-06;";

        public void ScheduleSession(Booking Newmember)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {

                    con.Open();

                    SqlCommand _scheduleSession = new SqlCommand("spRegisterMemberBooking", con);
                    _scheduleSession.CommandType = System.Data.CommandType.StoredProcedure;
                    _scheduleSession.Parameters.Add(new SqlParameter("@I_MemberID", Newmember.MemberNumber));
                    _scheduleSession.Parameters.Add(new SqlParameter("@I_Date", Newmember.BookingDate));

                    _scheduleSession.ExecuteNonQuery();
                }
                catch (SqlException e)
                {

                }

            }
        }
    }
}
