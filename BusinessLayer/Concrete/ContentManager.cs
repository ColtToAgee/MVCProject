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
    public class ContentManager : IContentService
    {
        IContentDal contentDal;
        public ContentManager(IContentDal contentDal)
        {
            this.contentDal = contentDal;
        }
        public void AddContent(Content content)
        {
            contentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            contentDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            contentDal.Update(content);
        }

        public Content GetById(int id)
        {
            return contentDal.Get(x => x.ContentId==id);
        }
        public List<Content> GetByHeading(int id)
        {
            return contentDal.List(x => x.HeadingId == id);
        }

        public List<Content> GetList()
        {
            return contentDal.List();
        }

        public List<Content> GetListByWriter(int id)
        {
            return contentDal.List(x=>x.WriterId==id);
        }
    }
}
