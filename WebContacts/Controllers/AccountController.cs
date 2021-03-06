﻿using System.Web.Mvc;
using System.Web.Security;
using WebContacts.DAL;
using WebContacts.Models;

namespace WebContacts.Controllers
{
    public class AccountController : Controller
    {
        private WebContactsContext db = new WebContactsContext();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        // Using return Url, to take user back to page, where he wanted to go
        public ActionResult Index(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                LogManager logManager = new LogManager(db);
                UserManager userManger = new UserManager(db);
                string password = userManger.GetUserPassword(model);
                if (string.IsNullOrEmpty(password))
                {
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                }
                else if (model.Password.Equals(password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    logManager.LogSuccessfulLogin(model.Username);

                    // redirects the user to page, where he wanted to go
                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    logManager.LogUnSuccessfulLogin(model.Username);
                    ModelState.AddModelError("", "The password provided is incorrect.");
                }

                logManager.LogUnSuccessfulLogin(model.Username);
                ModelState.AddModelError("", "Bad login attempt");
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel model)
        {
            LogManager logManager = new LogManager(db);
            if (ModelState.IsValid)
            {

                UserManager userManger = new UserManager(db);
                if (!userManger.IsLoginNameExist(model))
                {
                    userManger.createNewUser(model);
                    //FormsAuthentication.SetAuthCookie(model.UserName, false);
                    logManager.LogSuccessfulRegistration(model.UserName);
                    InsertMessage message = new InsertMessage();

                    // passing message to control about seccussfull registration
                    message.MessageText = "Registered user: " + model.UserName + " successfully. Now you can Log In.";
                    TempData["message"] = message;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    logManager.LogUnSuccessfulRegistration(model.UserName);
                    ModelState.AddModelError("", "Username already exists");
                }

            }
            logManager.LogUnSuccessfulRegistration(model.UserName);
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class InsertMessage
    {
        public string MessageText { get; set; }
    }
}