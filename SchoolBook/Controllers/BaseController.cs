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
        public ClassSelectorViewModel ClassSelection { get; set; }

        public BaseController(IUsersDAL usersDAL)
        {
            UsersDAL = usersDAL;

            ClassSelection = UsersDAL.GetUserSelection<ClassSelectorViewModel>(SelectionType.Class);
        }
    }
}
