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
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.IO;
using Azure;
using System.Text.Json;
using SchoolBook.Utils;

namespace SchoolBook.Controllers
{
    public class ClassBookController : BaseController
    {
        public IConfiguration Configuration { get; }
        public ISubjectsDAL SubjectsDAL { get; }
        public IEvaluationsDAL EvaluationsDAL { get; }
        public IAuthorizationRequestDAL AuthorizationRequestDAL { get; }
        public UserManager<User> UserManager { get; }
        public IStudentsDAL StudentsDAL { get; }
        public IPeriodsDAL PeriodsDAL { get; }
        public ILogger<DashboardController> Logger { get; }

        public ClassBookController(IStudentsDAL studentsDAL, IPeriodsDAL periodsDAL, ISubjectsDAL subjectsDAL, IEvaluationsDAL evaluationsDAL, IAuthorizationRequestDAL authorizationRequestDAL,
            IUsersDAL usersDAL, UserManager<User> userManager, IConfiguration configuration, ILogger<DashboardController> logger) : base(usersDAL)
        {
            Configuration = configuration;
            SubjectsDAL = subjectsDAL;
            EvaluationsDAL = evaluationsDAL;
            AuthorizationRequestDAL = authorizationRequestDAL;
            UserManager = userManager;
            StudentsDAL = studentsDAL;
            PeriodsDAL = periodsDAL;
            Logger = logger;
        }

        #region GradeBook

        [Authorize]
        public IActionResult Index()
        {
            var viewModel = UsersDAL.GetUserSelection<ClassBookViewModel>(SelectionType.Filters);

            if (int.TryParse(FiltersSelection.ClassId, out int classId))
                viewModel.Subjects = SubjectsDAL.GetSubjectsDdl(classId);

            if (int.TryParse(FiltersSelection.YearId, out int yearId))
                viewModel.Periods = PeriodsDAL.GetYearPeriods(yearId);
            else
                viewModel.Periods = PeriodsDAL.GetCurrentYearPeriods();

            if (int.TryParse(viewModel.SubjectId, out int subjectId) && int.TryParse(viewModel.PeriodId, out int periodId))
                viewModel.Students = StudentsDAL.GetClassScores(classId, subjectId, periodId);

            if (classId != 0 && subjectId != 0 && UsersDAL.IsUserClassTeacher(classId, subjectId))
                viewModel.ActionPermissions.Add(ActionPermission.EditGrades);

            viewModel.MinGrade = decimal.Parse(Configuration["AppSettings:MinGrade"]);
            viewModel.MaxGrade = decimal.Parse(Configuration["AppSettings:MaxGrade"]);
            viewModel.FailedGrade = decimal.Parse(Configuration["AppSettings:FailedGrade"]);

            viewModel.SelectorChangeAction = "/ClassBook/GetGradesBook";

            return View(viewModel);
        }

        [Authorize]
        public IActionResult GetGradesBook(int subjectId, int PeriodId, string selection)
        {
            var viewModel = new ClassBookViewModel();

            if (int.TryParse(FiltersSelection.ClassId, out int classId) && subjectId != 0)
            {
                viewModel.Students = StudentsDAL.GetClassScores(classId, subjectId, PeriodId);

                if (UsersDAL.IsUserClassTeacher(classId, subjectId))
                    viewModel.ActionPermissions.Add(ActionPermission.EditGrades);
            }

            viewModel.MinGrade = decimal.Parse(Configuration["AppSettings:MinGrade"]);
            viewModel.MaxGrade = decimal.Parse(Configuration["AppSettings:MaxGrade"]);
            viewModel.FailedGrade = decimal.Parse(Configuration["AppSettings:FailedGrade"]);

            
            UsersDAL.SaveUserSelection(SelectionType.Filters, selection);

            return PartialView("_GradesBook", viewModel);
        }

        [Authorize]
        public IActionResult SaveGradesBook(List<Student> students)
        {
            try
            {
                StudentsDAL.UpdateClassScores(students);
                return Json(new { state = "ok", message = "Se han actualizado las notas con éxito!" });
            }
            catch (Exception ex)
            {
                Logger.LogError("Ha ocurrido un error: " + ex.Message + " - Stacktrace: " + ex.StackTrace);
                return Json(new { state = "error", message = "Ha ocurrido un error, favor contactarse con el administrador." });
            }
        }

        #endregion

        #region Evaluations

        [Authorize]
        public IActionResult Evaluations()
        {
            var viewModel = UsersDAL.GetUserSelection<ClassBookViewModel>(SelectionType.Filters);

            if (int.TryParse(FiltersSelection.ClassId, out int classId))
                viewModel.Subjects = SubjectsDAL.GetSubjectsDdl(classId);

            if (int.TryParse(FiltersSelection.YearId, out int yearId))
                viewModel.Periods = PeriodsDAL.GetYearPeriods(yearId);
            else
                viewModel.Periods = PeriodsDAL.GetCurrentYearPeriods();

            if (!string.IsNullOrEmpty(viewModel.SubjectId) && !string.IsNullOrEmpty(viewModel.PeriodId))
                viewModel.Evaluations = EvaluationsDAL.GetClassEvaluations(classId, Convert.ToInt32(viewModel.SubjectId), Convert.ToInt32(viewModel.PeriodId));

            viewModel.SelectorChangeAction = "/ClassBook/GetEvaluations";
            viewModel.EvaluationTypes = EvaluationsDAL.GetEvaluationTypes();

            return View(viewModel);
        }

        [Authorize]
        public IActionResult GetEvaluations(int SubjectId, int PeriodId, string selection)
        {
            var viewModel = new ClassBookViewModel();

            if (SubjectId != 0 && int.TryParse(FiltersSelection.ClassId, out int classId))
                viewModel.Evaluations = EvaluationsDAL.GetClassEvaluations(classId, SubjectId, PeriodId);

            viewModel.EvaluationTypes = EvaluationsDAL.GetEvaluationTypes();

            UsersDAL.SaveUserSelection(SelectionType.Filters, selection);

            return PartialView("_ListEvaluations", viewModel);
        }

        [Authorize]
        public IActionResult GetNewEvaluation(int SubjectId, int PeriodId, int ClassId, int index)
        {
            var viewModel = EvaluationsDAL.GetNewEvaluation(ClassId, SubjectId, PeriodId);

            viewModel.EvaluationTypes = EvaluationsDAL.GetEvaluationTypes();
            viewModel.Index = index;

            return PartialView("_EditEvaluation", viewModel);
        }

        [Authorize]
        public IActionResult SaveEvaluation(Evaluation evaluation)
        {
            try
            {
                var idEvaluation = EvaluationsDAL.SaveEvaluation(evaluation);

                return Json(new { state = "ok", message = "Se ha guardado la evaluación con éxito!", id = idEvaluation });
            }
            catch (Exception ex)
            {
                Logger.LogError("Ha ocurrido un error: " + ex.Message + " - Stacktrace: " + ex.StackTrace);
                return Json(new { state = "error", message = "Ha ocurrido un error, favor contactarse con el administrador." });
            }
        }

        #endregion

        #region Observations

        [Authorize]
        public IActionResult Observations()
        {
            var viewModel = UsersDAL.GetUserSelection<ClassBookViewModel>(SelectionType.Observations);

            if (int.TryParse(FiltersSelection.ClassId, out int classId))
                viewModel.Subjects = SubjectsDAL.GetSubjectsDdl(classId);

            if (int.TryParse(FiltersSelection.YearId, out int yearId))
                viewModel.Periods = PeriodsDAL.GetYearPeriods(yearId);
            else
                viewModel.Periods = PeriodsDAL.GetCurrentYearPeriods();

            if (classId != 0 && int.TryParse(viewModel.SubjectId, out int subjectId) && int.TryParse(viewModel.PeriodId, out int periodId))
                viewModel.Students = StudentsDAL.GetClassStudentsEvaluations(classId, subjectId, periodId);

            if (int.TryParse(viewModel.StudentId, out int studentId) && int.TryParse(viewModel.EvaluationId, out int evaluationId))
                viewModel.Observations = EvaluationsDAL.GetStudentEvaluationObservations(studentId, evaluationId);

            viewModel.FilterAction = "/ClassBook/GetObservationFilters";
            viewModel.SelectorChangeAction = "/ClassBook/GetObservations";

            return View(viewModel);
        }

        [Authorize]
        public IActionResult GetObservationFilters(int SubjectId, int PeriodId, string selection)
        {
            var viewModel = JsonSerializer.Deserialize<ClassBookViewModel>(selection);

            if (int.TryParse(FiltersSelection.ClassId, out int classId))
                viewModel.Students = StudentsDAL.GetClassStudentsEvaluations(classId, SubjectId, PeriodId);

            UsersDAL.SaveUserSelection(SelectionType.Observations, selection);

            return PartialView("_StudentEvaluationSelector", viewModel);
        }

        [Authorize]
        public IActionResult GetObservations(int studentId, int evaluationId, string selection)
        {
            var viewModel = JsonSerializer.Deserialize<ClassBookViewModel>(selection);
            viewModel.Observations = EvaluationsDAL.GetStudentEvaluationObservations(studentId, evaluationId);

            UsersDAL.SaveUserSelection(SelectionType.Observations, selection);

            return PartialView("_ListObservations", viewModel);
        }

        [Authorize]
        public IActionResult SaveObservation(EvaluationObservation observation)
        {
            try
            {
                var idObservation = EvaluationsDAL.SaveObservation(observation);
                return Json(new { state = "ok", message = "Se ha guardado la observación con éxito!", id = idObservation });
            }
            catch (Exception ex)
            {
                Logger.LogError("Ha ocurrido un error: " + ex.Message + " - Stacktrace: " + ex.StackTrace);
                return Json(new { state = "error", message = "Ha ocurrido un error, favor contactarse con el administrador." });
            }
        }

        [Authorize]
        public IActionResult GetNewObservation(int studentId, int evaluationId, bool modal = false)
        {
            var partialView = modal ? "_AddObservationModal" : "_AddObservation";
            return PartialView(partialView, EvaluationsDAL.GetNewEvaluationObservation(studentId, evaluationId));
        }

        #endregion

        #region Anotations

        [Authorize]
        public IActionResult Anotations()
        {
            var viewModel = UsersDAL.GetUserSelection<ClassBookViewModel>(SelectionType.Anotations);

            if (int.TryParse(FiltersSelection.ClassId, out int classId))
            {
                viewModel.Students = StudentsDAL.GetClassStudents(classId);
                viewModel.ClassAnotations = StudentsDAL.GetClassAnotations(classId);
            }

            if (int.TryParse(viewModel.StudentId, out int studentId))
                viewModel.StudentAnotations = StudentsDAL.GetStudentAnotations(studentId);

            viewModel.SelectorChangeAction = "/ClassBook/GetAnotations";

            return View(viewModel);
        }

        [Authorize]
        public IActionResult GetAnotations(int studentId, int classId, string selection)
        {
            var viewModel = JsonSerializer.Deserialize<ClassBookViewModel>(selection);

            viewModel.StudentAnotations = StudentsDAL.GetStudentAnotations(studentId);
            viewModel.ClassAnotations = StudentsDAL.GetClassAnotations(classId);

            UsersDAL.SaveUserSelection(SelectionType.Anotations, selection);

            return PartialView("_ListAnotations", viewModel);
        }

        [Authorize]
        public IActionResult GetNewAnotation(int classId)
        {
            return PartialView("_AddAnotation", StudentsDAL.GetNewAnotation(classId));
        }

        [Authorize]
        public IActionResult SaveAnotation(Anotation anotation)
        {
            try
            {
                var idAnotation = StudentsDAL.SaveAnotation(anotation);
                return Json(new { state = "ok", message = "Se ha guardado la anotación con éxito!", id = idAnotation });
            }
            catch (Exception ex)
            {
                Logger.LogError("Ha ocurrido un error: " + ex.Message + " - Stacktrace: " + ex.StackTrace);
                return Json(new { state = "error", message = "Ha ocurrido un error, favor contactarse con el administrador." });
            }
        }

        #endregion

        #region Shared functions

        [Authorize]
        public IActionResult GetRegisterCancelation(int registerId, int type)
        {
            return PartialView("_ModalCancelRegister", AuthorizationRequestDAL.GetNewAuthorization(registerId, (AuthorizationType)type));
        }

        [Authorize]
        public IActionResult CancelRegister(int registerId, AuthorizationType type, string observation)
        {
            try
            {
                AuthorizationRequestDAL.RequestCancelAuthorization(registerId, type, observation);
                return Json(new { state = "ok", message = "La solicitud se ha realizado con éxito!" });
            }
            catch (Exception ex)
            {
                Logger.LogError("Ha ocurrido un error: " + ex.Message + " - Stacktrace: " + ex.StackTrace);
                return Json(new { state = "error", message = "Ha ocurrido un error, favor contactarse con el administrador." });
            }
        }

        #endregion
    }
}
