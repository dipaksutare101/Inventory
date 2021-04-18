using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterfaceDAL;
using Inventory.Entity;
namespace Inventory.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly MyCustomRepository<Registration> _RegistrationRepository;
        private readonly MyCustomRepository<City> _CityRepository;

        public RegistrationController()
        {
            _RegistrationRepository = new MyCustomRepository<Registration>();
            _CityRepository = new MyCustomRepository<City>();
        }
        // GET: Registration
        public ActionResult Index()
        {
            var data = _CityRepository.GetAllData();
            ViewBag.city = data.Select(m => new SelectListItem { Text = m.cityname, Value = m.cityid.ToString() });
            return View();
        }

        public ActionResult Save(Registration objregistration)
        {
            var data = _CityRepository.GetAllData();
            ViewBag.city = data.Select(m => new SelectListItem { Text = m.cityname, Value = m.cityid.ToString() });

            _RegistrationRepository.InsertRecord(objregistration);
            _RegistrationRepository.SaveRecord();

            return View("Index");
        }

        public JsonResult GetCity(string Prefix)
        {
            var data = _CityRepository.GetAllData();
             data.Select(m => new  {  m.cityname,  m.cityid });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}