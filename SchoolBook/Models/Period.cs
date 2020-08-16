using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBook.Models
{
    public class Period
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int TypePeriodId { get; set; }
        public TypePeriod TypePeriod { get; set; }
    }
}
