﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebAppVsEat.Models
{
    public class DishQuantityOrder
    {
        public Dish dish { get; set; }

        public int quantity { get; set; }
    }
}
