using System;
namespace SchoolBook.Models
{
    public class StudentAnotation
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int AnotationId { get; set; }
        public Anotation Anotation { get; set; }
    }
}
