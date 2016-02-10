using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACT_Challenges.Models.ViewModels
{
    public class ContactVM
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime SubmittedDate { get; set; }
        public string SubmittedDateFormatted { get {
            return SubmittedDate.ToShortDateString();
        } }
    }
}
