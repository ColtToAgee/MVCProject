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
    public class AdminLoginManager : IAdminLoginService
    {
        IAdminDal adminDal;

        public AdminLoginManager(IAdminDal adminDal)
        {
            this.adminDal = adminDal;
        }

        public Admin GetAdmin(string username, string password)
        {
            return adminDal.Get(x=>x.AdminUsername==username&&x.AdminPassword==password);
        }
    }
}
