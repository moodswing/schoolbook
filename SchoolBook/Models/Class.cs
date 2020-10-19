using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBook.Utils;

namespace SchoolBook.Models
{
    public class Class : IListItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Abbreviation { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public List<ClassSubject> ClassSubjects { get; set; }
        public List<StudentClass> StudentClass { get; set; }

        public string Text => Description;
        public string Value => Id.ToString();
        public string SuperiorId => GradeId.ToString();
    }
}
