using System;
using System.Collections.Generic;
using SchoolBook.Models;

namespace SchoolBook.ViewModels
{
    public class ClassSelectorViewModel
    {
        public int YearId { get; set; }
        public int PeriodId { get; set; }
        public int EducationId { get; set; }
        public int GradeId { get; set; }
        public int ClassId { get; set; }

        public IEnumerable<SchoolYear> Years { get; set; }
        public IEnumerable<Grade> Grades { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}
