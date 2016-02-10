using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PACT_Challenges.Models;
using PACT_Challenges.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;

namespace PACT_Challenges.Hubs
{
    public class ContactFormResultsHub : Hub
    {
        private ContactContext db;
        public ContactFormResultsHub()
        {
            db = new ContactContext();
        }

        public IEnumerable<ContactVM> Read()
        {
            return from contact in db.Contacts
                   select new ContactVM {
                        ContactID = contact.ContactID,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Email = contact.Email,
                        Company = contact.Company,
                        PhoneNumber = contact.PhoneNumber,
                        SubmittedDate = contact.SubmittedDate,
                   };
        }

        public void Update(ContactVM contactVm)
        {
            var c = db.Contacts.Where(contact => contact.ContactID == contactVm.ContactID).SingleOrDefault();
            if (c != null)
            {
                c.FirstName = contactVm.FirstName;
                c.LastName = contactVm.LastName;
                c.Email = contactVm.Email;
                c.Company = contactVm.Company;
                c.PhoneNumber = contactVm.PhoneNumber;
                db.SaveChanges();
                Clients.Others.update(contactVm);
            }
        }

        public void Destroy(ContactVM contactVm)
        {
            var c = db.Contacts.Where(contact => contact.ContactID == contactVm.ContactID).SingleOrDefault();
            if (c != null)
            {
                db.Contacts.Remove(c);
                db.SaveChanges();
                Clients.Others.destroy(contactVm);
            }
        }

        public ContactVM Create(ContactVM contactVm)
        {
            var c = new Contact
            {
                FirstName = contactVm.FirstName,
                LastName = contactVm.LastName,
                Email = contactVm.Email,
                Company = contactVm.Company,
                PhoneNumber = contactVm.PhoneNumber,
                SubmittedDate = DateTime.UtcNow,
            };
            db.Contacts.Add(c);
            db.SaveChanges();
            contactVm.ContactID = c.ContactID;
            Clients.Others.create(contactVm);
            return contactVm;
        }
    }
}