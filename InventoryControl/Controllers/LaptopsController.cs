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
using System.IO;


namespace InventoryControl.Controllers
{
     
    public class LaptopsController : Controller
    {
        private InventoryContext db = new InventoryContext();
        const int DEFAULT_PAGE_SIZE = 8;
        const int DEFAULT_INVENTORY_PAGE_SIZE = 6;

        // GET: Laptops
        public ActionResult Index(int? page)
        {
            int pageSize = DEFAULT_INVENTORY_PAGE_SIZE;
            int pageIndex = page != null ? (int)page : 0;
            Session["CurrentInventoryPageIndex"] = pageIndex;
            pageIndex = pageIndex * pageSize;//refine page index
            int fetchRow = 0;
            Session["InventoryDataCount"] = db.Laptops.ToList().Count();
            fetchRow = (int)Session["InventoryDataCount"] - pageIndex;
            pageSize = (fetchRow < pageSize) ? fetchRow : pageSize;//refine pageSize 
            return View(db.Laptops.ToList().GetRange(pageIndex,pageSize));
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Login()
        {
            return RedirectToAction("Index", "Login");
        }

        public ViewResult PurchaseOrder()
        {
            return View();
        }

        public ViewResult Ordered()
        {
            return View();
        }
        public ActionResult CheckOut()
        {
            return View();
        }

        public ActionResult Profile(string id)
        {
            return RedirectToAction("Details", "Users", new { id = id });
        }

        public ActionResult CheckInventory()
        {
            return View(db.Laptops.ToList());
        }

        public ViewResult ViewOrder()
        {
            return View();
        }
        public ActionResult Products(string id, int? page)
        {
            

            Session["UserChoice"] = id;
            int pageSize = DEFAULT_PAGE_SIZE;//default page size
            int pageIndex = page != null ? (int)page : 0;
            Session["CurrentPageIndex"] = pageIndex;
            pageIndex = pageIndex * pageSize;//refine page index
            int fetchRow = 0;
            if (id.Equals(""))
                {
                Session["DataCount"] = db.Laptops.ToList().Count();                
                fetchRow = (int)Session["DataCount"] - pageIndex;
                pageSize = (fetchRow < pageSize) ? fetchRow : pageSize;//refine pageSize           
                return View(db.Laptops.ToList().GetRange(pageIndex,pageSize));
                }

            var laptops = from lap in db.Laptops
                          select lap;

            laptops = laptops.Where(lap => lap.CATEGORY.ToString().Equals(id));
            Session["DataCount"] = laptops.ToList().Count();
            fetchRow = (int)Session["DataCount"] - pageIndex;
            pageSize = (fetchRow < pageSize) ? fetchRow : pageSize;//refine pageSize

            return View(laptops.ToList().GetRange(pageIndex,pageSize));
        }



        public ActionResult Specs(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // GET: Laptops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // GET: Laptops/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: Laptops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection fc, HttpPostedFileBase file)
        {
            var allowedExtensions = new[] {".jpg"};
            Laptop laptop = new Laptop();
            laptop.CATEGORY = (Category)Enum.Parse (typeof(Category),fc["CATEGORY"]);
            laptop.Name = fc["Name"].ToString();
            laptop.CPU = fc["CPU"];
            laptop.RAM = fc["RAM"];
            laptop.CPU_MODEL = fc["CPU_MODEL"];
            laptop.STORAGE = fc["STORAGE"];
            laptop.SCREEN = fc["SCREEN"];
            laptop.OS = fc["OS"];
            laptop.OTHER_SPEC = fc["OTHER_SPEC"];
            laptop.PRICE = Int32.Parse(fc["PRICE"]);

            var fileName = Path.GetFileName(file.FileName);//just file name
            var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
            if (allowedExtensions.Contains(ext)) //check what type of extension  
            {
                //we don't use this name, we use according to laptop name
                //string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                string myfile = fc["Name"] + ext; //appending the name with id  (aa.jpg)
                                                           
                var path = Path.Combine(Server.MapPath("~/Images/Laptops"), myfile);// store the file inside ~/project folder(Img)  
                //tbl.Image_url = path;
                if (ModelState.IsValid)
                {
                    db.Laptops.Add(laptop);
                    db.SaveChanges();
                    file.SaveAs(path);
                    return RedirectToAction("Index",new { page = Convert.ToInt32(db.Laptops.ToList().Count()/ DEFAULT_INVENTORY_PAGE_SIZE) });
                }
               
            }
            else
            {
                ViewBag.message = "Please choose only Image file";
            }
            return View();


        }

        // GET: Laptops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Laptop_ID,CATEGORY,Name,CPU,RAM,CPU_MODEL,STORAGE,SCREEN,OS,OTHER_SPEC,PRICE,QTY")] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laptop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(laptop);
        }

        public ActionResult EditQty(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditQty([Bind(Include = "Laptop_ID,CATEGORY,Name,CPU,RAM,CPU_MODEL,STORAGE,SCREEN,OS,OTHER_SPEC,PRICE,QTY")] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laptop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CheckInventory");
            }
            return View(laptop);
        }


        // GET: Laptops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.Find(id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Laptop laptop = db.Laptops.Find(id);
            db.Laptops.Remove(laptop);
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

        [HttpPost]
        public void DecreaseQuantity(string _laptopList)
        {
            string[] listArr = _laptopList.Split(',');
            
            for (int i = 0; i < listArr.Length - 1; i++)
            {
                int item_id = Int32.Parse(listArr[i].Split('-')[0]);
                int qty = Int32.Parse(listArr[i].Split('-')[1]);

                //prepare to decrease
                Laptop laptop = new Laptop();
                laptop = db.Laptops.Find(item_id);
                laptop.QTY = laptop.QTY - qty;
                db.Entry(laptop).State = EntityState.Modified;
                db.SaveChanges();
            }

            Session["DQty"] = _laptopList;
        }

        [HttpPost]
        public void RunAction(string value)
        {
            Session["isPresentOrder"] = value;
        }
    }


}