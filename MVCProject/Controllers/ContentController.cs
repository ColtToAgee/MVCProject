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
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        HeadingManager hm=new HeadingManager(new EFHeadingDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        public ActionResult Index()
        {
            List<Content> result = cm.GetList();
            return View(result);
        }
        public ActionResult GetByHeading(int id)
        {
            var content=cm.GetByHeading(id);
            return View(content);
        }
        [HttpGet]
        public ActionResult UpdateContent(int id)
        {
            List<SelectListItem> valueheading = (from x in hm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.HeadingName,
                                                      Value = x.HeadingId.ToString()
                                                  }
                                               ).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }
                                              ).ToList();
            ViewBag.vlc = valueheading;
            ViewBag.vlw = valuewriter;
            var content = cm.GetById(id);
            return View(content);
        }
        [HttpPost]
        public ActionResult UpdateContent(Content content,int id)
        {
            content.ContentId = id;
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cm.ContentUpdate(content);
            return RedirectToAction("/Index");
        }
        [HttpGet]
        public ActionResult AddContent()
        {
            List<SelectListItem> valuecategory = (from x in hm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.HeadingName,
                                                      Value = x.HeadingId.ToString()
                                                  }
                                                ).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName +" "+ x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }
                                              ).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuewriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content c)
        {
            ContentValidator validationRules = new ContentValidator();
            ValidationResult result=validationRules.Validate(c);
            c.ContentDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            if (result.IsValid)
            {
                cm.AddContent(c);
                return RedirectToAction("/Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(c);
        }
        [HttpGet]
        public ActionResult DeleteContent(int id)
        {
            var content = cm.GetById(id);
            cm.ContentDelete(content);
            return RedirectToAction("/Index");
        }
    }
}