using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class InvSaleController : Controller
    {
        // GET: InvSale
      

        public ActionResult SaleEntry()
        {
            return View();
        }
    }
}