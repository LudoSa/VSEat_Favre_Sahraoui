using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrdersDB
    {
        List<Order> GetOrders();
        Order GetOrder(int id);
        Order AddOrder(Order orders);
        int UpdateOrder(Order orders);
        int DeleteOrder(int id);
    }
}
