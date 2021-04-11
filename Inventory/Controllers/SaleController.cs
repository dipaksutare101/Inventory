using InterfaceDAL;
using Inventory.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class SaleController : Controller
    {
        private readonly MyCustomRepository<Sale> _SaleRepository;
        private readonly MyCustomRepository<Saledetail> _SaledetailRepository;
        public SaleController()
        {
            _SaleRepository = new MyCustomRepository<Sale>();
            _SaledetailRepository = new MyCustomRepository<Saledetail>();
        }
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new Sale());
        }

        public PartialViewResult SaleDetail()
        {
            return PartialView(new Saledetail());
        }
        public JsonResult Savesale(Sale objSale)
        {
          bool  status = true;
            
                //using (var db = new InventoryDAL())
                //{
                //    db.sales.Add(objSale);
                //    db.SaveChanges();
                //}
                _SaleRepository.InsertRecord(objSale);
                foreach(Saledetail sd in objSale.Saledetails)
                {
                    _SaledetailRepository.InsertRecord(sd);
                }
                _SaleRepository.SaveRecord();
              

          
            return new JsonResult { Data = new { status = status } };
        }
    }
}