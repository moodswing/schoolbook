using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SchoolBook.Models
{
    public class User : IdentityUser
    {
        public List<UserSuperior> Superiors { get; set; }
        public List<ClassSubject> Classes { get; set; }
    }
}
