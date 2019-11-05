using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dishes
    {
        public int IdDishes { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public int Created_at { get; set; }
        public int Restaurants_id { get; set; }

        public override string ToString()
        {
            return $"{IdDishes}|{Name}|{Price}|{Status}|{Created_at}|{Restaurants_id.ToString()}";
        }

    }
}
