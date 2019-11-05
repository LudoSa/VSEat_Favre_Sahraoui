using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Restaurants
    {

        public int IdRestaurant { get; set; }
        public string Merchant_name { get; set; }
        public string Address { get; set; }
        public int Country_code { get; set; }

        public override string ToString()
        {
            return $"{IdRestaurant}|{Merchant_name}|{Address}|{Country_code.ToString()}";
        }

    }
}
