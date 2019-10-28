using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ICitiesDB
    {
        IConfiguration Configuration { get; }
        List<CitiesDB> getCities();
        CitiesDB getCity(int id);
        CitiesDB AddCity(CitiesDB city);
        int DeleteCity(int id);

    }
}
