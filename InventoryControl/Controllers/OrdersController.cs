using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryControl.DAL;
using InventoryControl.Models;

namespace InventoryControl.Controllers
{
    public class OrdersController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_ID,Order_NO,Purchased_On,Customer_Name,Customer_Address,Charges")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orders);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_ID,Order_NO,Purchased_On,Customer_Name,Customer_Address,Charges")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Products()
        {
            return RedirectToAction("Products", "Laptops");
        }

        public ActionResult RemoveOrder(int id)
        {
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public void TakeOrder(string _orderNo, string _purchaseTime, string _shipToName, string _shipAddress, float _charge, string _orderList)
        {
                        
            //insert into database
            Orders order = new Orders();
            order.Order_NO = _orderNo;
            order.Purchased_On = _purchaseTime;
            order.Customer_Name = _shipToName;
            order.Customer_Address = _shipAddress;
            order.Charges = _charge;
            string[] orderItems = _orderList.Split('#');
            string Order_items = "";
            for (int i = 0; i < orderItems.Length - 1; i++)
            {
                string name = orderItems[i].Split(',')[0];
                int qty = Int32.Parse(orderItems[i].Split(',')[1]);
                float total = float.Parse(orderItems[i].Split(',')[2]);
                Order_items += name + "," + qty + "," + total+"#";
               



            }
            order.Order_Items = Order_items;
            db.Orders.Add(order);
            db.SaveChanges();
            Session["Order"] = Order_items;
        }
    }
}
