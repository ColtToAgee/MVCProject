using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        public ActionResult Index()
        {
            var results = cm.GetList();
            return View(results);
        }
        public ActionResult GetMessageDetail(int id)
        {
            var messages=cm.GetById(id);
            return View(messages);
        }
        public PartialViewResult Toolbox()
        {
            return PartialView();
        }
    }
}