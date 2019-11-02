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
        List<OrderDishes> getOrderDishes();
        OrderDishes getOrderDish(int id);
        OrderDishes AddOrderDish(OrderDishes orderdishes);
        int UpdateOrderDish(OrderDishes orderdishes);
        int DeleteOrderDish(int id);
    }
}
