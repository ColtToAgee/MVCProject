using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public void AddCategory(Category category)
        {
            categoryDal.Insert(category);
        }

        public List<Category> GetList()
        {
            return categoryDal.List();
        }
        public Category GetById(int id)
        {
            return categoryDal.Get(x=>x.CategoryId == id);
        }

        public void CategoryDelete(Category category)
        {
            categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            categoryDal.Update(category);
        }
    }
}
