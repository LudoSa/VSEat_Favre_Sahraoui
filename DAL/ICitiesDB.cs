using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ICitiesDB
    {
        IConfiguration Configuration { get; }
        List<Cities> GetCities();
        
        Cities AddCity(Cities city);
        
        int DeleteCity(int id);

    }
}
