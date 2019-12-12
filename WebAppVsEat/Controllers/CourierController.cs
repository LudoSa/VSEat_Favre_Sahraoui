using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppVsEat.Controllers
{
    public class CourierController : Controller
    {


        private ICourierManager CourierManager { get; }
        private IOrdersManager OrderManager { get; }
        public CourierController(ICourierManager courierManager, IOrdersManager ordersManager)
        {
            CourierManager = courierManager;
            OrderManager = ordersManager;
        }


        // GET: Courier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
        //Méthode qui retourne la view de toutes les orders correspondantes à un livreur grâce à son id
        public ActionResult GetOrders(string email, [FromQuery(Name = "isAccountValid")] string isAccountValid, [FromQuery(Name = "isCourierValid")] string isCourier)
        {
                // On récupère les orders correspondantes à un id
                int id = CourierManager.GetCourierId(email);
                var orders = OrderManager.GetCourierOrders(id);

                //On stock dans des views bags les boolean de connection
                
                ViewBag.isAccountValid = isAccountValid;
                ViewBag.isCourierValid = isCourier;
                ViewBag.email = email;

                return View(orders);


        }

        //Méthode pour modifier le statut d'une commande
        public ActionResult EditOrder(int id, string isAccoutValid, string isCourier)
        {

            
           //On trouve l'order à modifier grâce à son id
            var order = OrderManager.GetOrder(id);
            ViewBag.isAccountValid = isAccoutValid;
            ViewBag.isCourierValid = isCourier;
            return View(order);



        }

        [HttpPost]
        public ActionResult EditOrder(Order order)
        {
            string isCourier = Request.Form["isCourierValid"];
            string isAccountValid = Request.Form["isAccountValid"];
            string email = Request.Form["email"];


            //On modifie l'order avec les nouvelles informations
            OrderManager.UpdateOrder(order);

            return RedirectToAction(nameof(GetOrders));
        }
    }
}