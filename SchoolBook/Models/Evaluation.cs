using System;
using System.Collections.Generic;

namespace SchoolBook.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int ClassSubjectId { get; set; }
        public ClassSubject ClassSubject { get; set; }

        public int PeriodId { get; set; }
        public TypePeriod Period { get; set; }

        public List<EvaluationScore> Scores { get; set; }
    }
}
