using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBook.Models
{
    public class EvaluationObservation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastModification { get; set; }

        public User Observer { get; set; }
        public string ObserverId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int EvaluationId { get; set; }
        public Evaluation Evaluation { get; set; }

        public int? AuthorizationRequestId { get; set; }
        public AuthorizationRequest AuthorizationRequest { get; set; }

        [NotMapped]
        public int Index { get; set; }
    }
}
