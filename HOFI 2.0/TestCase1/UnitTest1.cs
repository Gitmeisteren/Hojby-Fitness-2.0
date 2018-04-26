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
        Controller _controller = new Controller();
        SQLDatabaseConnectionPoint sqlDatabaseConnectionPoint = new SQLDatabaseConnectionPoint();
        private static string testConString = "Server= den1.mssql5.gear.host; Database= hofi; User ID = hofi; Password= Qg9OG4l~v-06;";
        SqlConnection testCon = new SqlConnection(testConString);
        
        [TestMethod] //Tester forbindelsen til SQLDatabasen.
        public void TestSqlConnection()
        {
            testCon.Open();
            bool ConnecTest = false;
            if (testCon.State == ConnectionState.Open)
            {
                ConnecTest = true;
            }
            Assert.AreEqual(true, ConnecTest);
        }
    }
}