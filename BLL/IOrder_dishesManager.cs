using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IOrder_dishesManager
    {


        IOrder_dishesDB OrderDishesDb { get; }

        List<OrderDish> GetOrderDishes();

        OrderDish GetOrderDish(int id);

        int UpdateOrderDish(OrderDish orderDish);


    }
}
