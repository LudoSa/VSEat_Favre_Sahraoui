﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class Restaurants
    {

        public int IdRestaurant { get; set; }
        public string Merchant_name { get; set; }
        public int Country_code { get; set; }

        public override string ToString()
        {
            return $"{IdRestaurant}|{Merchant_name}|{Country_code}";
        }

    }
}
