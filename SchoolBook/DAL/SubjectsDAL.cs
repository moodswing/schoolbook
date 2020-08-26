using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolBook.Data;
using SchoolBook.Models;

namespace SchoolBook.DAL
{
    public class SubjectsDAL : BaseDAL, ISubjectsDAL
    {
        public SubjectsDAL(ApplicationDbContext dbContext, ILogger<MenuOptionsDAL> logger) : base(dbContext, logger)
        {
        }

        public List<SelectListItem> GetSubjectsDdl(int classId)
        {
            return _dbContext.ClassSubjects.Include(c => c.Subject)
                .Where(c => c.ClassId == classId)
                .Select(e => new SelectListItem { Text = e.Subject.Description, Value = e.Subject.Id.ToString() }).ToList();
        }
    }

    public interface ISubjectsDAL
    {
        List<SelectListItem> GetSubjectsDdl(int classId);
    }
}
