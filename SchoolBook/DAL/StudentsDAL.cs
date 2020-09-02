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

namespace SchoolBook.DAL
{
    public class StudentsDAL : BaseDAL, IStudentsDAL
    {
        public ClaimsPrincipal User { get; }

        public StudentsDAL(ClaimsPrincipal user, ApplicationDbContext dbContext, ILogger<MenuOptionsDAL> logger) : base(dbContext, logger)
        {
            User = user;
        }

        public List<Student> GetClassScores(int classId, int subjectId, int periodId)
        {
            //_dbContext.ChangeTracker.LazyLoadingEnabled = false;
            var result = _dbContext.StudentsClasses
                .Include("Student")
                .Where(s => s.ClassId == classId).Select(s => s.Student).OrderBy(s => s.Name).ToList();

            foreach(var student in result)
            {
                student.Evaluations = _dbContext.Evaluations.AsNoTracking()
                    .Include(e => e.Scores)
                    .Where(s => s.PeriodId == periodId && s.ClassSubject.ClassId == classId && s.ClassSubject.SubjectId == subjectId)
                    .ToList();

                foreach(var eval in student.Evaluations)
                    //_dbContext.Entry(eval).State = EntityState.Detached;
                    eval.StudentScore = eval.Scores.FirstOrDefault(s => s.StudentId == student.Id && s.EvaluationId == eval.Id);
            }

            return result;
        }

        public void UpdateClassScores(List<Student> students)
        {
            foreach(var student in students)
                foreach(var evaluation in student.Evaluations)
                {
                    var score = evaluation.StudentScore.Id != 0 ? _dbContext.Scores.FirstOrDefault(s => s.Id == evaluation.StudentScore.Id) : _dbContext.Scores.FirstOrDefault(s => s.EvaluationId == evaluation.Id && s.StudentId == student.Id) ?? new EvaluationScore();
                    score.Score = evaluation.StudentScore.Score;

                    if (score.Id == 0)
                    {
                        score.EvaluationId = evaluation.Id;
                        score.StudentId = student.Id;

                        _dbContext.Scores.Add(score);
                    }
                }

            _dbContext.SaveChanges();
        }
    }

    public interface IStudentsDAL
    {
        List<Student> GetClassScores(int classId, int subjectId, int periodId);
        public void UpdateClassScores(List<Student> students);
    }
}
