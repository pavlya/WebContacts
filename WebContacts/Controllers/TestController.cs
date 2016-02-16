using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        //public object Get(int id)
        //{
        //    int userId = -1;
        //    List<string> myDevices1 = new List<string>();
        //    myDevices1.Add("1");

        //    List<LogModel> jsonFiles = db.Logs.ToList();
        //    //List<ContactModel> jsonRegistration = db.Contacts.ToList();
        //    //var grouped = db.Logs.GroupBy(l => l.logEvent).Select(g => new { Name = g.Key, Count = g.Count() });
        //    var grouped = db.Contacts.ToList();
        //    var monthHourById = db.MonthHours.Where(i => i.ContactModelId == id);
        //    return Json(monthHourById);
        //}

        // get workin hours Json by username
        // example of url
        // http://localhost:55362/api/test?user=someuser
        public object Get(string user)
        {

            // get the user by FirstName, use First to get the result
            // check lowercase result
            var response = db.Contacts.Where(
                c => c.FirstName.ToLower().Contains(user.ToLower()));

            ContactModel someUser = null;
            // check if response is not empty
            // use First to get the result
            if ( response.Any())
            {
                someUser = response.First();
            }

            if(someUser != null) {
                var monthHourById = db.MonthHours.Where(i => i.ContactModelId == someUser.Id);
                return Json(monthHourById);
            }
            // no such user 
            throw new HttpResponseException(HttpStatusCode.NotFound); ;
        }

    }
}
