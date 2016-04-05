using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whatsupp.Models;
using System.Data.Entity;

namespace Whatsupp.Controllers
{
    public class ChatsController : Controller
    {
        private IChatRepository chatRepository = new DbChatRepository();
        //
        // GET: /Gesprek/
        //view messages involving your AccountId
        public ActionResult Index()
        {
            Account account = (Account)Session ["loggedin_account"];
            IEnumerable<Message> messages = chatRepository.GetLatestMessages(account.Id);
                
            return View(messages);
        }

        public ActionResult DeleteMessage()
        {
            // Hide huidige gesprek.

            return View();
        }

        public ActionResult ViewChat(int id, int id2)
        {
            //find all messages from the sender with the id.
            IEnumerable<Message> rightMessages1 = chatRepository.GetLatestMessagesFromSender(id, id2);
            IEnumerable <Message> rightmessages = rightMessages1.Concat(chatRepository.GetLatestMessagesFromReceiver(id2, id));
            return View(rightmessages);
        }

        public ActionResult AddMessage(int id)
        {
            //ViewBag.senderName = chatRepository.GetAccountName(id);
            Account from = (Account)Session["loggedin_account"];
            Message m = new Message();
            m.receiverName = chatRepository.GetAccountName(id);
            ViewBag.Title = m.receiverName;
            m.receiverAccountId = id;
            m.receiverName = chatRepository.GetAccountName(id);
            m.senderAccountId = from.Id;
            m.senderName = chatRepository.GetAccountName(id);
            m.addedAt = DateTime.Now;
            return View(m);
        }

        [HttpPost]
        public ActionResult AddMessage(Message m)
        {
            
            if (ModelState.IsValid)
            {
                chatRepository.AddMessage(m);
                return RedirectToAction("Index");
            }
            return View(m);
        }
    }
}
