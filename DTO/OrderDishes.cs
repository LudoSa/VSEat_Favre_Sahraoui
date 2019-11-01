using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class OrderDishes
    {

        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{IdOrder}|{IdProduct}|{Quantity}";
        }

    }
}
