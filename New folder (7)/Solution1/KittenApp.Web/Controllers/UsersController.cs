using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KittenApp.Data;
using KittenApp.Models;
using KittenApp.Web.Models;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;

namespace KittenApp.Web.Controllers
{
    public class UsersController:Controller
    {
        [HttpGet]

        public IActionResult Register()
        {
            this.Model.Data["error"] = string.Empty;
            return this.View();
        }

        [HttpPost]

        public IActionResult Register(UserRegisteringModel model)
        {
            if (!IsValidModel(model))
            {
                return this.View();
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = model.Password
            };
            using (var context = new KittenAppContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
                return RedirectToAction("Result");
        }
        [HttpGet]
        public IActionResult Result() => this.View();

        [HttpGet]
        public IActionResult Login()
        {
            this.Model.Data["error"] = string.Empty;
            if (this.User.IsAuthenticated)
            {
                return RedirectToAction("/home/index");
            }

            return this.View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToAction("/home/index");
            }
            using (var context = new KittenAppContext())
            {
                var user = context.Users.FirstOrDefault(x => x.Username == model.Username);
                if (user == null || user.PasswordHash != model.Password)
                {
                    this.Model.Data["error"] = "Wrong username or password!";
                    return View();
                }
                SignIn(model.Username);
                context.SaveChanges();
            }

            return this.RedirectToAction("/home/index");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            SignOut();
            return RedirectToAction("/home/index");
        }




    }
}
