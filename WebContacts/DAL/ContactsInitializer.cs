using System;
using System.Collections.Generic;
using WebContacts.Models;

namespace WebContacts.DAL
{
    class ContactsInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<WebContactsContext>
    {
        protected override void Seed(WebContactsContext context)
        {
            //Create dummy contacts
            var contacts = new List<ContactModel> {
                new ContactModel { FirstName = "Robin", LastName ="Hood", Position="IT Specialist",
                    Email ="his@email.test", PhoneNumber ="030303"},
                new ContactModel { FirstName = "Batman", LastName ="White", Position="IT Specialist",
                    Email ="Batman@email.test", PhoneNumber ="030303" },
                new ContactModel { FirstName = "Sarrah", LastName ="Kerrigan", Position="Designer",
                    Email ="Kerrigan@email.test", PhoneNumber ="030303"}
            };
            //Add contacts to database
            contacts.ForEach(c => context.Contacts.Add(c));
            context.SaveChanges();
        }
    }
}
