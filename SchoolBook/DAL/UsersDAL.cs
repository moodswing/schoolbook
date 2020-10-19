using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolBook.Data;
using SchoolBook.Models;

namespace SchoolBook.DAL
{
    public class UsersDAL : BaseDAL, IUsersDAL
    {
        private ClaimsPrincipal User { get; }

        public UsersDAL(ApplicationDbContext dbContext, UserManager<User> userManager, ClaimsPrincipal user, ILogger<MenuOptionsDAL> logger) : base(dbContext, logger)
        {
            User = user;
        }

        public User GetCurrentUser(bool includeSuperiors = false)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _dbContext.Users.Include(u => u.Classes).FirstOrDefault(u => u.Id == userId);
        }

        public List<User> GetSuperiors()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _dbContext.Users.Include("Superiors.Superior").FirstOrDefault(u => u.Id == userId);

            return user.Superiors.Select(s => s.Superior).ToList();
        }

        public T GetUserSelection<T>(SelectionType type) where T : new()
        {
            var result = new T();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var selection = _dbContext.UserSelections.OrderByDescending(s => s.Type)
                .FirstOrDefault(s => s.UserId.Equals(userId) && (s.Type.Equals(type) || s.Type.Equals(SelectionType.Filters)))?.Value ?? null;

            if (!string.IsNullOrEmpty(selection))
                result = JsonSerializer.Deserialize<T>(selection);

            return result;
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

        public bool IsUserClassTeacher(int classId, int subjectId)
        {
            var user = GetCurrentUser();

            return user.Classes != null && user.Classes.Any(c => c.ClassId == classId && c.SubjectId == subjectId);
        }
    }

    public interface IUsersDAL
    {
        User GetCurrentUser(bool includeSuperiors);
        List<User> GetSuperiors();

        T GetUserSelection<T>(SelectionType type) where T : new();
        bool IsUserClassTeacher(int classId, int subjectId);
        void SaveUserSelection(SelectionType type, string value);
    }
}
