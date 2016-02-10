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

namespace PACT_Challenges.Controllers
{
    public class ContactFormResultsController : Controller
    {  
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignalR()
        {
            return View();
        }

        public async Task<ActionResult> Contacts_Read()
        {
            using (var contactsDB = new ContactContext())
            {
                var result = await contactsDB.Contacts
                    .Select(c => new ContactVM
                        {
                            ContactID = c.ContactID,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Email = c.Email,
                            Company = c.Company,
                            PhoneNumber = c.PhoneNumber,
                            SubmittedDate = c.SubmittedDate,
                        })
                     .OrderByDescending(c => c.SubmittedDate)
                     .ToListAsync();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> Contacts_Update(Contact models)
        {
            using (var contactsDB = new ContactContext())
            {
                var update = contactsDB.Contacts
                    .Where(c => c.ContactID == models.ContactID)
                    .SingleOrDefault();
                if (update != null)
                {
                    update.FirstName = models.FirstName;
                    update.LastName = models.LastName;
                    update.Email = models.Email;
                    update.Company = models.Company;
                    update.PhoneNumber = models.PhoneNumber;
                    await contactsDB.SaveChangesAsync();
                }
                return Json(update);
            }
        }

        public async Task<ActionResult> Contacts_Destroy(int ContactID)
        {
            using (var contactsDB = new ContactContext())
            {
               var contact = contactsDB.Contacts
                   .Where(c => c.ContactID == ContactID).First();
               contactsDB.Contacts.Remove(contact);
               await contactsDB.SaveChangesAsync();
            }
            return Json(ContactID);
        }

        public async Task<ActionResult> Contacts_Create(Contact model)
        {
            using (var contactsDB = new ContactContext())
            {
                var contact = new Contact
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Company = model.Company,
                    PhoneNumber = model.PhoneNumber,
                    SubmittedDate = DateTime.UtcNow,
                };
                contactsDB.Contacts.Add(contact);
                await contactsDB.SaveChangesAsync();
            }
            return Json(model);
        }
    }
}