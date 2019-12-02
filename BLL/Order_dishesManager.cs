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

        public IOrder_dishesDB OrderDishesDbObject { get; }

        public Order_dishesManager(IOrder_dishesDB orderDishesDb)
        {

            OrderDishesDbObject = orderDishesDb;

        }

        public List<OrderDish> GetOrderDishes()
        {
            return OrderDishesDbObject.GetOrderDishes();
        }

        public OrderDish GetOrderDish(int id)
        {
            return OrderDishesDbObject.GetOrderDish(id);
        }

        public int UpdateOrderDish(OrderDish orderDish)
        {
            return OrderDishesDbObject.UpdateOrderDish(orderDish);

        }




    }
}
