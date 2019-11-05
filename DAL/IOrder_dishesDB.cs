using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrder_dishesDB
    {
        IConfiguration Configuration { get; }
        List<OrderDishes> GetOrderDishes();
        OrderDishes GetOrderDish(int id);
       
    }
}
