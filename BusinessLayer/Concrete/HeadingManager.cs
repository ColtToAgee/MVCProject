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
    public class HeadingManager:IHeadingService
    {
        IHeadingDal headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            this.headingDal = headingDal;    
        }

        public Heading GetById(int id)
        {
            return headingDal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetList()
        {
            return headingDal.List();
        }

        public void AddHeading(Heading heading)
        {
            headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            headingDal.Delete(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            headingDal.Update(heading);
        }
        public Heading GetByCategoryId(int id)
        {
            return headingDal.Get(x => x.CategoryId == id);
        }
    }
}
