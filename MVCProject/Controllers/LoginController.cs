using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager wlm = new WriterLoginManager(new EFWriterDal());
        AdminLoginManager alm = new AdminLoginManager(new EFAdminDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var admininfo = alm.GetAdmin(p.AdminUsername, p.AdminPassword);
            if (admininfo != null)
            {
                FormsAuthentication.SetAuthCookie(admininfo.AdminUsername, false);
                Session["AdminUsername"]=admininfo.AdminUsername;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            var writerinfo = wlm.GetWriter(p.WriterMail, p.WriterPassword);   
            if (writerinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerinfo.WriterMail, false);
                Session["WriterMail"] = writerinfo.WriterMail;
                return RedirectToAction("Index", "WriterPanel");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }

        }
    }
}