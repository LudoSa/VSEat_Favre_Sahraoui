﻿using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IRestaurantsDB
    {
        List<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int id);
        
    }
}
