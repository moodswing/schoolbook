using System;
using Microsoft.AspNetCore.Identity;

namespace SchoolBook.Models
{
    public class UserSelection
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public SelectionType Type { get; set; }
        public string Value { get; set; }
    }

    public enum SelectionType
    {
        Class,
        GradeBook,
    }
}
