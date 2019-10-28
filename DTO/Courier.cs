using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class Courier
    {
        public int IdCourier { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int CountryCode { get; set; }

        public override string ToString()
        {
            return $"{IdCourier}|{Firstname}|{Lastname}|{CountryCode}";
        }


    }
}
