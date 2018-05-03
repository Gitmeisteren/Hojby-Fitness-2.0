﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using ViewModel;
using View;
using System.Data;
using System.Data.SqlClient;


namespace TestCase1
{
    [TestClass]
    public class UnitTest1
    {
            SQLDatabaseConnectionPoint sqlDatabaseConnectionPoint = new SQLDatabaseConnectionPoint();
            private static string testConString = "Server= den1.mssql5.gear.host; Database= hofi; User ID = hofi; Password= Qg9OG4l~v-06;";
            SqlConnection testCon = new SqlConnection(testConString);

            [TestMethod] //Tester forbindelsen til SQLDatabasen.
            public void SqlConnectionTest()
            {
                testCon.Open();
                bool ConnecTest = false;
                if (testCon.State == ConnectionState.Open)
                {
                    ConnecTest = true;
                }
                Assert.AreEqual(true, ConnecTest);
            }

        [TestMethod]
        public void DoubleBookingTest()
        {
            Booking bookInfo = new Booking();
            Controller bookingController = Controller.GetInstance();
            using (var scop = new System.Transactions.TransactionScope())
            {
                bookInfo.MemberNumber = "hofi9002";
                bookInfo.BookingDate = "01.01.2000";
                bookingController.ScheduleSession();
                Assert.AreEqual("Booking er oprettet.", bookingController.ReturnMessage);
                bookInfo.MemberNumber = "hofi9002";
                bookInfo.BookingDate = "01.01.2000";
                bookingController.ScheduleSession();
                Assert.AreEqual("dagen er optaget", bookingController.ReturnMessage);
                // all your test code and Asserts that access the database, 
                // writes and reads, from any class, ...
            }
        }
        [TestMethod]
        public void CalenderRecieveDataTest()
        {
            Calendar cal = Calendar.GetInstance();
            cal.Label_1 = "11";
            Assert.AreEqual("11-11", cal.Label_1);
        }
    }
}