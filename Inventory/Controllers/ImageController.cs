using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterfaceDAL;
using Inventory.Entity;
namespace Inventory.Controllers
{
    public class ImageupController : Controller
    {

        private readonly MyCustomRepository<Image_Table> _Image_TableRepository;

        public ImageupController()
        {
            _Image_TableRepository = new MyCustomRepository<Image_Table>();
        }
        // GET: Image
        public ActionResult Index()
        {
            return View(_Image_TableRepository.GetAllData());
        }


        public ActionResult Uploadim(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string name = Path.GetFileName(file.FileName);
                string filePath = "~/upload/" + name;

                file.SaveAs(Server.MapPath(filePath));
                _Image_TableRepository.InsertRecord(new Image_Table { Title = name, image = filePath });
                _Image_TableRepository.SaveRecord();
            }
            return RedirectToAction("Index");
        }
    }


}