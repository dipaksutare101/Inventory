using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Entity;
using InterfaceDAL;

namespace Inventory.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        private readonly MyCustomRepository<Registration> _RegistrationRepositoty = null;
        private readonly MyCustomRepository<City> _CityRepositoty = null;
        public RegisterController()
        {
            this._RegistrationRepositoty = new MyCustomRepository<Registration>();
            this._CityRepositoty = new MyCustomRepository<City>();
        }
        public ActionResult Index()
        {
            using (var db = new InventoryDAL())
            {
                //SelectList data = new SelectList(db.cities.Select(x => new { x.cityid, x.cityname }).ToList());
                //var data = db.cities.Select(x => new { x.cityid, x.cityname }).ToList();
                //ViewBag.city = data.Select(m => new SelectListItem { Value = m.cityid.ToString(), Text = m.cityname });
                var data = _CityRepositoty.GetAllData();
                ViewBag.city = data.Select(m => new SelectListItem { Value = m.cityid.ToString(), Text = m.cityname });
            }
            return View("Register", new Registration());
        }

        public ActionResult Create(Registration objregistration)
        {


            //using (var db = new InventoryDAL())
            //{
            //    var data = db.cities.Select(x => new { x.cityid, x.cityname }).ToList();
            //    ViewBag.city = data.Select(m => new SelectListItem { Value = m.cityid.ToString(), Text = m.cityname });
            //    if (ModelState.IsValid)
            //    {
            //        db.registrations.Add(objregistration);
            //        db.SaveChanges();
            //    }
            //}
            var data = _CityRepositoty.GetAllData();
            ViewBag.city = data.Select(m => new SelectListItem { Value = m.cityid.ToString(), Text = m.cityname });
            if (ModelState.IsValid)
            {
                _RegistrationRepositoty.InsertRecord(objregistration);
                _RegistrationRepositoty.SaveRecord();

            }
            return View("Register", objregistration);
        }
    }
}