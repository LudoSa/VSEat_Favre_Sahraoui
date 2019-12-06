using System;
using System.Collections.Generic;
using DTO;
using System.Text;

namespace BLL
{
    public interface ILoginManager
    {

        bool IsUserValid(Login l);
        bool IsCustomerValid(Login l);
    }
}
