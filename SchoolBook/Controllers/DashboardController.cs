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

namespace SchoolBook.Controllers
{
    public class DashboardController : Controller
    {
        public IBulletinsDAL BulletinsDAL { get; }
        public IUsersDAL UsersDAL { get; }
        public ILogger<DashboardController> Logger { get; }

        public DashboardController(IBulletinsDAL bulletinsDAL, IUsersDAL usersDAL, ILogger<DashboardController> logger)
        {
            BulletinsDAL = bulletinsDAL;
            UsersDAL = usersDAL;
            Logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            var viewModel = new DashboardViewModel
            {
                News = BulletinsDAL.GetBulletins().OrderByDescending(b => b.Id).Take(3).ToList(),
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SaveClassSelection(string selection)
        {
            try
            {
                UsersDAL.SaveUserSelection(SelectionType.Class, selection);

                return Json("ok");

            }
            catch(Exception ex)
            {
                Logger.LogError("Ha ocurrido un error: " + ex.Message + " - Stacktrace: " + ex.StackTrace);
                return Json("error: " + ex.Message);
            }
        }
    }
}
