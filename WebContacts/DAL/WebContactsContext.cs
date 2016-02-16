using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebContacts.Models;

namespace WebContacts.DAL
{
    public class WebContactsContext: DbContext
    {
        //Specifying the connection string
        //The name of the connection string(in Web.config)
        public WebContactsContext() : base("ContactsContext")
        {

        }

        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<RegistrationModel> Logins { get; set; }
        public DbSet<LogModel> Logs { get; set; }
        public DbSet<File> files { get; set; }
        public DbSet<MonthHours>  MonthHours { get; set; }

        //check why we need this
        //for naming of tables (Contact instead of Contacts)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention> ();
        }
    }
}
