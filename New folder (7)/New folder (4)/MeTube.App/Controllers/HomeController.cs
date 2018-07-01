﻿namespace MeTube.App.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using Helpers;
    using Services;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;

    public class HomeController : BaseController
    {
        private readonly TubesService tubes;
        private readonly UsersService users;

        public HomeController()
        {
            this.tubes = new TubesService();
            this.users = new UsersService();
        }


        [HttpGet]
        public IActionResult Index()
        {
            int? userId = null;
            if (!this.User.IsAuthenticated)
            {
                var guestFormat = File.ReadAllText("../../../Views/Home/guest.html");
                this.Model["guest"] = guestFormat;
                this.Model["user"] = string.Empty;
                return View();
            }
            //else
            //{
            //}
            //this.Model.Data["jumbotronn"] = "none";
            var username = this.User.Name;
            userId = this.users.GetByName(this.User.Name).Id;

            var tubeCards = this.tubes.All().Select(g => g.ToHtml()).ToList();

            var result = new StringBuilder();

            for (int i = 0; i < tubeCards.Count; i++)
            {
                if (i % 3 == 0)
                {
                    result.Append(@"<div class=""card-group col-12 justify-content-center"">");
                }

                result.Append(tubeCards[i]);

                if (i % 3 == 2 || i == tubeCards.Count - 1)
                {
                    result.Append("</div>");
                }
            }


            var userFormat = File.ReadAllText("../../../Views/Home/user.html");
            this.Model.Data["user"] = userFormat;
            this.Model.Data["username"] = username;
            this.Model.Data["userhome"] = result.ToString();
            this.Model["id"] = userId.ToString();

            this.Model["guest"] = string.Empty;
                


            return this.View();
        }
    }
}

