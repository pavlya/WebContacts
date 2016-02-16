using System;
using System.Collections.Generic;
using System.Linq;
using WebContacts.Models;

namespace WebContacts.DAL
{
    class ContactsInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<WebContactsContext>
    {
        Random rand = new Random();
        protected override void Seed(WebContactsContext context)
        {
            GenerateContacts(context);
            GenerateWorkersHours(context);
            GenerateDefaultAdmin(context);
        }

        private void GenerateDefaultAdmin(WebContactsContext context)
        {
            
            RegistrationModel defaultAdmin = new RegistrationModel
            {
                UserName = "admin",
                Password = "password",
                ConfirmPassword = "password",
                Email = "admin@test.net",
                ConfirmEmail = "admin@test.net"
            };
            context.Logins.Add(defaultAdmin);
            context.SaveChanges();
        }

        //Add workers hours to database
        private void GenerateWorkersHours(WebContactsContext context)
        {
            var monthHours = new List<MonthHours>();
            List<ContactModel> contactsList = context.Contacts.ToList();
            foreach (ContactModel contact in contactsList)
            {
                for (int i = 0; i < 12; i++)
                {
                    MonthHours model = new MonthHours
                    {
                        ContactModelId = contact.Id,
                        Hours = rand.Next(180),
                        MonthOfTheYear = (Month)i
                    };
                    monthHours.Add(model);
                }
            }

            monthHours.ForEach(m => context.MonthHours.Add(m));
            context.SaveChanges();
        }

        private void GenerateContacts(WebContactsContext context)
        {
            // using random value to get random positions
            int enumLength = Position.GetNames(typeof(Position)).Length;
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
