using System;
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
        public int IdUser { get; set; }
        public int IdCourier { get; set; }

        public override string ToString()
        {
            return $"{IdOrder}|{Status}|{Created_at.ToString()}|{Status.ToString()}|{Delivery_time.ToString()}|{IdUser.ToString()}|{IdCourier.ToString()}";
        }

    }
}
