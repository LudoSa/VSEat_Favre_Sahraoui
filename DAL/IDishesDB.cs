﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IDishesDB
    {
        IConfiguration Configuration { get; }
        List<Dishes> GetDishes();
        Dishes GetDish(int id);
        Dishes AddDish(Dishes dishes);
        int UpdateDish(Dishes dishes);
        int DeleteDish(int id);
    }
}
