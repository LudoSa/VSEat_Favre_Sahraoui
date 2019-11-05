using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface ICitiesManager
    {

        ICitiesDB CitiesDb { get; }

        List<Cities> GetCities();

        Cities GetCity(int id);

        Cities AddCity(Cities cities);

        int UpdateCity(Cities cities);

        int DeleteCity(int id);

    }
}
