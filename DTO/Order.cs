using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Order
    {
        public int IdOrder { get; set; }
        public string Status { get; set; }
        public DateTime Created_at { get; set; }
        public int Delivery_time { get; set; }
        public int IdCustomer { get; set; }
        public int IdCourier { get; set; }


    }
}
