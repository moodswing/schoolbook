using System;
using Microsoft.AspNetCore.Identity;

namespace SchoolBook.Models
{
    public class RoleMenu
    {
        public int Id { get; set; }

        public string RoleId { get; set; }
        public IdentityRole Role { get; set; }

        public int MenuOptionId { get; set; }
        public MenuOption MenuOption { get; set; }
    }
}
