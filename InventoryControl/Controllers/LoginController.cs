using InventoryControl.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryControl.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(InventoryControl.Models.Login userLoginModel)
        {
            using (InventoryContext db = new InventoryContext())
            {
                var userInfo = db.Users.Where(x => x.UserName == userLoginModel.UserName && x.Password == userLoginModel.Password).FirstOrDefault();
                if(userInfo == null)
                {
                    userLoginModel.LoginErrorMessage = "Incorrect Username & Password";

                    return View("Index", userLoginModel);
                }
                else
                {
                    Session["userID"] = userInfo.User_ID;                                       
                    Session["userName"] = userInfo.UserName;
                    return RedirectToAction("Index", "Home");
                }
            }
                return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}