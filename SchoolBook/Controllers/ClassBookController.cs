using SchoolBook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SchoolBook.DAL;
using System.Linq;
using SchoolBook.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace SchoolBook.Controllers
{
    public class ClassBookController : BaseController
    {
        public IConfiguration Configuration { get; }
        public ISubjectsDAL SubjectsDAL { get; }
        public IStudentsDAL StudentsDAL { get; }
        public IPeriodsDAL PeriodsDAL { get; }
        public ILogger<DashboardController> Logger { get; }

        public ClassBookController(IStudentsDAL studentsDAL, IPeriodsDAL periodsDAL, ISubjectsDAL subjectsDAL,
            IUsersDAL usersDAL, IConfiguration configuration, ILogger<DashboardController> logger) : base(usersDAL)
        {
            Configuration = configuration;
            SubjectsDAL = subjectsDAL;
            StudentsDAL = studentsDAL;
            PeriodsDAL = periodsDAL;
            Logger = logger;
        }

        [Authorize]
        public IActionResult Index(int subjectId = 0)
        {
            var viewModel = UsersDAL.GetUserSelection<ClassBookViewModel>(SelectionType.GradeBook);

            if (int.TryParse(ClassSelection.ClassId, out int classId))
                viewModel.Subjects = SubjectsDAL.GetSubjectsDdl(classId);

            if (int.TryParse(ClassSelection.YearId, out int yearId))
                viewModel.Periods = PeriodsDAL.GetYearPeriods(yearId);
            else
                viewModel.Periods = PeriodsDAL.GetCurrentYearPeriods();

            if (!string.IsNullOrEmpty(viewModel.SubjectId) && !string.IsNullOrEmpty(viewModel.PeriodId))
                viewModel.Students = StudentsDAL.GetClassScores(classId, Convert.ToInt32(viewModel.SubjectId), Convert.ToInt32(viewModel.PeriodId));

            viewModel.MinGrade = Decimal.Parse(Configuration["AppSettings:MinGrade"]);
            viewModel.MaxGrade = Decimal.Parse(Configuration["AppSettings:MaxGrade"]);
            viewModel.FailedGrade = Decimal.Parse(Configuration["AppSettings:FailedGrade"]);

            return View(viewModel);
        }

        [Authorize]
        public IActionResult GetGradesBook(int subjectId, int periodId, string selection)
        {
            var viewModel = new ClassBookViewModel();

            if (subjectId != 0 && int.TryParse(ClassSelection.ClassId, out int classId))
                viewModel.Students = StudentsDAL.GetClassScores(classId, subjectId, periodId);

            viewModel.MinGrade = Decimal.Parse(Configuration["AppSettings:MinGrade"]);
            viewModel.MaxGrade = Decimal.Parse(Configuration["AppSettings:MaxGrade"]);
            viewModel.FailedGrade = Decimal.Parse(Configuration["AppSettings:FailedGrade"]);
            
            UsersDAL.SaveUserSelection(SelectionType.GradeBook, selection);

            return PartialView("_GradesBook", viewModel);
        }

        [Authorize]
        public IActionResult SaveGradesBook(List<Student> students)
        {
            StudentsDAL.UpdateClassScores(students);

            return Json("ok");
        }
    }
}
