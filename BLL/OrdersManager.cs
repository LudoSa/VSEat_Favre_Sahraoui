using DTO;
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


        public Order GetOrder(int id)
        {
            return OrdersDbObject.GetOrder(id);
        }

        public int AddOrder(Order courier)
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

        public List<Order> GetCourierOrders(int id)
        {

            return OrdersDbObject.GetCourierOrders(id);

        }

        public List<Order> GetArchivedCourierOrders(int id)
        {
            return OrdersDbObject.GetArchivedCourierOrders(id);
        }

        public List<Order> GetCustomerOrders(int id)
        {
            return OrdersDbObject.GetCustomerOrders(id);
        }

        public List<Order> GetCustomerCancelOrders(int id)
        {
            return OrdersDbObject.GetCustomerCancelOrders(id);
        }
    }
}
