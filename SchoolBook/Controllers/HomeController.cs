using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.Models;
using SchoolBook.Utils;
using SchoolBook.ViewModels;

namespace SchoolBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public HomeController(SignInManager<User> signInManager, ILogger<HomeController> logger, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index(string returnUrl = "")
        {
            // todo: change to dashboard
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "ClassBook");

            var viewModel = new LoginViewModel();
            viewModel.SessionEnded = !string.IsNullOrEmpty(returnUrl);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(viewModel.Username);
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, viewModel.Password, true, false);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("Usuario " + viewModel.Username + " accede al dashboard con éxito.");

                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        ModelState.AddModelError("Username", "Usuario o contraseña incorrectos");
                        viewModel.Password = string.Empty;
                    }
                }

            }
            catch(Exception e)
            {
                _logger.LogError("Ha ocurrido un error: {1}", e.Message);
                ModelState.AddModelError("Username", "Usuario o contraseña incorrectos");
                viewModel.Password = string.Empty;
            }

            return View("Index", viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
