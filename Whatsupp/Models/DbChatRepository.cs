using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    public class DbChatRepository : IChatRepository
    {
       
        private WhatsuppContext ctx = new WhatsuppContext();
        //
        public void AddMessage(Message message)
        {
            ctx.AccountChats.Add(message);
            ctx.SaveChanges();
            return; 
        }

        public IEnumerable<Message> GetSent(int accountId)
        {
            return ctx.AccountChats.Where(c => (c.senderAccountId == accountId)).ToList();
        }

        public IEnumerable<Message> GetReceived(int accountId)
        {
            return ctx.AccountChats.Where(c => (c.receiverAccountId == accountId)).ToList();
        }

        //public IEnumerable<Message> GetMessages(int accountId)
        //{
            
        //    IEnumerable<Message> sent = ctx.AccountChats.Where(c => (c.senderAccountId == accountId)).ToList();
        //    IEnumerable<Message> received = ctx.AccountChats.Where(c => (c.receiverAccountId == accountId)).ToList();

        //    IEnumerable<Message> all = ctx.AccountChats.Where(c => (c.senderAccountId == accountId) & (c.receiverAccountId == accountId)).ToList;
        //    IEnumerable<Message> batch = sent.Concat(GetReceived();
        //    foreach (Message m in batch)
        //    {
        //        m.receiverName = GetAccountName(m.receiverAccountId);
        //        m.senderName = GetAccountName(m.senderAccountId);

        //        if (m.senderAccountId == accountId)
        //        {
        //            m.flag = true;
        //        }
        //    }        
        //    return batch;
        //}

        //GetSentMessagesToContact

        //GetReceivedMessagesFromContact

        public IEnumerable<Message> GetLatestMessages(int accountId)
        {
            IEnumerable<Message> a = GetReceived(accountId);
            IEnumerable<Message> b = GetSent(accountId);
            List<Message> list1 = new List<Message>();
            Message last = new Message();
            List<Message> latestmessages = new List<Message>();
            //Hier haal ik de laatste berichten per afzender vandaan.
            foreach (Message m in a)
            {
                if(m.senderAccountId != last.senderAccountId)
                {
                    list1 = a.Where(c => c.senderAccountId == m.senderAccountId).ToList();
                    last = list1.OrderByDescending(x => x.addedAt).First();
                    last.senderName = GetAccountName(last.senderAccountId);
                    last.flag = false;
                    latestmessages.Add(last);
                }
            }

            //IEnumerable<Message> allmessages = ctx.AccountChats;
            //
            //    //if havent received message from contact, but have sent, show latest sent towards him.
            //if(latestmessages.Find(c => c.receiverAccountId == accountId) == null)
            //{
            //    list1 = allmessages.Where(d => d.senderAccountId == accountId).ToList();
            //    last = list1.OrderByDescending(x => x.addedAt).First();
            //    last.senderName = GetAccountName(accountId);
            //    last.flag = false;
            //    latestmessages.Add(last);
            //}



                
            
                    
                    
                
                
               
                    //(((((a.Where(ae => ae.senderAccountId != accountId)) == null) && (a.Where(ab => ab.receiverAccountId !== accountId) == null)) && (((b.Where(be => be.receiverAccountId == accountId) == null) && (b.Where(bb => bb.senderAccountId == accountId) == null)))) == null)
                    //(a.Where(c => c.receiverAccountId != mes.senderAccountId)) == null)
            

            // 5-6 6-5 if 5 is not a receiver account yet, add sent message to the list.
            //hier moet er gekeken worden of er een bericht al binnen is gekomen of niet, zo niet voeg dan het laatst verzonden bericht aan de lijst latestmessages toe.
            
            //latest = a.OrderByDescending(x => x.addedAt).First();
            return latestmessages as IEnumerable<Message>;
        }
        //find latest messages from a specific senderID
        public IEnumerable<Message> GetLatestMessagesFromSender(int currentSenderId, int currentReceiverId)
        {
            IEnumerable<Message> received = GetSent(currentSenderId);
            List<Message> receivedFromSender = new List<Message>();
            foreach (Message m in received)
            {
                if (m.senderAccountId == currentSenderId && m.receiverAccountId == currentReceiverId)
                {
                    m.flag = false;
                    receivedFromSender.Add(m);
                }
            }
            return receivedFromSender as IEnumerable<Message>;
        }

        public IEnumerable<Message> GetLatestMessagesFromReceiver(int currentSenderId, int currentReceiverId)
        {
            IEnumerable<Message> received = GetSent(currentSenderId);
            List<Message> receivedFromSender = new List<Message>();
            foreach (Message m in received)
            {
                if (m.senderAccountId == currentSenderId && m.receiverAccountId == currentReceiverId)
                {
                    m.flag = true;
                    receivedFromSender.Add(m);
                }
            }
            return receivedFromSender as IEnumerable<Message>;
        }

           
        public string GetAccountName(int accountId)
        {
            Account m = ctx.Accounts.SingleOrDefault(c => c.Id == accountId);

            return m.name;
        }

        public Account GetAccount(string naam)
        {
            return ctx.Accounts.SingleOrDefault(c => c.name == naam);
        }
    }
}