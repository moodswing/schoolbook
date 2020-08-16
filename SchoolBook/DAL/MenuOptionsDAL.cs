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
    public class MenuOptionsDAL : BaseDAL, IMenuOptionsDAL
    {
        private ClaimsPrincipal User { get; }

        public MenuOptionsDAL(ILogger<MenuOptionsDAL> logger, UserManager<User> userManager, ApplicationDbContext dbContext, ClaimsPrincipal user) : base(logger, userManager, dbContext)
        {
            User = user;
        }

        public List<MenuOption> GetCurrentUserMenuOptions()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var roles = _dbContext.UserRoles.Where(r => r.UserId.Equals(userId)).Select(r => r.RoleId);

            var roleMenus = _dbContext.RoleMenus.Where(rm => roles.Contains(rm.RoleId));
            var menuOptions = roleMenus.Select(m => m.MenuOption).ToList();

            var menuOptionsOrdered = new List<MenuOption>();

            foreach (var menu in menuOptions.Where(m => m.GroupMenuOptionId.Equals(0)).OrderBy(m => m.Order))
            {
                menuOptionsOrdered.Add(menu);
                foreach (var subMenu in menuOptions.OrderBy(m => m.Description).Where(m => m.GroupMenuOptionId.Equals(menu.Id)))
                    menuOptionsOrdered.Add(subMenu);
            }

            return menuOptionsOrdered;
        }
    }

    public interface IMenuOptionsDAL
    {
        List<MenuOption> GetCurrentUserMenuOptions();
    }
}
