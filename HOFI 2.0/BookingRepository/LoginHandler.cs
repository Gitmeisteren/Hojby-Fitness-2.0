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
        public string GetLoginInformation(string LoginCredentials, string LoginCredentialsPassword)
        {
            string loginResponse = _DatabaseCon.RetrieveLoginInformation(LoginCredentialsPassword, LoginCredentials);
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