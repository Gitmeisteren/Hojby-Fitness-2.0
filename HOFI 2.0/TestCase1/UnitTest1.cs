using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using ViewModel;
using View;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace TestCase1
{
    [TestClass]
    public class UnitTest1
    {
        Booking bookingInfo = new Booking();
        LoginHandler loginHandler = new LoginHandler();
        Login login = new Login();
        Controller controller = Controller.GetInstance();
        BookingRepository bookingRepository = new BookingRepository();
        Calendar calendar = Calendar.GetInstance();
        BookingHandler bookingHandler = BookingHandler.GetInstance();
            SQLDatabaseConnectionPoint sqlDatabaseConnectionPoint = new SQLDatabaseConnectionPoint();
            private static string testConString = "Server= den1.mssql5.gear.host; Database= hofi; User ID = hofi; Password= Qg9OG4l~v-06;";
            SqlConnection testCon = new SqlConnection(testConString);

            [TestMethod] //Tester forbindelsen til SQLDatabasen.
            public void SqlConnectionTest()
            {
                testCon.Open();
                bool ConnectTest = false;
                if (testCon.State == ConnectionState.Open)
                {
                    ConnectTest = true;
                }
                Assert.AreEqual(true, ConnectTest);
            }

        [TestMethod]
        public void DoubleBookingTest()
        {
            Booking bookInfo = new Booking();
            using (var scop = new System.Transactions.TransactionScope())
            {
                List<string> listOfDates = new List<string>();
                Calendar calendar = Calendar.GetInstance();
                bookInfo.MemberNumber = "hofi9002";
                bookInfo.BookingDate = "01.01.2000";
                controller.ScheduleSession();
                Assert.AreEqual(true, bookingRepository.FindDate(bookingInfo));
                bookInfo.MemberNumber = "hofi9002";
                bookInfo.BookingDate = "01.01.2000";
                controller.ScheduleSession();
                Assert.AreEqual(false , bookingRepository.FindDate(bookingInfo));
                // all your test code and Asserts that access the database, 
                // writes and reads, from any class, ...
            }
        }
        [TestMethod]
        public void CalenderRecieveDataTest()
        {
            controller.UpdateCalendar();
            Assert.AreEqual(DateTime.Today.ToString("dd.MM"), controller.Label_1);
        }

        [TestMethod]
        public void AccesLoginTest()
        {
            login.memberNumber = "hofi1453";
            login.password = "Timmi10";
            Assert.AreEqual("Godkendt", loginHandler.GetLoginInformation("Timmi10", "hofi1453"));
        }

    }
}