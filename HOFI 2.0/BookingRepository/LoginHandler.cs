using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LoginHandler
    {
        SQLDatabaseConnectionPoint _DatabaseCon = new SQLDatabaseConnectionPoint();
        public string GetLoginInformation(string password, string memberNumber)
        {
            string loginResponse = _DatabaseCon.RetrieveLoginInformation(password, memberNumber);
            if (loginResponse == "Godkendt")
            {

            }
            else if (loginResponse == "")
            {
                loginResponse = "Ikke godkendt";
            }
            else
            {
                loginResponse += " : Ikke godkendt";
            }
            return loginResponse;
        }
    }
}