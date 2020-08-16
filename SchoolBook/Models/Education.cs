using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBook.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<EducationGrade> EducationGrades { get; set; }
    }
}