using System;
namespace SchoolBook.Utils
{
    public interface IListItem
    {
        string Text { get; }
        string Value { get; }
        string SuperiorId { get; }
    }
}
