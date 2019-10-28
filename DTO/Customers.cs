using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class Customers
    {

        public int IdCustomer { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Country_code { get; set; }


        public override string ToString()
        {
            return $"{IdCustomer}|{Firstname}|{Lastname}|{Login}|{Password}|{Country_code.ToString()}";
        }

    }
}
