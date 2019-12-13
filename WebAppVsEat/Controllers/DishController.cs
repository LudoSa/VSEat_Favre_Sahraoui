using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppVsEat.Models;

namespace WebAppVsEat.Controllers
{
    public class DishController : Controller
    {
    private IDishesManager DishesManager { get; }
    private IRestaurantsManager RestaurantsManager { get; }
   
    public DishController(IDishesManager dishesManager, IRestaurantsManager restaurantsManager)
    {
            DishesManager = dishesManager;
            RestaurantsManager = restaurantsManager;
         
    }
    // GET: Dish/Details/5
    public ActionResult DishesRestaurant(int id)
        {

            var restaurant = RestaurantsManager.GetRestaurant(id);
            ViewData["Address"] = restaurant;
            
            var order_dishes = new List<OrderDishmodel>();
            var dishes = DishesManager.GetDishes(id);
            var datetime = RoundUp(DateTime.Now.AddMinutes(15),TimeSpan.FromMinutes(15));
            foreach (var item in dishes)
            {
                var dishOrder = new Models.OrderDishmodel();
                dishOrder.dish = DishesManager.GetDish(item.IdDishes);
                dishOrder.dish.Name = item.Name;

                dishOrder.Quantity = 0;

                order_dishes.Add(dishOrder);
                
            }

            return View(order_dishes);
        }
        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }
         <input class="form-control" style="width:300px;" type="datetime-local" value="@item.dateTime.ToString("yyyy-MM-ddTHH:mm")" min="@item.dateTime.ToString("yyyy-MM-ddTHH:mm")" step="900" a />

    }
}