using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using PACT_Challenges.Models;
using System.Threading.Tasks;
namespace PACT_Challenges.Controllers
{
    public class ContactFormController : Controller
    {
        // GET: ContactForm
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(Contact model)
        {
            if (ModelState.IsValid) { 
                //ContactContext contacts = new ContactContext();
                using (var contactsDB = new ContactContext()) { 
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
            return Json(model);
        }
    }
}