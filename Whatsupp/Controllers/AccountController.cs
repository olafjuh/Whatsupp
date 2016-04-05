using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Whatsupp.Models;

namespace Whatsupp.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        private IAccountRepository accountRepository = new DbAccountRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel1 model)
        {
            if (ModelState.IsValid)
            {
                Account account = accountRepository.GetAccount(model.email, model.password);
                if (account != null)
                {
                    //niet persistent (false) werkt alleen in firefox, chrome bewaard deze wel.
                    FormsAuthentication.SetAuthCookie(account.email, false);

                    //remember complete account
                    Session["loggedin_account"] = account;

                    //redirect to default entry of Contact Controller
                    return RedirectToAction("Index", "Home");
                    //return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("login-error", "The user name or password provided is incorrect.");
                    return View(model);
                }
            }
            //error --> go back to login page
            return View(model);
        }

        public ActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            //session = 0;
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                
                accountRepository.RegisterAccount(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }


    }
}
