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
    public class WriterManager : IWriterService
    {
        IWriterDal writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            this.writerDal = writerDal; 
        }

        public void AddWriter(Writer writer)
        {
            writerDal.Insert(writer);
        }

        public Writer GetById(int id)
        {
            return writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return writerDal.List();
        }

        public void WriterDelete(Writer writer)
        {
            writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            writerDal.Update(writer);
        }
    }
}
