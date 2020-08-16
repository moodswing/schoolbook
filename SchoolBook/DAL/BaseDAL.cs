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
        protected readonly UserManager<User> _userManager;
        protected readonly ApplicationDbContext _dbContext;

        public BaseDAL(ILogger logger, UserManager<User> userManager, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _userManager = userManager;
            _dbContext = dbContext;
        }
    }
}
