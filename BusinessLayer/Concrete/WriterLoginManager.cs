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
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterDal writerDal;
        public WriterLoginManager(IWriterDal writerDal)
        {
            this.writerDal = writerDal;
        }

        public Writer GetWriter(string username, string password)
        {
            var result=writerDal.Get(x=>x.WriterMail==username&&x.WriterPassword==password);
            return result;
        }
        public int GetWriterIdInfo(string username)
        {
            var result = writerDal.Get(x => x.WriterMail == username);
            return result.WriterID;
        }
    }
}
