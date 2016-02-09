using System.Web.Mvc;
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
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserManager userManger = new UserManager(db);
                string password = userManger.GetUserPassword(model);
                if (string.IsNullOrEmpty(password))
                {
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                }
                else if (model.Password.Equals(password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Index", "Home");
                } else
                {
                    ModelState.AddModelError("", "The password provided is incorrect.");
                }
                    
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
            if (ModelState.IsValid)
            {
                UserManager userManger = new UserManager(db);
                if (!userManger.IsLoginNameExist(model)){
                    userManger.createNewUser(model);
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                } else
                {
                    ModelState.AddModelError("", "Username already exists");
                }
            }
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
}