using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.Controllers;
using SchoolBook.Data;
using SchoolBook.Models;

namespace SchoolBook.ViewComponents
{
    public abstract class BaseViewComponent : ViewComponent
    {
        protected readonly ILogger Logger;
        protected readonly UserManager<User> UserManager;
        protected readonly ApplicationDbContext DbContext;

        protected BaseViewComponent(ILogger logger, UserManager<User> userManager, ApplicationDbContext dbContext)
        {
            UserManager = userManager;
            DbContext = dbContext;
            Logger = logger;
        }
    }
}
