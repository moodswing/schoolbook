using SchoolBook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SchoolBook.DAL;
using System.Linq;

namespace SchoolBook.Controllers
{
    public class DashboardController : Controller
    {
        public IBulletinsDAL BulletinsDAL { get; }

        public DashboardController(IBulletinsDAL bulletinsDAL)
        {
            BulletinsDAL = bulletinsDAL;
        }

        [Authorize]
        public IActionResult Index()
        {
            var viewModel = new DashboardViewModel
            {
                News = BulletinsDAL.GetBulletins().OrderByDescending(b => b.Id).Take(3).ToList()
            };

            return View(viewModel);
        }
    }
}
