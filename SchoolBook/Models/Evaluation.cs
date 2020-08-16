using System;
namespace SchoolBook.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Grade { get; set; }

        public int GradeSubjectId { get; set; }
        public ClassSubject ClassSubject { get; set; }

        public int PeriodId { get; set; }
        public TypePeriod Period { get; set; }
    }
}
