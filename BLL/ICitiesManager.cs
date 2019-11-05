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

    }
}
