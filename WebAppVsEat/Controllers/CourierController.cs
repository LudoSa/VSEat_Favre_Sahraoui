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



        
        //Méthode qui retourne la view de toutes les orders correspondantes à un livreur grâce à son id
        public ActionResult GetOrders(string email)
        {
                // On récupère les orders correspondantes à un id
                int id = CourierManager.GetCourierId(email);
                var orders = OrderManager.GetCourierOrders(id);

                //On stock dans des views bags les boolean de connection
                ViewBag.email = email;

                return View(orders);


        }

        //Méthode qui retourne les orders qui ont été livrées (Archivage)
        public ActionResult GetArchivedOrders(string email)
        {
            // On récupère les orders correspondantes à un id
            int id = CourierManager.GetCourierId(email);
            var orders = OrderManager.GetArchivedCourierOrders(id);

            //On stock dans des views bags les boolean de connection
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

        //Méthode qui réceptionne les informations afin d'update l'order
        [HttpPost]
        public ActionResult EditOrder(Order order)
        {
            string email = HttpContext.Session.GetString("User");

           
            //On modifie l'order avec les nouvelles informations
            OrderManager.UpdateOrder(order);

            return RedirectToAction("GetOrders", "Courier", new { email = email });
        }
    }
}