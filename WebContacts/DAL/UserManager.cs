using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebContacts.Models;

namespace WebContacts.DAL
{
    public class UserManager
    {
        private WebContactsContext db;

        public UserManager(WebContactsContext db)
        {
            this.db = db;
        }

        public bool IsLoginNameExist(LoginViewModel loginModel)
        {
            string userName = loginModel.UserName;
            // Check if username exists in database
            return db.Logins.Any(x => x.UserName.ToLower().Equals(userName));
        }

        public void createNewUser([Bind(Include = "Id,UserName,Password")] LoginViewModel model)
        {
            db.Logins.Add(model);
            db.SaveChanges();
        }

        public bool isLoginCorrect(LoginViewModel loginModel)
        {
            string userName = loginModel.UserName;
            //get password from database
            var loginModeliNDB = db.Logins.Where(x => x.UserName.ToLower().Equals(userName.ToLower()));
            string password = loginModel.Password;

            return loginModel.Password.Equals(loginModel.Password);
        }

        public string GetUserPassword(LoginViewModel loginModel)
        {
            string userName = loginModel.UserName;
            var user = db.Logins.Where(o => o.UserName.ToLower().Equals(userName));
                if (user.Any())
                    return user.FirstOrDefault().Password;
                else
                    return string.Empty;
           
        }
    }
}