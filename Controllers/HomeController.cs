using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoodiShop.Helpers;
using HoodiShop.Models;
using HoodiShop.Models.Entities;

namespace HoodiShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new IndexModel();
            model.elencoBeat = DatabaseHelper.GetAllBeats();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var user = DatabaseHelper.Login(model.Username, model.Password);
            if (user != null)
            {
                Session["loggedUser"] = user;
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}