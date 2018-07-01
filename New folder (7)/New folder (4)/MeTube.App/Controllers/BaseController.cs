﻿namespace MeTube.App.Controllers
{
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;

    public class BaseController : Controller
    {
        protected BaseController()
        {
            this.Model["anonymousDisplay"] = "flex";
            this.Model["displayAddNote"] = "none";
            this.Model.Data["show-error"] = "none";
        }
        protected void ShowError(string error)
        {
            this.Model.Data["show-error"] = "block";
            this.Model.Data["error"] = error;
        }

        protected IActionResult RedirectToHome()
        {
            return this.RedirectToAction("/home/index");
        }

        protected IActionResult RedirectToLogin()
        {
            return this.RedirectToAction("/users/login");
        }
    }
}
