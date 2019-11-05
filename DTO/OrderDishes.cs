using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class OrderDishes
    {

        public int IdOrderDishes { get; set; }
        public int IdDish { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{IdOrderDishes}|{IdDish.ToString()}|{Quantity.ToString()}";
        }

    }
}
