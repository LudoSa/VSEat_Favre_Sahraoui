using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrder_dishesDB
    {
        List<OrderDish> GetOrderDishes();
        OrderDish GetOrderDish(int id);
 
        void AddOrderDishes(OrderDish orderDish);

    }
}
