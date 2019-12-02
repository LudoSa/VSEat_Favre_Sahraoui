﻿using DTO;
using Microsoft.Extensions.Configuration;
using System;
using DAL;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class OrdersManager : IOrdersManager
    {


        public IOrdersDB OrdersDbObject { get; }

        public OrdersManager(IOrdersDB ordersDb)
        {

            OrdersDbObject = ordersDb;

        }

        public List<Order> GetOrders()
        {
            return OrdersDbObject.GetOrders();
        }

        public Order GetOrder(int id)
        {
            return OrdersDbObject.GetOrder(id);
        }

        public Order AddOrder(Order courier)
        {
            return OrdersDbObject.AddOrder(courier);
        }

        public int UpdateOrder(Order courier)
        {
            return OrdersDbObject.UpdateOrder(courier);
        }

        public int DeleteOrder(int id)
        {
            return OrdersDbObject.DeleteOrder(id);
        }

    }
}
