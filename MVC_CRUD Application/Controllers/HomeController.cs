using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD_Application.Models;

namespace MVC_CRUD_Application.Controllers
{
    public class HomeController : Controller
    {
        Personal_DetailsEntities db = new Personal_DetailsEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DataSet()
        {
            return View();
        }

        public JsonResult GetDataSet()
        {
            ViewBag.Message = "Person Information Dataset.";
            return Json(db.Personal_Information.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}