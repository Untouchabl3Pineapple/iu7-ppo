using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using db_cp.ViewModels;
using db_cp.Interfaces;
using db_cp.Mocks;
using db_cp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using db_cp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;
using System.Runtime.ConstrainedExecution;

namespace db_cp.Controllers
{
    public class AccountController : Controller
    {
        IUsersService userService;
        private readonly ILogger<AccountController> logger;

        public AccountController(IUsersService userService,
                                 ILogger<AccountController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        string getHashPassword(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asByteArray);

            return Convert.ToBase64String(hashedPassword);
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Title = "Register";

            logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            ViewBag.Title = "Register";

            if (ModelState.IsValid)
            {
                try
                {
                    Users user = new Users
                    {
                        Login = model.Login,
                        Password = getHashPassword(model.Password),
                        Permission = "guest",
                        Name = model.Name,
                        Surname = model.Surname,
                        MiddleName = model.MiddleName,
                    };

                    userService.Add(user);

                    await Authenticate(user);

                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name, ex.Message);

                    ModelState.AddModelError("", "This login is already taken");
                }
            }
            else
                ModelState.AddModelError("", "Incorrect data");

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "Login";

            logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            ViewBag.Title = "Login";

            if (ModelState.IsValid)
            {
                Users user = userService.GetByLogin(model.Login);

                string inputPassword = getHashPassword(model.Password);

                if (user != null && user.Password == inputPassword)
                {
                    await Authenticate(user);

                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name, "Incorrect username or password");

                    ModelState.AddModelError("", "Incorrect username or password");
                }
            }
            else
                ModelState.AddModelError("", "Incorrect username or password");

            return View(model);
        }

        private async Task Authenticate(Users user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Permission)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
