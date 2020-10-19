using System;
namespace SchoolBook.Models
{
    public class UserSuperior
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public string SuperiorId { get; set; }
        public User Superior { get; set; }
    }
}
