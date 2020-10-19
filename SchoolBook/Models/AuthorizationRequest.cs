using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBook.Models
{
    public class AuthorizationRequest
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Observation { get; set; }

        public AuthorizationType Type { get; set; }
        public AuthorizationStatus Status { get; set; }

        public string ResolvedById { get; set; }
        public User ResolvedBy { get; set; }

        [NotMapped]
        public int RegisterId { get; set; }

        [NotMapped]
        public List<User> Approvers { get; set; }
    }

    public enum AuthorizationType
    {
        [Display(Name = "Anular Observación")]
        CancelObservation = 1,
        [Display(Name = "Anular Anotación")]
        CancelAnnotation = 2
    }

    public enum AuthorizationStatus
    {
        [Display(Name = "Pendiente")]
        Pending,
        [Display(Name = "Aprobado")]
        Approved,
        [Display(Name = "Rechazado")]
        Denied
    }
}