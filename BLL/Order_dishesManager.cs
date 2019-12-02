using Microsoft.Extensions.Configuration;
using System;
using DAL;
using DTO;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Order_dishesManager : IOrder_dishesManager
    {

        public IOrder_dishesDB OrderDishesDb { get; }

        public Order_dishesManager(IConfiguration configuration)
        {

            OrderDishesDb = new Order_dishesDB(configuration);

        }

        public List<OrderDish> GetOrderDishes()
        {
            return OrderDishesDb.GetOrderDishes();
        }

        public OrderDish GetOrderDish(int id)
        {
            return OrderDishesDb.GetOrderDish(id);
        }

        public int UpdateOrderDish(OrderDish orderDish)
        {
            return OrderDishesDb.UpdateOrderDish(orderDish);

        }




    }
}
