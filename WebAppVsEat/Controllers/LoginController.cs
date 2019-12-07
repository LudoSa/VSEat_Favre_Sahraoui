using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace WebAppVsEat.Controllers
{
    public class LoginController : Controller
    {


        private ILoginManager LoginManager { get; }
        public LoginController(ILoginManager loginManager)
        {
            LoginManager = loginManager;
        }


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login l)
        {
            bool isValid = LoginManager.IsUserValid(l);
            bool isCustomerValid = LoginManager.IsCustomerValid(l);
            if (isValid)
            {

                if (isCustomerValid)
                {
                    ViewBag.Role = "Customer";
                    //return RedirectToAction("Index", "Restaurant",  new { isValid = isValid, isCustomerValid = isCustomerValid });
                    return View("Index");
                }
                else
                {
                    ViewBag.Role = "Courier";
                    //return RedirectToAction("Index", "Restaurant", new { isValid = isValid, isCustomerValid = isCustomerValid });
                    return View("Index");
                }

            }
            else
            {
                return View();
            }
        }
    }
}