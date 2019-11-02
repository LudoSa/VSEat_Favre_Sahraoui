using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Customers
    {

        public int IdCustomer { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Country_code { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"{IdCustomer}|{Firstname}|{Lastname}|{Login}|{Password}|{Address}|{Country_code.ToString()}";
        }

    }
}
