using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolBook.Models;

namespace SchoolBook.ViewModels
{
    public class ClassBookViewModel
    {
        public string SubjectId { get; set; }
        public string PeriodId { get; set; }

        public List<SelectListItem> Subjects { get; set; }
        public List<Period> Periods { get; set; }
        public List<Student> Students { get; set; }

        public List<Evaluation> Evaluations {
            get
            {
                if (Students == null || !Students.Any() || Students.First().Scores == null || !Students.First().Scores.Any())
                    return new List<Evaluation>();

                return Students.First().Scores.Select(s => s.Evaluation).ToList();
            }
        }

        public ClassBookViewModel()
        {
            Students = new List<Student>();
            Subjects = new List<SelectListItem>();
        }
    }
}
