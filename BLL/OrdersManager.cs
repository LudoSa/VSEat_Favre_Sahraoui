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


        public IOrdersDB OrdersDb { get; }

        public OrdersManager(IConfiguration configuration)
        {

            OrdersDb = new OrdersDB(configuration);

        }

        public List<Order> GetOrders()
        {
            return OrdersDb.GetOrders();
        }

        public Order GetOrder(int id)
        {
            return OrdersDb.GetOrder(id);
        }

        public Order AddOrder(Order courier)
        {
            return OrdersDb.AddOrder(courier);
        }

        public int UpdateOrder(Order courier)
        {
            return OrdersDb.UpdateOrder(courier);
        }

        public int DeleteOrder(int id)
        {
            return OrdersDb.DeleteOrder(id);
        }

    }
}
