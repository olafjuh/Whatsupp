using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Whatsupp.Models;
using System.Data.Entity;

namespace Whatsupp.Controllers
{
   [Authorize]
    public class ContactsController : Controller
    {
        //
        // GET: /Contact/

        private IContactRepository contactRepository = new DbContactRepository();
        

        public ActionResult Index()
        {
            /*List<Contact> Contacts = new List<Contact>();
            Contacts.Add(new Contact(0, 0622935185, "Olaf", "de Mol"));
            Contacts.Add(new Contact(1, 0612583933, "Jan", "Schaap"));
            Contacts.Add(new Contact(2, 0624124343, "Jaap", "Aap"));
            return View(Contacts);*/
            //Laat alle contacten/groepen zien.

            Account account = (Account)Session["loggedin_account"];
            IEnumerable<Contact> allContacts = contactRepository.GetAllContacts(account.Id);
            return View(allContacts);
        }

        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                //check if email is attached to account
                if (contactRepository.CheckContact(contact))
                {
                    Account account = (Account)Session["loggedin_account"];
                    contact.OwnerAccountId = account.Id;
                    contact.ContactAccountId = null;
                    contactRepository.AddContact(contact);
                    return RedirectToAction("Index");
                }
                return View(contact);
            }
            return View(contact);
        }

        public ActionResult AddContact()
        {
            //List<Contact> Contacts = new List<Contact>();
            //return View(Contacts);
            //Een nieuwe contact toevoegen.
            return View();
        }


        public ActionResult editContact(int id)
        {
            Contact rightcontact = contactRepository.GetContact(id);
            return View(rightcontact);
        }

        [HttpPost]
        public ActionResult editContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactRepository.Update(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        

        public ActionResult RemoveContact(int id)
        {
            Contact rightcontact = contactRepository.GetContact(id);
            return View(rightcontact);
            //Contact verwijderen.
        }

        [HttpPost]
        public ActionResult RemoveContact(Contact contact)
        {
                contactRepository.Remove(contact);
                return RedirectToAction("Index");
            
            //Contact verwijderen.
        }
        public ActionResult StartConversation()
        {
            return View();
            //Geselecteerde contact wordt doorgestuurd naar Chat venster om chat te beginnen.
        }

        public ActionResult CreateGroep()
        {
            return View();
            //Groepen worden aangemaakt bij het selecteren van meerdere contact personen.
        }

        public ActionResult EditGroep()
        {
            return View();
        }

        public ActionResult ShowGroup()
        {
            return View();
        }

        public ActionResult RemoveGroup()
        {
            return View();
        }

    }
}
