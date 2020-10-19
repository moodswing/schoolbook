using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolBook.Data;
using SchoolBook.Models;
using Microsoft.EntityFrameworkCore;
using SchoolBook.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolBook.DAL
{
    public class EvaluationsDAL : BaseDAL, IEvaluationsDAL
    {
        public UserManager<User> UserManager { get; }
        public ClaimsPrincipal User { get; }

        public EvaluationsDAL(ApplicationDbContext dbContext, UserManager<User> userManager, ClaimsPrincipal user, ILogger<MenuOptionsDAL> logger) : base(dbContext, logger)
        {
            UserManager = userManager;
            User = user;
        }

        public List<Evaluation> GetClassEvaluations(int classId, int subjectId, int periodId)
        {
            var result = _dbContext.Evaluations.AsNoTracking()
                    .Where(s => s.PeriodId == periodId && s.ClassSubject.ClassId == classId && s.ClassSubject.SubjectId == subjectId)
                    .ToList();

            return result;
        }

        public List<SelectListItem> GetEvaluationTypes()
        {
            return _dbContext.EvaluationTypes.Select(t => new SelectListItem { Text = t.Description, Value = t.Id.ToString() }).ToList();
        }

        public Evaluation GetNewEvaluation(int classId, int subjectId, int periodId)
        {
            var newEvaluation = new Evaluation();
            newEvaluation.PeriodId = periodId;
            newEvaluation.Coefficient = 1;

            var classSubject = _dbContext.ClassSubjects.FirstOrDefault(cs => cs.SubjectId == subjectId && cs.ClassId == classId);
            newEvaluation.ClassSubjectId = classSubject.Id;

            return newEvaluation;
        }

        public EvaluationObservation GetNewEvaluationObservation(int studentId, int evaluationId)
        {
            var observation = new EvaluationObservation
            {
                Date = DateTime.Today,
                EvaluationId = evaluationId,
                StudentId = studentId,
                ObserverId = UserManager.GetUserId(User),
                Student = _dbContext.Students.FirstOrDefault(s => s.Id == studentId),
                Evaluation = _dbContext.Evaluations.FirstOrDefault(s => s.Id == evaluationId)
            };

            return observation;
        }

        public int SaveEvaluation(Evaluation evaluation)
        {
            if (evaluation.Id == 0)
                _dbContext.Evaluations.Add(evaluation);
            else
            {
                var dbEvaluation = _dbContext.Evaluations.FirstOrDefault(e => e.Id == evaluation.Id);

                dbEvaluation.Date = evaluation.Date;
                dbEvaluation.Title = evaluation.Title;
                dbEvaluation.Description = evaluation.Description;
                dbEvaluation.Active = evaluation.Active;
                dbEvaluation.Coefficient = evaluation.Coefficient;
                dbEvaluation.TypeId = evaluation.TypeId;
            }

            _dbContext.SaveChanges();

            return evaluation.Id;
        }

        public int SaveObservation(EvaluationObservation observation)
        {
            if (observation.Id == 0)
                _dbContext.Observations.Add(observation);
            else
            {
                var dbObservation = _dbContext.Observations.FirstOrDefault(e => e.Id == observation.Id);

                dbObservation.Description = observation.Description;
                dbObservation.LastModification = observation.Date;
            }

            _dbContext.SaveChanges();

            return observation.Id;
        }

        public List<EvaluationObservation> GetStudentEvaluationObservations(int studentId, int evaluationId)
        {
            var result = _dbContext.Observations.Include(o => o.Observer).Include(o => o.AuthorizationRequest).AsNoTracking()
                    .Where(s => s.StudentId == studentId && s.EvaluationId == evaluationId)
                    .ToList();

            return result;
        }
    }

    public interface IEvaluationsDAL
    {
        List<Evaluation> GetClassEvaluations(int classId, int subjectId, int periodId);
        List<SelectListItem> GetEvaluationTypes();
        int SaveEvaluation(Evaluation evaluation);
        int SaveObservation(EvaluationObservation observation);
        Evaluation GetNewEvaluation(int classId, int subjectId, int periodId);
        EvaluationObservation GetNewEvaluationObservation(int studentId, int evaluationId);
        List<EvaluationObservation> GetStudentEvaluationObservations(int studentId, int evaluationId);
    }
}
