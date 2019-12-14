using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ICitiesDB
    {
        List<City> GetCities();
        City getCity(int id);
        List<string> GetNames();
        int GetRestaurantCity(int id);

    }
}
