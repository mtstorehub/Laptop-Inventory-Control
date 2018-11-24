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

        public ActionResult Products()
        {
            return RedirectToAction("Products", "Laptops");
        }

        [HttpPost]
        public ActionResult Authorize(InventoryControl.Models.Login userLoginModel)
        {

            
            if(userLoginModel.UserName.Equals("thida@gmail.com") && userLoginModel.Password == "012345")
            {
                Session["userID"] = "1";
                Session["userName"] = "Admin";
                Session["UserType"] = "Admin";                
                
                return RedirectToAction("Index", "Laptops");
            }

            using (InventoryContext db = new InventoryContext())
            {          
                //var adminInfo = db.Admin.Where(x => x.UserName == userLoginModel.UserName && x.Password == userLoginModel.Password).FirstOrDefault();
                //if (adminInfo != null)
                //{
                //    Session["userID"] = adminInfo.Admin_ID;
                //    Session["userName"] = adminInfo.UserName;
                //    Session["UserType"] = "Admin";
                //    return RedirectToAction("Index", "Laptops");
                //}

                var userInfo = db.Users.Where(x => x.UserName == userLoginModel.UserName && x.Password == userLoginModel.Password).FirstOrDefault();
                if (userInfo == null)
                {
                    userLoginModel.LoginErrorMessage = "Incorrect Nname & Password";

                    return View("Index", userLoginModel);
                }
                else
                {
                    Session["userID"] = userInfo.User_ID;
                    Session["userName"] = userInfo.UserName;
                    Session["userAddress"] = userInfo.Address;
                    Session["userPhno"] = userInfo.Phno;
                    Session["orderShowed"] = 1;//0 is before, 1 is current, 2 is after
                    if (Session["isPresentOrder"] != null)
                    {
                        return RedirectToAction("CheckOut", "Laptops");
                    }
                    return RedirectToAction("Products", "Laptops");
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public void RunAction(int value)
        {
            Session["orderShowed"] = value;         
        }
    }
}