using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;
using Inventory.DAL;
using Inventory.Entity;

namespace Inventory.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            using (var db = new InventoryDAL())
            {
                //SelectList data = new SelectList(db.cities.Select(x => new { x.cityid, x.cityname }).ToList());
                var data = db.cities.Select(x => new { x.cityid, x.cityname }).ToList();
                ViewBag.city = data.Select(m => new SelectListItem { Value = m.cityid.ToString(), Text = m.cityname });
            }
            return View("Register", new Registration());
        }

        public ActionResult Create(Registration objregistration)
        {


            using (var db = new InventoryDAL())
            {
                var data = db.cities.Select(x => new { x.cityid, x.cityname }).ToList();
                ViewBag.city = data.Select(m => new SelectListItem { Value = m.cityid.ToString(), Text = m.cityname });
                if (ModelState.IsValid)
                {
                    db.registrations.Add(objregistration);
                    db.SaveChanges();
                }
            }
            return View("Register", objregistration);
        }
    }
}