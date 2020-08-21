using System;
using Microsoft.AspNetCore.Identity;

namespace SchoolBook.Models
{
    public class EducationGrade
    {
        public int Id { get; set; }

        public int EducationId { get; set; }
        public Education Education { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }
    }
}
