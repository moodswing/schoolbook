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
            var result = _dbContext.StudentsClasses.Include("Student.Scores.Evaluation.ClassSubject").Where(s => s.ClassId == classId).Select(s => s.Student).OrderBy(s => s.Name).ToList();

            foreach(var student in result)
                student.Scores = student.Scores.Where(s => s.Evaluation.PeriodId == periodId && s.Evaluation.ClassSubject.ClassId == classId && s.Evaluation.ClassSubject.SubjectId == subjectId).ToList();

            return result;
        }
    }

    public interface IStudentsDAL
    {
        List<Student> GetClassScores(int classId, int subjectId, int periodId);
    }
}
