using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    class Customers
    {

        public int IdCustomer { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Firstname { get; set; }
        public int Lastname { get; set; }
        public bool Countrycode { get; set; }
        public bool HasParking { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }


    }
}
