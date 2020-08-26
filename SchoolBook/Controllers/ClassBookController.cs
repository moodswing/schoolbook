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

namespace SchoolBook.Controllers
{
    public class ClassBookController : BaseController
    {
        public ISubjectsDAL SubjectsDAL { get; }
        public IStudentsDAL StudentsDAL { get; }
        public IPeriodsDAL PeriodsDAL { get; }
        public ILogger<DashboardController> Logger { get; }

        public ClassBookController(IStudentsDAL studentsDAL, IPeriodsDAL periodsDAL, ISubjectsDAL subjectsDAL, IUsersDAL usersDAL, ILogger<DashboardController> logger) : base(usersDAL)
        {
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

            return View(viewModel);
        }

        [Authorize]
        public IActionResult GetGradesBook(int subjectId, int periodId, string selection)
        {
            var viewModel = new ClassBookViewModel();

            if (subjectId != 0 && int.TryParse(ClassSelection.ClassId, out int classId))
                viewModel.Students = StudentsDAL.GetClassScores(classId, subjectId, periodId);

            UsersDAL.SaveUserSelection(SelectionType.GradeBook, selection);

            return PartialView("_GradesBook", viewModel);
        }
    }
}
