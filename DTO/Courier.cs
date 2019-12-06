using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Courier
    {
        public int IdCourier { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Country_code { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public override string ToString()
        {
            return $"{IdCourier}|{Firstname}|{Lastname}|{Country_code}|{Email}|{Password}";
        }


    }
}
