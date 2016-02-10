namespace PACT_Challenges.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.Infrastructure;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        public int ContactID { get; set; }
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Must be between 3 and 25 characters")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [StringLength(25, MinimumLength=3, ErrorMessage = "Must be between 3 and 25 characters")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [StringLength(50, MinimumLength=3, ErrorMessage = "Must be between 3 and 50 characters")]
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        [Column(TypeName="DateTime2")]
        public DateTime SubmittedDate { get; set; }
    }
    
    public class ContactContext : DbContext
    {
        public ContactContext()
            :base("name=ContactContext")
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}