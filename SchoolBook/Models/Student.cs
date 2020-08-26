using System;
using System.Collections.Generic;

namespace SchoolBook.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<StudentClass> StudentClass { get; set; }
        public List<EvaluationScore> Scores { get; set; }
    }
}
