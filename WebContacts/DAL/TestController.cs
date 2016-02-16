using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebContacts.DAL;
using WebContacts.Models;

namespace WebContacts.Controllers
{
    public class TestController : ApiController
    {
        private WebContactsContext db = new WebContactsContext();

        //public JsonResult<List<LogModel>> Get()
        //{
        //    int userId = -1;
        //    List<string> myDevices1 = new List<string>();
        //    myDevices1.Add("1");

        //    List<LogModel> jsonFiles = db.Logs.ToList();
        //    //List<ContactModel> jsonRegistration = db.Contacts.ToList();
        //    var grouped = db.Logs.GroupBy(l =>l.logEvent).Select(g =>new {Name= g.Key,Count = g.Count() });
        //    return Json(jsonFiles);
        //}

        public object Get()
        {
            int userId = -1;
            List<string> myDevices1 = new List<string>();
            myDevices1.Add("1");

            List<LogModel> jsonFiles = db.Logs.ToList();
            //List<ContactModel> jsonRegistration = db.Contacts.ToList();
            //var grouped = db.Logs.GroupBy(l => l.logEvent).Select(g => new { Name = g.Key, Count = g.Count() });
            var grouped = db.Contacts.ToList();
            return Json(grouped);
        }

        public string Get(int id)
        {
            return "value: " + id;
        }
    }
}
