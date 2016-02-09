using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
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
            //ContactModel contactModel = db.Contacts.Find(id);
            // specify the related files for Contacs model
            ContactModel contactModel = db.Contacts.Include(s => s.Files).SingleOrDefault(s => s.Id == id);
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
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Position,Email,PhoneNumber")] ContactModel contactModel,
            HttpPostedFileBase upload)
        {
            LogManager logManager = new LogManager(db);
            if (ModelState.IsValid)
            {
                // check if image was uploaded
                if(upload != null && upload.ContentLength > 0 ){
                    logManager.LogFileUploadEvent(upload.FileName);
                    var avatar = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    contactModel.Files = new List<File> { avatar };
                }
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

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, HttpPostedFileBase upload)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contactModel = db.Contacts.Find(id);
            //if (contactModel == null)
            //{
            //    return HttpNotFound();
            //}
            if (TryUpdateModel(contactModel, "", new string[] { "FirstName", "LastName", "Position", "Email", "PhoneNumber" }))
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    // check if user have Avatar uploaded
                    if (contactModel.Files.Any(f => f.FileType == FileType.Avatar))
                    {
                        db.files.Remove(contactModel.Files.First(f => f.FileType == FileType.Avatar));
                    }
                    var avatar = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    contactModel.Files = new List<File> { avatar };
                }
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
