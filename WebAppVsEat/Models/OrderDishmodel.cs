﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebAppVsEat.Models
{
   public class OrderDishmodel
    {
        public int idDish { get; set; }
        public DateTime DeliveryTime { get; set; }  
        public int Quantity { get; set; }
    }
}