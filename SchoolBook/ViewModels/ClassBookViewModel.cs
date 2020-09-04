using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolBook.Models;
using Microsoft.Extensions.Configuration;

namespace SchoolBook.ViewModels
{
    public class ClassBookViewModel
    {
        public string SubjectId { get; set; }
        public string PeriodId { get; set; }
        public decimal MinGrade { get; set; }
        public decimal MaxGrade { get; set; }
        public decimal FailedGrade { get; set; }

        public string SelectorChangeAction { get; set; }

        public List<SelectListItem> Subjects { get; set; }
        public List<Period> Periods { get; set; }
        public List<Student> Students { get; set; }
        public List<Evaluation> Evaluations { get; set; }

        public List<Evaluation> StudentEvaluations {
            get
            {
                if (Students == null || !Students.Any() || Students.First().Evaluations == null || !Students.First().Evaluations.Any())
                    return new List<Evaluation>();

                return Students.First().Evaluations.ToList();
            }
        }

        public IConfiguration Configuration { get; }

        public ClassBookViewModel()
        {
            Students = new List<Student>();
            Subjects = new List<SelectListItem>();
        }

        public ClassBookViewModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
