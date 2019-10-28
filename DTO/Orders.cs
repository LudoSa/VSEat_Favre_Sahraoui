using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Orders
    {
        public int IdOrder { get; set; }
        public string Status { get; set; }
        public string Created_at { get; set; }
        public int Delivery_time { get; set; }
        public int IdUser { get; set; }

        public override string ToString()
        {
            return $"{IdOrder}|{Status}|{Created_at}|{Status}|{Delivery_time}|{IdUser.ToString()}";
        }

    }
}
