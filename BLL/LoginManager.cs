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
            return LoginDbObject.IsUserValid(l);
        }
    }
}
