using System;
using DTO;
using DAL;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IOrdersManager
    {



        Order GetOrder(int id);

        Order AddOrder(Order orders);

        int UpdateOrder(Order orders);

        int DeleteOrder(int id);
        List<Order> GetCourierOrders(int id);

    }
}
