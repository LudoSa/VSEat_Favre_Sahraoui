using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebAppVsEat.Models
{
    //model used to get the dish, the quantity and the date time of the order
   public class OrderDishmodel
    {
        public Dish dish { get; set; } 
        public int Quantity { get; set; }
    }
}
