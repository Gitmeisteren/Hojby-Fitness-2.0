using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LoginHandler
    {
        SQLDatabaseConnectionPoint _databaseCon = new SQLDatabaseConnectionPoint();
        public string GetLoginInformation(string password, string memberNumber)
        {
            string loginResponse = _databaseCon.RetrieveLoginInformation(password, memberNumber);
            if (loginResponse == "Godkendt")
            {

            }
            else if (loginResponse == "")
            {
                loginResponse = "Ikke Godkendt";
            }
            else
            {
                loginResponse += " : Ikke Godkendt";
            }
            return loginResponse;
        }
    }
}