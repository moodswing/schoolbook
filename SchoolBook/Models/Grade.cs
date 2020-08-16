using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBook.Utils;

namespace SchoolBook.Models
{
    public class Grade : IListItem
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int YearId { get; set; }
        public SchoolYear Year { get; set; }

        public  List<EducationGrade> EducationGrades { get; set; }

        [NotMapped]
        public string Text => Description;
        [NotMapped]
        public string Value => Id.ToString();
        [NotMapped]
        public string SuperiorId => YearId.ToString();
    }
}
