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
    public class MessageManager:IMessageService
    {
        IMessageDal messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }

        public void AddMessage(Message message)
        {
            messageDal.Insert(message);
        }

        public Message GetById(int id)
        {
            return messageDal.Get(x=>x.MessageId == id);
        }
        public List<Message> GetListInbox()
        {
            return messageDal.List(x => x.ReceiverMail == "admin@gmail.com");
        }

        public List<Message> GetListInboxByWriter()
        {
            return messageDal.List(x => x.ReceiverMail == "mehmetozgonul@gmail.com");
        }

        public List<Message> GetListSendBox()
        {
            return messageDal.List(x => x.SenderMail == "admin@gmail.com");
        }

        public List<Message> GetListSendBoxByWriter()
        {
            return messageDal.List(x => x.SenderMail == "mehmetozgonul@gmail.com");
        }

        public void MessageDelete(Message message)
        {
            messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            messageDal.Update(message);
        }
    }
}
