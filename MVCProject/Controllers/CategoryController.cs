using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MVCProject.Controllers
{
    public class CategoryController : Controller
    {
        
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategories()
        {
            var category = cm.GetList();
            return View(category);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result=categoryValidator.Validate(p);
            if (result.IsValid)
            {
                cm.AddCategory(p);
                return RedirectToAction("GetCategories");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}