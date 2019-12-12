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
        private int Id { get; set; }
        public CourierController(ICourierManager courierManager, IOrdersManager ordersManager)
        {
            CourierManager = courierManager;
            OrderManager = ordersManager;
        }

        // GET: Courier
        public ActionResult Index()
        {
            return View();
        }

        // GET: Courier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetOrders(string email, [FromQuery(Name = "isAccountValid")] string isAccountValid, [FromQuery(Name = "isCourierValid")] string isCourier)
        {

                int id = CourierManager.GetCourierId(email);
                var orders = OrderManager.GetCourierOrders(id);
            //For the Edit page
                ViewBag.isAccountValid = isAccountValid;
                ViewBag.isAccountValid = isCourier;
                ViewBag.email = email;
            //For the Layout
                ViewBag.Role = "Courier";

                return View(orders);


        }

        public ActionResult EditOrder(int id, string isAccoutValid, string isCourier)
        {

            /*
            if (isAccoutValid == true && isCourier == true)
            {
                
            }
            else
                return RedirectToAction("Index", "Login");*/
            Id = id;
            var order = OrderManager.GetOrder(Id);
            ViewBag.Role = "Courier";
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

            OrderManager.UpdateOrder(order);

            return RedirectToAction(nameof(GetOrders));
        }
    }
}