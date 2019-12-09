using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppVsEat.Controllers
{
    public class CourierController : Controller
    {
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
    }
}