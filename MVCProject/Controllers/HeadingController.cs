using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        CategoryManager cm=new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        public ActionResult Index()
        {
            List<Heading> headings = hm.GetList();
            return View(headings);
        }
        [HttpGet]
        public ActionResult GetByHeading(int id)
        {
            var headings = hm.GetByWriterId(id);
            return View(headings);
        }
        [HttpGet]
        public ActionResult GetByCategory(int id)
        {
            List<Heading> categories = hm.GetByCategoryId(id);
            return View(categories);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                {
                                                    Text=x.CategoryName,
                                                    Value=x.CategoryId.ToString()
                                                }
                                                ).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }
                                              ).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuewriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            HeadingValidator validationRules = new HeadingValidator();
            ValidationResult result = validationRules.Validate(p);
            p.HeadingDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            if (result.IsValid)
            {
                hm.AddHeading(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                                ).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }
                                              ).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuewriter;

            var result=hm.GetById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p,int id)
        {
            p.HeadingId = id;
            hm.HeadingUpdate(p);
            return RedirectToAction("index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetById(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingUpdate(HeadingValue);
            return RedirectToAction("index");
        }
        
    }
}