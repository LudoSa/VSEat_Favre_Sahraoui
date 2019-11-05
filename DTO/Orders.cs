﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Orders
    {
        public int IdOrder { get; set; }
        public string Status { get; set; }
        public int Created_at { get; set; }
        public int Delivery_time { get; set; }
        public int IdCustomer { get; set; }
        public int IdCourier { get; set; }

        public override string ToString()
        {
            return $"{IdOrder}|{Status}|{Created_at.ToString()}|{Delivery_time.ToString()}|{IdCustomer.ToString()}|{IdCourier.ToString()}";
        }

    }
}
