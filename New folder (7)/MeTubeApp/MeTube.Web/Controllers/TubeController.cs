using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeTube.Data;
using MeTube.Models;
using MeTube.Web.Models;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;

namespace MeTube.Web.Controllers
{
    public class TubeController:Controller
    {
        [HttpGet]
        public IActionResult Upload()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToAction("/home/index");
            }
            this.Model.Data["error"] = "";
            return this.View();
        }

        [HttpPost]

        public IActionResult Upload(TubeUploadModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToAction("/home/index");
            }

            if (!IsValidModel(model))
            {
                this.Model.Data["error"] = "Invalid!";
                return this.View();
            }
            using (var context = new MeTubeContext())
            {
                var user = context.Users.FirstOrDefault(x => x.Username == this.User.Name);
                var tube = new Tube
                {
                    Author = model.Author,
                    User = user,
                    YoutubeId = model.YoutubeId,
                    Description = model.Description
                };
                context.Tubes.Add(tube);
                context.SaveChanges();
            }
            this.Model.Data["error"] = "Successfull upload!";
            return View();
        }
    }
}
