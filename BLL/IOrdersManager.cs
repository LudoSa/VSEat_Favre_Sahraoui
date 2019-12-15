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

        int AddOrder(Order orders);

        int UpdateOrder(Order orders);

        int DeleteOrder(int id);
        List<Order> GetCourierOrders(int id);
        List<Order> GetArchivedCourierOrders(int id);
        List<Order> GetCustomerOrders(int id);
        List<Order> GetCustomerCancelOrders(int id);

    }
}
