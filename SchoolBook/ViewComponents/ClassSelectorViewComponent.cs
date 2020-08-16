using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.Controllers;
using SchoolBook.Data;
using SchoolBook.Models;
using SchoolBook.ViewModels;

namespace SchoolBook.ViewComponents
{
    public class ClassSelectorViewComponent : BaseViewComponent
    {
        public ClassSelectorViewComponent(ILogger<SidebarViewComponent> logger, UserManager<User> userManager, ApplicationDbContext dbContext) : base(logger, userManager, dbContext)
        {
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new ClassSelectorViewModel
            {
                Years = DbContext.SchoolYears.ToList(),
                Grades = DbContext.Grades.ToList(),
                Classes = DbContext.Classes.ToList()
            };

            return View(viewModel);
        }
    }
}
