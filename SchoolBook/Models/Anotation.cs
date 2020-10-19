using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using SchoolBook.Utils;

namespace SchoolBook.Models
{
    public class Anotation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastModification { get; set; }

        public AnotationType Type { get; set; }
        public AnotationReceiver Receiver { get; set; }

        public User Observer { get; set; }
        public string ObserverId { get; set; }

        public List<StudentAnotation> StudentAnotations { get; set; }

        public int? ClassId { get; set; }
        public Class Class { get; set; }

        public int? AuthorizationRequestId { get; set; }
        public AuthorizationRequest AuthorizationRequest { get; set; }

        [NotMapped]
        public List<Student> Students { get; set; }

        [NotMapped]
        public int Index { get; set; }

        public string TypeDescription => EnumHelper<AnotationType>.GetDisplayValue(Type);
        public List<IListItem> TypesList => EnumHelper<AnotationType>.GetListItems(Type);

        public string ReceiverDescription => Receiver == AnotationReceiver.Class ?
            Class.Grade.Description + " " + Class.Description : string.Join(", ", Students.Select(s => s.Name));

        public List<IListItem> ReceiverList => EnumHelper<AnotationReceiver>.GetListItems(Receiver);
    }

    public enum AnotationType
    {
        [Display(Name = "Negativa")]
        Negative,
        [Display(Name = "Positiva")]
        Positive
    }

    public enum AnotationReceiver
    {
        [Display(Name = "Estudiante")]
        Students = 1,
        [Display(Name = "Curso")]
        Class = 2
    }
}
