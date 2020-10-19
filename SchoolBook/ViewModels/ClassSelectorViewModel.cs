using System;
using System.Collections.Generic;
using SchoolBook.Models;

namespace SchoolBook.ViewModels
{
    public class UserSelectorViewModel
    {
        public string YearId { get; set; }
        public string GradeId { get; set; }
        public string ClassId { get; set; }

        public string StudentId { get; set; }
        public string EvaluationId { get; set; }

        public IEnumerable<SchoolYear> Years { get; set; }
        public IEnumerable<Grade> Grades { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}
