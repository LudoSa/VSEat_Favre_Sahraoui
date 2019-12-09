using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppVsEat.Controllers
{
    public class CourierController : Controller
    {


        private ICourierManager CourierManager { get; }
        public CourierController(ICourierManager courierManager)
        {
            CourierManager = courierManager;
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

        public ActionResult Orders(int id)
        {



            return View();
        }
    }
}