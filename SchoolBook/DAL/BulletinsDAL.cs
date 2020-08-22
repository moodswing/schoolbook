using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolBook.Data;
using SchoolBook.Models;

namespace SchoolBook.DAL
{
    public class BulletinsDAL : BaseDAL, IBulletinsDAL
    {
        public BulletinsDAL(ApplicationDbContext dbContext, ILogger<MenuOptionsDAL> logger) : base(dbContext, logger)
        {
        }

        public List<Bulletin> GetBulletins()
        {
            return _dbContext.Bulletins.ToList();
        }
    }

    public interface IBulletinsDAL
    {
        List<Bulletin> GetBulletins();
    }
}
