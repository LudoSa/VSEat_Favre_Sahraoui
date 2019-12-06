using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Customer
    {

        public int IdCustomer { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Country_code { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"{IdCustomer}|{Firstname}|{Lastname}|{Email}|{Password}|{Country_code.ToString()}|{Address}";
        }

    }
}
