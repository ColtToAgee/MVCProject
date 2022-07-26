using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class IstatistikController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        public ActionResult Index()
        {
            int categorycount = cm.GetList().Count();
            ViewData["toplamkategori"] = categorycount;
            int category_heading_count = cm.GetList().Where(x => x.CategoryName == "Yazılım").Count();
            ViewData["headingcount"]=category_heading_count;
            int headingcount = hm.GetList().Where(x => x.HeadingName.Contains('a')).Count();
            ViewData["heading"] = headingcount;
            var cats = hm.GetList().GroupBy(g => new
            {
                g.CategoryId,
                g.Category.CategoryName
            }).Select(s2 => new
            {
                CategoryId = s2.Key.CategoryId,
                CategoryName = s2.Key.CategoryName,
                Count = s2.Count()
            }).Max(m => m.CategoryName);
            ViewData["mesaj"] = cats;
            var categorytrue = cm.GetList().Where(x => x.CategoryStatus == true).Count();
            var categoryfalse = cm.GetList().Where(x => x.CategoryStatus == false).Count();
            int sonuc = categorytrue - categoryfalse;
            ViewData["kategori"]= sonuc;
            return View();

        }
    }
}