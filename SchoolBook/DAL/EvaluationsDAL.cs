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
    public class EvaluationsDAL : BaseDAL, IEvaluationsDAL
    {
        public EvaluationsDAL(ApplicationDbContext dbContext, ILogger<MenuOptionsDAL> logger) : base(dbContext, logger)
        {
        }

        public List<Evaluation> GetClassEvaluations(int classId, int subjectId, int periodId)
        {
            var result = _dbContext.Evaluations.AsNoTracking()
                    .Where(s => s.PeriodId == periodId && s.ClassSubject.ClassId == classId && s.ClassSubject.SubjectId == subjectId)
                    .ToList();

            return result;
        }
    }

    public interface IEvaluationsDAL
    {
        List<Evaluation> GetClassEvaluations(int classId, int subjectId, int periodId);
    }
}
