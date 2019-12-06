using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface ICitiesManager
    {
        City getCity(int id);

        List<City> GetCities();

    }
}
