using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolBook.Models;
using Microsoft.Extensions.Configuration;
using SchoolBook.Utils;

namespace SchoolBook.ViewModels
{
    public class ClassBookViewModel
    {
        public string SubjectId { get; set; }
        public string PeriodId { get; set; }
        public string StudentId { get; set; }
        public string EvaluationId { get; set; }
        public decimal MinGrade { get; set; }
        public decimal MaxGrade { get; set; }
        public decimal FailedGrade { get; set; }

        public string FilterAction { get; set; }
        public string SelectorChangeAction { get; set; }

        public List<Period> Periods { get; set; }
        public List<Evaluation> Evaluations { get; set; }
        public List<EvaluationObservation> Observations { get; set; }
        public List<Anotation> StudentAnotations { get; set; }
        public List<Anotation> ClassAnotations { get; set; }
        public List<SelectListItem> Subjects { get; set; }
        public List<SelectListItem> EvaluationTypes { get; set; }

        public List<ActionPermission> ActionPermissions { get; set; }

        public AuthorizationRequest CancelRequest { get; set; }

        private List<Student> students;
        public List<Student> Students
        {
            get => students;
            set
            {
                if (int.TryParse(StudentId, out int studentId) && !value.Any(s => s.Id == studentId))
                    StudentId = "";

                students = value;

                if (int.TryParse(EvaluationId, out int evaluationId) && !StudentEvaluations.Any(s => s.Id == evaluationId))
                    EvaluationId = "";
            }
        }

        public List<Evaluation> StudentEvaluations
        {
            get
            {
                if (Students == null || !Students.Any() || Students.First().Evaluations == null || !Students.First().Evaluations.Any())
                    return new List<Evaluation>();

                return Students.First().Evaluations.ToList();
            }
        }

        public ClassBookViewModel()
        {
            Students = new List<Student>();
            Subjects = new List<SelectListItem>();
            ActionPermissions = new List<ActionPermission>();

            CancelRequest = new AuthorizationRequest();
        }
    }
}
