using System;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBook.Utils;

namespace SchoolBook.Models
{
    public class Period : IListItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int TypePeriodId { get; set; }
        public TypePeriod TypePeriod { get; set; }

        public int YearId { get; set; }
        public SchoolYear Year { get; set; }

        [NotMapped]
        public string Text => Description.ToString();
        [NotMapped]
        public string Value => Id.ToString();
        [NotMapped]
        public string SuperiorId => string.Empty;
    }
}
