using Microsoft.Extensions.Configuration;
using System;
using DTO;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Order_dishesManager
    {

        public IOrder_dishes Order_dishesDb { get; }

        public Order_dishesManager(IConfiguration configuration)
        {

            Order_dishesDb = new Order_dishesDb(configuration);

        }

        public List<OrderDishes> GetHotels()
        {
            return Order_dishesDb.GetHotel();
        }

        public OrderDishes GetHotel(int id)
        {
            return Order_dishesDb.GetHotel(id);
        }

        public OrderDishes AddHotel(OrderDishes Order_dishes)
        {
            return Order_dishesDb.AddHotel(Order_dishes);
        }

        public int UpdateHotel(OrderDishes Order_dishes)
        {
            return Order_dishesDb.UpdateHotel(Order_dishes);
        }

        public int DeleteHotel(int id)
        {
            return Order_dishesDb.DeleteHotel(id);
        }





    }
}
