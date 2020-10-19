using System;
using Microsoft.AspNetCore.Mvc;
using SchoolBook.DAL;
using SchoolBook.Models;
using SchoolBook.ViewModels;

namespace SchoolBook.Controllers
{
    public class BaseController : Controller
    {
        public IUsersDAL UsersDAL { get; }
        public UserSelectorViewModel FiltersSelection { get; set; }

        public BaseController(IUsersDAL usersDAL)
        {
            UsersDAL = usersDAL;

            FiltersSelection = UsersDAL.GetUserSelection<UserSelectorViewModel>(SelectionType.Filters);
        }
    }
}
