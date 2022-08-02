using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EFAboutDal());
        public ActionResult Index()
        {
            var aboutvalues=am.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AboutAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AboutAdd(About ab)
        {
            am.AddAbout(ab);
            return RedirectToAction("index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}