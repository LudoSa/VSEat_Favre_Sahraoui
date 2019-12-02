using System;
using DAL;
using DTO;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class LoginManager : ILoginManager
    {
        public IloginDB LoginDbObject { get; }


        public LoginManager(IloginDB loginDB)
        {
            LoginDbObject = loginDB;
        }

        public bool IsUserValid(Login l)
        {

            var LoginPasswords = LoginDbObject.GetLoginPassword();

            foreach(var loginPassword in LoginPasswords)
            {
                if (l.Username.Equals(loginPassword.Username) && l.Password.Equals(loginPassword.Password))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
