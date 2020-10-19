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
        public UserManager<User> UserManager { get; }
        public ClaimsPrincipal User { get; }

        public StudentsDAL(ClaimsPrincipal user, ApplicationDbContext dbContext, UserManager<User> userManager, ILogger<MenuOptionsDAL> logger) : base(dbContext, logger)
        {
            User = user;
            UserManager = userManager;
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
                    .Where(s => s.PeriodId == periodId && s.ClassSubject.ClassId == classId && s.ClassSubject.SubjectId == subjectId).ToList();

                foreach(var eval in student.Evaluations)
                    //_dbContext.Entry(eval).State = EntityState.Detached;
                    eval.StudentScore = eval.Scores.FirstOrDefault(s => s.StudentId == student.Id && s.EvaluationId == eval.Id);
            }

            return result;
        }

        public List<Student> GetClassStudentsEvaluations(int classId, int subjectId, int periodId)
        {
            var result = _dbContext.StudentsClasses
                .Include("Student")
                .Where(s => s.ClassId == classId).Select(s => s.Student).OrderBy(s => s.Name).ToList();

            foreach (var student in result)
                student.Evaluations = _dbContext.Evaluations.AsNoTracking()
                    .Where(s => s.PeriodId == periodId && s.ClassSubject.ClassId == classId && s.ClassSubject.SubjectId == subjectId).ToList();

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

        public List<Student> GetClassStudents(int classId)
        {
            var result = _dbContext.StudentsClasses
                .Include("Student")
                .Where(s => s.ClassId == classId).Select(s => s.Student).OrderBy(s => s.Name).ToList();

            return result;
        }

        public List<Anotation> GetStudentAnotations(int studentId)
        {
            var result = _dbContext.Anotations.Include(a => a.Observer).Include("StudentAnotations.Student").AsNoTracking()
                    .Where(s => s.Receiver == AnotationReceiver.Students && s.StudentAnotations.Any(s => s.Student.Id == studentId))
                    .ToList();

            foreach (var annotation in result)
                annotation.Students = annotation.StudentAnotations.Select(s => s.Student).ToList();

            return result;
        }

        public List<Anotation> GetClassAnotations(int classId)
        {
            var result = _dbContext.Anotations.Include(a => a.Observer).Include("Class.Grade").AsNoTracking()
                    .Where(s => s.ClassId == classId && s.Receiver == AnotationReceiver.Class)
                    .ToList();

            return result;
        }

        public Anotation GetNewAnotation(int classId)
        {
            var anotation = new Anotation
            {
                ObserverId = UserManager.GetUserId(User),
                Students = GetClassStudents(classId),
                Class = _dbContext.Classes.Include(c => c.Grade).FirstOrDefault(c => c.Id == classId)
            };

            return anotation;
        }

        public int SaveAnotation(Anotation anotation)
        {
            var studentAnotations = new List<StudentAnotation>();

            if (anotation.Students != null)
                foreach (var student in anotation.Students)
                    studentAnotations.Add(new StudentAnotation
                    {
                        AnotationId = anotation.Id,
                        StudentId = student.Id
                    });

            if (anotation.Id == 0)
            {
                anotation.StudentAnotations = studentAnotations;
                _dbContext.Anotations.Add(anotation);
            }
            else
            {
                var dbAnotation = _dbContext.Anotations.FirstOrDefault(e => e.Id == anotation.Id);

                dbAnotation.Title = anotation.Title;
                dbAnotation.Date = anotation.Date;
                dbAnotation.ObserverId = anotation.ObserverId;
                dbAnotation.Receiver = anotation.Receiver;
                dbAnotation.ClassId = anotation.ClassId;
                dbAnotation.Type = anotation.Type;
                dbAnotation.LastModification = DateTime.Now;

                dbAnotation.StudentAnotations = studentAnotations;
            }

            _dbContext.SaveChanges();

            return anotation.Id;
        }
    }

    public interface IStudentsDAL
    {
        List<Student> GetClassScores(int classId, int subjectId, int periodId);
        List<Student> GetClassStudentsEvaluations(int classId, int subjectId, int periodId);
        List<Student> GetClassStudents(int classId);
        List<Anotation> GetStudentAnotations(int studentId);
        List<Anotation> GetClassAnotations(int classId);
        Anotation GetNewAnotation(int classId);
        int SaveAnotation(Anotation anotation);
        void UpdateClassScores(List<Student> students);
    }
}
