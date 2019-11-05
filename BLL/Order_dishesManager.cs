using Microsoft.Extensions.Configuration;
using System;
using DAL;
using DTO;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Order_dishesManager
    {

        public IOrder_dishesDB Order_dishesDb { get; }

        public Order_dishesManager(IConfiguration configuration)
        {

            Order_dishesDb = new Order_dishesDB(configuration);

        }

        public List<OrderDishes> GetOrderDishes()
        {
            return Order_dishesDb.GetOrderDishes();
        }

        public OrderDishes GetOrderDish(int id)
        {
            return Order_dishesDb.GetOrderDish(id);
        }

        public OrderDishes AddOrderDish(OrderDishes Order_dishes)
        {
            return Order_dishesDb.AddOrderDish(Order_dishes);
        }

        public int UpdateOrderDish(OrderDishes Order_dishes)
        {
            return Order_dishesDb.UpdateOrderDish(Order_dishes);
        }

        public int DeleteOrderDish(int id)
        {
            return Order_dishesDb.DeleteOrderDish(id);
        }





    }
}
