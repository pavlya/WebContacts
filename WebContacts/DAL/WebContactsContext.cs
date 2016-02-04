﻿using System.Data.Entity;
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
        public DbSet<LoginViewModel> Logins { get; set; }

        //check why we need this
        //for naming of tables (Contact instead of Contacts)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention> ();
        }
    }
}