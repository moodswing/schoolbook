using System;
namespace SchoolBook.Models
{
    public class MenuOption
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }

        public int GroupMenuOptionId { get; set; }
    }
}
