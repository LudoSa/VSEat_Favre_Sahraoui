using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppVsEat.Models
{
    public class OrderItem
    {

        public int IdCustomer { get; set; }
        public int IdCourier { get; set; }
        public DateTime DeliveryTime { get; set; }
        public string Status { get; set; }
    }
}
