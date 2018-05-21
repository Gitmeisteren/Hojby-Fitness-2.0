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
        ShiftHandler shiftHandler = ShiftHandler.GetInstance();
        Controller controller = Controller.GetInstance();
        BookingRepository bookingRepository = BookingRepository.GetInstance();
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
                bookInfo.BookingDate = "01-01-2000";
                controller.ScheduleSession();
                Assert.AreEqual(true, bookingRepository.FindDate(bookingInfo));
                bookInfo.MemberNumber = "hofi9002";
                bookInfo.BookingDate = "01-01-2000";
                controller.ScheduleSession();
                Assert.AreEqual(false , bookingRepository.FindDate(bookingInfo));
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
            controller.LoginCredentials = "hofi1453";
            controller.LoginCredentialsPassword = "1234";
            Assert.AreEqual("Godkendt", loginHandler.GetLoginInformation("Timmi10", "hofi1453"));
        }
        [TestMethod]
        public void RegisterShiftTest()
        {
            controller.Shift.Date = "11-05-2018";
            controller.Instructor.InstructorID = "hofi0";
            controller.RegisterShift("Fitness");
            Assert.AreEqual("Vagt registreret og mail sendt", controller.ReturnMessageRegisterShift);
        }
        [TestMethod]
        public void ShowShiftListTest()
        {
            controller.ShiftStartDate = "01-05-2018";
            controller.ShiftEndDate = "04-05-2018";
            controller.ShiftListInstructorID = "hofi0";
            controller.ShowShiftList();
            Assert.AreEqual("Subtotal: 0kr.\n&\n \n Fil eksporteret for  på skrivebordet under mappen 'Excel'. \n \n", controller.ReturnMessageShiftWindow);
        }
        [TestMethod]
        public void ExportShiftListTest()
        {
            bool TestBool = false;
            controller.ShiftStartDate = "01-05-2018";
            controller.ShiftEndDate = "04-05-2018";
            controller.ReturnMessageShiftWindow = "SuperGay";
            controller.ExportShiftList();

        }
    }
}