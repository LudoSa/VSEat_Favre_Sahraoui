﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dish
    {
        public int IdDishes { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public DateTime Created_at { get; set; }
        public int Restaurants_id { get; set; }

       

    }
}
