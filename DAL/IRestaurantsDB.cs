﻿using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IRestaurantsDB
    {
        IConfiguration Configuration { get; }
        List<Restaurants> getRestaurants();
        Restaurants getRestaurant(int id);
        Restaurants AddRestaurant(Restaurants restaurants);
        int UpdateRestaurant(Restaurants restaurants);
        int DeleteRestaurant(int id);
    }
}