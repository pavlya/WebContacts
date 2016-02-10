using System;
using System.Collections.Generic;
using WebContacts.Models;

namespace WebContacts.DAL
{
    class ContactsInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<WebContactsContext>
    {
        Random rand = new Random();
        protected override void Seed(WebContactsContext context)
        {
            // using random value to get random positions
            int enumLength = Position.GetNames(typeof(Position)).Length;
            rand.Next();
            //Create dummy contacts
            var contacts = new List<ContactModel> {
                new ContactModel { FirstName = "Robin", LastName ="Hood", Position=(Position)rand.Next(enumLength), // random value for getting position
                    Email ="his@email.biz", PhoneNumber ="03-9330303"},
                new ContactModel { FirstName = "Batman", LastName ="White", Position=(Position)rand.Next(enumLength),
                    Email ="Batman@email.biz", PhoneNumber ="052-49727272" },
                new ContactModel { FirstName = "Sarrah", LastName ="Kerrigan", Position=(Position)rand.Next(enumLength),
                    Email ="Kerrigan@email.biz", PhoneNumber ="054-8765213"},
                new ContactModel { FirstName = "Jack", LastName ="Sparrow", Position=(Position)rand.Next(enumLength),
                    Email ="his@email.biz", PhoneNumber ="052-933003"},
                new ContactModel { FirstName = "Jim", LastName ="Raynor", Position=(Position)rand.Next(enumLength),
                    Email ="Batman@email.biz", PhoneNumber ="054-49727272" },
                new ContactModel { FirstName = "Super", LastName ="Mario", Position=(Position)rand.Next(enumLength),
                    Email ="Kerrigan@email.biz", PhoneNumber ="058-8765213"}
            };
            //Add contacts to database
            contacts.ForEach(c => context.Contacts.Add(c));
            context.SaveChanges();
        }
    }
}
