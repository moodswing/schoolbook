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

        [NotMapped]
        public string Text => Year.ToString();
        [NotMapped]
        public string Value => Id.ToString();
        [NotMapped]
        public string SuperiorId => string.Empty;
    }
}
