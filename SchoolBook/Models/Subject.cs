using System;
using System.Collections.Generic;

namespace SchoolBook.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<ClassSubject> ClassSubjects { get; set; }
    }
}
