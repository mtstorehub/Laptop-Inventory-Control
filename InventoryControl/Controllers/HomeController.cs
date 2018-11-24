using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryControl.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Products(string id)
        {
            return RedirectToAction("Products", "Laptops", new { id = id });
        }

        public ActionResult Profile(string id)
        {
            return RedirectToAction("Details", "Users", new { id = id });
        }
    }
}