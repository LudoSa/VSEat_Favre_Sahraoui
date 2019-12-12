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
        [HttpGet]
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

                    return RedirectToAction("Index", "Restaurant", new { isAccountValid = isValid, isCustomer = isCustomerValid});
                }
                else
                {
                    ViewBag.Role = "Courier";
                    //return RedirectToAction("Index", "Restaurant", new { isValid = isValid, isCustomerValid = isCustomerValid });
                    string emailLog = l.Email;
                    return RedirectToAction("GetOrders", "Courier", new  { email = emailLog, isAccountValid = isValid, isCourierValid = true });
                }

            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            ViewBag.Role = "";
            return RedirectToAction("Index", "Restaurant");
        }
    }
}