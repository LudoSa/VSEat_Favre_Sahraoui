﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebAppVsEat.Models
{
   public class OrderDishmodel
    {
        public Dish dish { get; set; } 
        public int Quantity { get; set; }
    }
}
