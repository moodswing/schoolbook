using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.DAL;
using SchoolBook.Data;
using SchoolBook.Models;

namespace SchoolBook.ViewComponents
{
    public class SidebarViewComponent : BaseViewComponent
    {
        public IMenuOptionsDAL MenuOptionsDAL { get; }

        public SidebarViewComponent(ILogger<SidebarViewComponent> logger, UserManager<User> userManager, ApplicationDbContext dbContext, IMenuOptionsDAL menuOptionsDAL) : base(logger, userManager, dbContext)
        {
            MenuOptionsDAL = menuOptionsDAL;
        }

        public IViewComponentResult Invoke()
        {
            return View(MenuOptionsDAL.GetCurrentUserMenuOptions());
        }
    }
}
