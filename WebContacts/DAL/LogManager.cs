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
            LogEventType logEvent = LogEventType.Registration;
            LogEvent(username, message, logEvent);
        }

        public void LogUnSuccessfulRegistration(string username)
        {
            string message = "Registration failed";
            LogEventType logEvent = LogEventType.Registration;
            LogEvent(username, message, logEvent);
        }

        public void LogSuccessfulLogin(string username)
        {
            string message = "Login succeed";
            LogEventType logEvent = LogEventType.LogIn;
            LogEvent(username, message, logEvent);
        }

        public void LogUnSuccessfulLogin(string username)
        {
            string message = "Login failed";
            LogEventType logEvent = LogEventType.LogIn;
            LogEvent(username, message, logEvent);
        }

        private void LogEvent(string username, string message, LogEventType logEvent)
        {
            DateTime now = DateTime.Now;
            LogModel logModel = new LogModel();
            string combinedMessage = message + " for user: " + username;

            logModel.date = now;
            logModel.description = combinedMessage;
            logModel.Username = username;
            logModel.logEvent = logEvent;

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
            logModel.logEvent = LogEventType.FileUpload;

            db.Logs.Add(logModel);
            db.SaveChanges();
        }
    }
}