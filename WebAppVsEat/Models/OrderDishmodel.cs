using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebAppVsEat.Models
{
   public class OrderDishmodel
    {
        public List<Dish> dish { get; }

        public DateTime dateTime { get; }
        public int Quantity { get; }
    }
}
