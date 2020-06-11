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
    public class ReservedController : Controller
    {
        // GET: Reserved
        public ActionResult Profilo()
        {
            var model = new ProfiloModel();
            var user = (User)(Session["loggedUser"]);
            model.username = user.username;
            model.email = user.email;
            return View(model);
        }

        [HttpGet]
        public ActionResult Purchase(int id)
        {
            var user = (User)(Session["loggedUser"]);
            var model = new PurchaseModel();
            model.idBeat = id;
            model.username = user.username;
            DatabaseHelper.Purchase(model);
            return View(model);
        }

        public ActionResult BeatPosseduti()
        {
            var user = (User)(Session["loggedUser"]);
            var model = new BeatPossedutiModel();
            model.listaBeatPosseduti = DatabaseHelper.GetBeatPosseduti(user.username);
            return View(model);
        }

        [HttpGet]
        public ActionResult DownloadBeat(string id)
        {
            byte[] fileByes = System.IO.File.ReadAllBytes(@"C:\Users\Marco\source\repos\TestMVC\TestMVC\Cool Images\"+"prova.mp3");
            string fileName = id+".mp3";
            return File(fileByes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}