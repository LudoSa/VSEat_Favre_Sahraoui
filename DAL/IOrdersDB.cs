﻿using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrdersDB
    {
        List<Order> GetCourierOrders(int id);
        List<Order> GetArchivedCourierOrders(int id);
        Order GetOrder(int id);
        int AddOrder(Order orders);
        int UpdateOrder(Order orders);
   
        List<Order> GetCustomerOrders(int id);
        List<Order> GetCustomerCancelOrders(int id);
    }
}
