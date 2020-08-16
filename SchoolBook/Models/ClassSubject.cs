using System;
using System.Collections.Generic;

namespace SchoolBook.Models
{
    public class ClassSubject
    {
        public int Id { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public List<Evaluation> Evaluations { get; set; }
    }
}
