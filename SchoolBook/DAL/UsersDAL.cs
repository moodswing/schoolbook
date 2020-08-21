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
    public class UsersDAL : BaseDAL, IUsersDAL
    {
        private ClaimsPrincipal User { get; }

        public UsersDAL(ILogger<MenuOptionsDAL> logger, UserManager<User> userManager, ApplicationDbContext dbContext, ClaimsPrincipal user) : base(logger, userManager, dbContext)
        {
            User = user;
        }

        public User GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        }

        public string GetUserSelection(SelectionType type)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _dbContext.UserSelections.FirstOrDefault(s => s.UserId.Equals(userId) && s.Type.Equals(type))?.Value ?? null;
        }

        public void SaveUserSelection(SelectionType type, string value)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userSelection = _dbContext.UserSelections.FirstOrDefault(s => s.UserId.Equals(userId) && s.Type.Equals(type)) ?? new UserSelection();

            userSelection.UserId = userId;
            userSelection.Type = type;
            userSelection.Value = value;

            if (userSelection.Id == 0)
                _dbContext.UserSelections.Add(userSelection);
            else
                _dbContext.UserSelections.Update(userSelection);

            _dbContext.SaveChanges();
        }
    }

    public interface IUsersDAL
    {
        User GetCurrentUser();

        string GetUserSelection(SelectionType type);
        void SaveUserSelection(SelectionType type, string value);
    }
}
