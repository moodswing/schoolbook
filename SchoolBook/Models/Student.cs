using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SchoolBook.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<StudentClass> StudentClass { get; set; }

        [NotMapped]
        public List<Evaluation> Evaluations { get; set; }

        [NotMapped]
        public decimal EvaluationAvg
        {
            get
            {
                if (Evaluations == null || !Evaluations.Any(e => e.StudentScore != null && e.StudentScore.Score != 0))
                    return 0;

                return Evaluations.Where(e => e.StudentScore != null && e.StudentScore.Score != 0).Average(e => e.StudentScore.Score);
            }
        }

        [NotMapped]
        public string EvaluationAvgStr {
            get
            {
                return EvaluationAvg == 0 ? "" : EvaluationAvg.ToString("0.0");
            }
        }
    }
}
