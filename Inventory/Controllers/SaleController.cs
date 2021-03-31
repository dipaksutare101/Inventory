using Inventory.DAL;
using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new Sale());
        }

        public ActionResult Savesale(Sale objSale)
        {
            if (ModelState.IsValid)
            {
                using (var db = new InventoryDAL())
                {
                    db.sales.Add(objSale);
                    db.SaveChanges();
                }
            }
            return View("Create", objSale);
        }
    }
}