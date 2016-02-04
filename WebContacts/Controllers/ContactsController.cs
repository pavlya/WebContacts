using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebContacts.DAL;
using WebContacts.Models;

namespace WebContacts.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private WebContactsContext db = new WebContactsContext();

        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactModel contactModel = db.Contacts.Find(id);
            if (contactModel == null)
            {
                return HttpNotFound();
            }
            return View(contactModel);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Position,Email,PhoneNumber")] ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contactModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactModel);
        }

        // GET:
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactModel contactModel = db.Contacts.Find(id);
            if (contactModel == null)
            {
                return HttpNotFound();
            }
            return View(contactModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Position,Email,PhoneNumber")] ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactModel);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactModel contactModel = db.Contacts.Find(id);
            if (contactModel == null)
            {
                return HttpNotFound();
            }
            return View(contactModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactModel contactModel = db.Contacts.Find(id);
            db.Contacts.Remove(contactModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
