using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebContacts.DAL;
using WebContacts.Models;

namespace WebContacts.Controllers
{
    [Authorize]
    public class LogsController : Controller
    {

        private WebContactsContext db = new WebContactsContext();
        // GET: Logs
        public ActionResult Index()
        {
            return View(db.Logs.ToList());
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogModel logModel = db.Logs.Find(id);
            if (logModel == null)
            {
                return HttpNotFound();
            }
            return View(logModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogModel logModel = db.Logs.Find(id);
            db.Logs.Remove(logModel);
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