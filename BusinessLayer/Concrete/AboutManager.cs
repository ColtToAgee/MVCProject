using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager:IAboutService
    {
        IAboutDal aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            this.aboutDal = aboutDal;
        }

        public void AboutDelete(About about)
        {
            aboutDal.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            aboutDal.Update(about);
        }

        public void AddAbout(About about)
        {
            aboutDal.Insert(about);
        }

        public About GetById(int id)
        {
            return aboutDal.Get(x => x.AboutId == id);
        }

        public List<About> GetList()
        {
            return aboutDal.List();
        }
    }
}
