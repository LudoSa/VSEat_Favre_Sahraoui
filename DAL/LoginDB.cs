using System;
using System.Collections.Generic;
using DTO;
using System.Text;

namespace DAL
{
    public class LoginDB : IloginDB
    {

        public LoginDB()
        {

        }

        public bool IsUserValid(Login l)
        {
            return true;
        }
    }
}
