using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using db_cp.ViewModels;
using db_cp.Interfaces;
using db_cp.Mocks;
using db_cp.Services;
using Microsoft.AspNetCore.Mvc;
using db_cp.Models;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text;
using System.Security.Cryptography;

namespace db_cp.Controllers
{
    public class UserController : Controller
    {
        private IUsersService userService;
        private readonly ILogger<UserController> logger;

        public UserController(IUsersService userService,
                              ILogger<UserController> logger)
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
        public IActionResult AddNewUser()
        {
            ViewBag.Title = "AddNewUser";

            UserViewModel model = new UserViewModel();
            model.users = userService.GetAll();

            logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

            return View(model);
        }

        [HttpPost]
        public IActionResult AddNewUser(UserViewModel model)
        {
            ViewBag.Title = "AddNewUser";

            if (ModelState.IsValid)
            {
                try
                {
                    Users user = new Users
                    {
                        Login = model.Login,
                        Password = getHashPassword(model.Permission),
                        Permission = model.Permission,
                        Name = model.Name,
                        Surname = model.Surname,
                        MiddleName = model.MiddleName
                    };

                    userService.Add(user);

                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

                    return RedirectToAction("AddNewUser", "User");
                }
                catch (Exception ex)
                {
                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name, ex.Message);

                    ModelState.AddModelError("", "This user does not exist");
                }
            }
            else
                ModelState.AddModelError("", "Incorrect data");

            return View(model);
        }

        [HttpGet]
        public IActionResult UpdatePermission()
        {
            ViewBag.Title = "UpdatePermission";

            logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

            UserViewModel model = new UserViewModel();
            model.users = userService.GetAll();

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdatePermission(string login, string permission)
        {
            ViewBag.Title = "UpdatePermission";

            if (ModelState.IsValid)
            {
                try
                {
                    Users user = userService.GetByLogin(login);
                    user.Permission = permission;

                    userService.Update(user);

                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

                    return RedirectToAction("UpdatePermission", "User");
                }
                catch (Exception ex)
                {
                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name, ex.Message);

                    ModelState.AddModelError("", "This user does not exist");
                }
            }
            else
                ModelState.AddModelError("", "Incorrect data");

            return View();
        }
    }
}
