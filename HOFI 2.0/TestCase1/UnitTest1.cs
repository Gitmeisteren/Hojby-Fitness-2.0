using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Controller;
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
        Controller.Controller controller = Controller.Controller.GetInstance();
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
                controller.NewBooking.MemberNumber = "hofi9002";
                controller.NewBooking.BookingDate = "01-05-2018";
                controller.ScheduleSession();
                Assert.AreEqual(true, bookingRepository.FindDate(bookingInfo));
                controller.NewBooking.MemberNumber = "hofi9002";
                controller.NewBooking.BookingDate = "01-05-2018";
                controller.ScheduleSession();
                Assert.AreEqual(false , bookingRepository.FindDate(bookingInfo));
            }
        }
        [TestMethod]
        public void CalenderRecieveDataTest()
        {
            controller.UpdateCalendar();
            Assert.AreEqual(DateTime.Today.ToString("dd-MM"), controller.Label_1);
        }

        [TestMethod]
        public void AccesLoginTest()
        {
            controller.LoginCredentials = "hofi0";
            controller.LoginCredentialsPassword = "10";
            controller.CheckLogin();
            Assert.AreEqual("Godkendt", controller.ReturnMessageLoginWindow);
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
            Assert.AreEqual("Subtotal: 0kr.", controller.ReturnMessageShiftWindow);
        }
        [TestMethod]
        public void ExportShiftListTest()
        {
            controller.ShiftStartDate = "01-05-2018";
            controller.ShiftEndDate = "04-05-2018";
            controller.ReturnMessageShiftWindow = "TestExport";
            controller.ExportShiftList();
            Assert.AreEqual("TestExport\n Fil eksporteret til skrivebordet under mappen 'Excel'.", controller.ReturnMessageShiftWindow);
        }
        [TestMethod]
        public void Test()
        {

        }
    }
}