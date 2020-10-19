using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolBook.Utils;

namespace SchoolBook.Models
{
    public class Evaluation : IListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(2,1)")]
        public decimal Coefficient { get; set; }
        public bool Active { get; set; }

        public int ClassSubjectId { get; set; }
        public ClassSubject ClassSubject { get; set; }

        public int PeriodId { get; set; }
        public TypePeriod Period { get; set; }

        public int TypeId { get; set; }
        public EvaluationType Type { get; set; }

        public List<EvaluationScore> Scores { get; set; }

        [NotMapped]
        public int Index { get; set; }
        [NotMapped]
        public EvaluationScore StudentScore { get; set; }
        [NotMapped]
        public List<SelectListItem> EvaluationTypes { get; set; }

        public string Text => Title;
        public string Value => Id.ToString();
        public string SuperiorId => string.Empty;
    }
}
