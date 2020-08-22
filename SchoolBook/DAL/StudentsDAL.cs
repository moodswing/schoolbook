using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolBook.Data;
using SchoolBook.Models;

namespace SchoolBook.DAL
{
    public class StudentsDAL : BaseDAL, IStudentsDAL
    {
        public ClaimsPrincipal User { get; }

        public StudentsDAL(ClaimsPrincipal user, ApplicationDbContext dbContext, ILogger<MenuOptionsDAL> logger) : base(dbContext, logger)
        {
            User = user;
        }

        public List<Student> GetClassStudents(int classId)
        {
            return _dbContext.StudentsClasses.Where(s => s.ClassId.Equals(classId)).Select(s => s.Student).OrderBy(s => s.Name).ToList();
        }
    }

    public interface IStudentsDAL
    {
        List<Student> GetClassStudents(int classId);
    }
}
