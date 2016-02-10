﻿using System;
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
                    Email ="his@email.biz", PhoneNumber ="03-9330303"},
                new ContactModel { FirstName = "Batman", LastName ="White", Position="IT Specialist",
                    Email ="Batman@email.biz", PhoneNumber ="052-49727272" },
                new ContactModel { FirstName = "Sarrah", LastName ="Kerrigan", Position="Designer",
                    Email ="Kerrigan@email.biz", PhoneNumber ="054-8765213"}
            };
            //Add contacts to database
            contacts.ForEach(c => context.Contacts.Add(c));
            context.SaveChanges();
        }
    }
}
