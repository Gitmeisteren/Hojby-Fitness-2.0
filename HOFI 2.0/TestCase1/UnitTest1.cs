using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using ViewModel;
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
            string FakeMember1 = "Hofi1111";
            string FakeMember2 = "Hofi2222";
            string FakeBookingDate = "1010"; 
            
            BookingController bookingController = BookingController.GetInstance();
            using (var scop = new System.Transactions.TransactionScope())
            {
                
                // all your test code and Asserts that access the database, 
                // writes and reads, from any class, ...
                // to commit at the very end of this block,
                // you would call
                // scop.Complete();  // ..... but don't and all will be rolled back
            }
        }
    }
}