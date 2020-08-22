using SchoolBook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SchoolBook.DAL;
using System.Linq;
using SchoolBook.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SchoolBook.Controllers
{
    public class ClassBookController : BaseController
    {
        public IStudentsDAL StudentsDAL { get; }
        public ILogger<DashboardController> Logger { get; }

        public ClassBookController(IStudentsDAL studentsDAL, IUsersDAL usersDAL, ILogger<DashboardController> logger) : base(usersDAL)
        {
            StudentsDAL = studentsDAL;
            Logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            var viewModel = new ClassBookViewModel();

            if (int.TryParse(ClassSelection.ClassId, out int classId))
                viewModel.Students = StudentsDAL.GetClassStudents(classId);
            else
                viewModel.Students = new List<Student>();

            var studentsCount = viewModel.Students?.Count() ?? 0;

            return View(viewModel);
        }
    }
}
