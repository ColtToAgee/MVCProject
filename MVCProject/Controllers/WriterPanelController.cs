using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MVCProject.Controllers
{   
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        MessageManager mm = new MessageManager(new EFMessageDal());
        ContentManager conm=new ContentManager(new EFContentDal());
        WriterLoginManager wlm = new WriterLoginManager(new EFWriterDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyHeading(string p)
        {
            Context c = new Context();
            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y=>y.WriterID).FirstOrDefault();
            var result=hm.GetListByWriter(writeridinfo);
            return View(result);
        }
        public ActionResult AllHeading(int p=1)
        {
            var result = hm.GetList().ToPagedList(p,4);
            return View(result);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                               ).ToList();
            ViewBag.vlc = valuecategory;
            return View(); 
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        { 
            HeadingValidator validationRules = new HeadingValidator();
            ValidationResult result = validationRules.Validate(p);
            p.WriterId = 2;
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.HeadingStatus = true;
            if (result.IsValid)
            {
                hm.AddHeading(p);
                return RedirectToAction("MyHeading");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction("Index");   
            }
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
            ViewBag.vlc = valuecategory;
            var result = hm.GetById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p,int id)
        {
            p.HeadingId = id;
            p.WriterId = 2;
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult InBox()
        {
            var result = mm.GetListInboxByWriter();
            return View(result);
        }
        public ActionResult SendBox()
        {
            var result = mm.GetListSendBoxByWriter();
            return View(result);
        }
        [HttpGet]
        public ActionResult NewMessage(string p)
        {
            p = (string)Session["WriterMail"];
            var writeridinfo = wlm.GetWriterIdInfo(p);
            var result = conm.GetListByWriter(writeridinfo);
            return View(result);
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.SenderMail = (string)Session["WriterMail"];
            MessageValidator validationRules = new MessageValidator();
            ValidationResult results = validationRules.Validate(p);
            if (results.IsValid)
            {
                mm.AddMessage(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public PartialViewResult ToolBox()
        {
            return PartialView();
        }
        public ActionResult MyContents(string p)
        {
            Context c = new Context();
            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var result = conm.GetListByWriter(writeridinfo);
            return View(result);
        }
        
    }
}