using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        public ActionResult Index()
        {
            var headings = hm.GetList();
            return View();
        }
        [HttpGet]
        public ActionResult GetByHeading(int id)
        {
            var headings = hm.GetByWriterId(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetByCategory(int id)
        {
            var categories = hm.GetByCategoryId(id);
            return View(categories);
        }
    }
}