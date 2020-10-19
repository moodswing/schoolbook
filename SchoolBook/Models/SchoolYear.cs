using System;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBook.Utils;

namespace SchoolBook.Models
{
    public class SchoolYear : IListItem
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string Text => Year.ToString();
        public string Value => Id.ToString();
        public string SuperiorId => string.Empty;
    }
}
