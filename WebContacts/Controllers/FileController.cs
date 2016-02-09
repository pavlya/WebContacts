using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebContacts.DAL;

namespace WebContacts.Controllers
{
    public class FileController : Controller
    {
        private WebContactsContext db = new WebContactsContext();

        // GET: File
        public ActionResult Index(int id)
        {
            var fileToShow = db.files.Find(id);
            return File(fileToShow.Content, fileToShow.ContentType);
        }
    }
}