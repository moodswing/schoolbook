using System;
namespace SchoolBook.Utils
{
    public class ListItem : IListItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public string SuperiorId { get; set; }
    }

    public interface IListItem
    {
        string Text { get; }
        string Value { get; }
        string SuperiorId { get; }
    }
}
