using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.Controllers;
using SchoolBook.DAL;
using SchoolBook.Data;
using SchoolBook.Models;
using SchoolBook.ViewModels;

namespace SchoolBook.ViewComponents
{
    public class ClassSelectorViewComponent : BaseViewComponent
    {
        public IUsersDAL UsersDAL { get; }

        public ClassSelectorViewComponent(IUsersDAL usersDAL, UserManager<User> userManager, ApplicationDbContext dbContext, ILogger<SidebarViewComponent> logger) : base(logger, userManager, dbContext)
        {
            UsersDAL = usersDAL;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new ClassSelectorViewModel();
            var classSelection = UsersDAL.GetUserSelection(SelectionType.Class);

            if (!string.IsNullOrEmpty(classSelection))
                viewModel = JsonSerializer.Deserialize<ClassSelectorViewModel>(classSelection);

            viewModel.Years = DbContext.SchoolYears.ToList();
            viewModel.Grades = DbContext.Grades.ToList();
            viewModel.Classes = DbContext.Classes.ToList();

            return View(viewModel);
        }
    }
}
