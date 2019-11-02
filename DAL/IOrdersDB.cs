﻿using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrdersDB
    {
        IConfiguration Configuration { get; }
        List<Orders> getOrders();
        Orders getOrder(int id);
        Orders AddOrder(Orders orders);
        int UpdateOrder(Orders orders);
        int DeleteOrder(int id);
    }
}
