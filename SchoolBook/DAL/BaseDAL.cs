using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolBook.Data;
using SchoolBook.Models;

namespace SchoolBook.DAL
{
    public class BaseDAL
    {
        protected readonly ILogger _logger;
        protected readonly ApplicationDbContext _dbContext;

        public BaseDAL(ApplicationDbContext dbContext, ILogger logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
    }
}
