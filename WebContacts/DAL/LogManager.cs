using System;
using WebContacts.Models;

namespace WebContacts.DAL
{
    public class LogManager
    {

        private WebContactsContext db;
        private static LogManager instance = null;
        public LogManager(WebContactsContext db)
        {
            this.db = db;
        }

        public static LogManager getInstance(WebContactsContext db)
        {

            if (instance == null)
            {
                instance = new LogManager(db);
            }
            return instance;

        }

        public void LogSuccessfulRegistration(string username)
        {
            string message = "Registration succeed";
            LogEvent(username, message);
        }

        public void LogUnSuccessfulRegistration(string username)
        {
            string message = "Registration failed";
            LogEvent(username, message);
        }

        public void LogSuccessfulLogin(string username)
        {
            string message = "Login succeed";
            LogEvent(username, message);
        }

        public void LogUnSuccessfulLogin(string username)
        {
            string message = "Login failed";
            LogEvent(username, message);
        }

        private void LogEvent(string username, string message)
        {
            DateTime now = DateTime.Now;
            LogModel logModel = new LogModel();
            string combinedMessage = message + " for user: " + username;

            logModel.date = now;
            logModel.description = combinedMessage;
            logModel.Username = username;
            logModel.logEvent = message;

            db.Logs.Add(logModel);
            db.SaveChanges();
        }

        public void LogFileUploadEvent(string fileName)
        {
            DateTime now = DateTime.Now;
            LogModel logModel = new LogModel();
            string combinedMessage = "Uploaded picture "+ fileName;

            logModel.date = now;
            logModel.description = combinedMessage;
            logModel.Username = "";
            logModel.logEvent = "Picture uploaded";

            db.Logs.Add(logModel);
            db.SaveChanges();
        }
    }
}