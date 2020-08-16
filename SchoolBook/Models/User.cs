using System;
using Microsoft.AspNetCore.Identity;

namespace SchoolBook.Models
{
    public class User : IdentityUser
    {
        //public Guid Id { get; set; }
        //public string PasswordHash { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string IdSuperior { get; set; }
    }
}
