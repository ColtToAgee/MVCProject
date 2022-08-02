﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager:IContactService
    {
        IContactDal contactDal;

        public ContactManager(IContactDal contactDal)
        {
            this.contactDal = contactDal;
        }

        public void AddContact(Contact contact)
        {
            contactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            contactDal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            contactDal.Update(contact);
        }

        public Contact GetById(int id)
        {
            return contactDal.Get(x => x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return contactDal.List();
        }

    }
}
