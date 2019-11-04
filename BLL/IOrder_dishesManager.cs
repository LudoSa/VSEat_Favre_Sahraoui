using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IOrder_dishesManager
    {


        IOrder_Dishes OrderDishesDb { get; }

        List<OrderDishes> GetOrderDishes();

        OrderDishes GetOrderDish(int id);

        OrderDishes AddOrderDish(OrderDishes hotel);

        int UpdateOrderDish(OrderDishes hotel);

        int DeleteOrderDish(int id);


    }
}
