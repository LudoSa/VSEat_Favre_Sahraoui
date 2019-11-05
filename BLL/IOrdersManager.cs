using System;
using DTO;
using DAL;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IOrdersManager
    {


        IOrdersDB OrderDb { get; }

        List<Orders> GetOrders();

        Orders GetOrder(int id);

        Orders AddOrder(Orders orders);

        int UpdateOrder(Orders orders);

        int DeleteOrder(int id);



    }
}
