using System.Web.Mvc;

namespace WebContacts.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            InsertMessage message = TempData["message"] as InsertMessage;
            if(message != null)
            {
                ViewData["MessageText"] = message.MessageText;
            }
            return View();
        }
    }
}