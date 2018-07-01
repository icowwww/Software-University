using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KittenApp.Data;
using KittenApp.Models;
using KittenApp.Models.Enums;
using KittenApp.Web.Models;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;

namespace KittenApp.Web.Controllers
{
    public class KittensController:Controller
    {
        private readonly Dictionary<string, string> dbToVisual = new Dictionary<string, string>() {{ "StreetTranscended", "street-transcended" }, { "Shorthair", "american-shorthair" }, { "Munchkin", "munchkin" }, { "Siamese", "siamese" }};
        [HttpGet]
        public IActionResult Add()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToAction("/home/index");
            }

            var a = Breed.StreetTranscended.ToString();
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddKittenModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToAction("/home/index");
            }
            if (!IsValidModel(model))
            {
                return View();
            }
            using (var context = new KittenAppContext())
            {
                var user = context.Users.FirstOrDefault(x => x.Username == this.User.Name);
                Breed.TryParse(model.Breed, out Breed breed);
                var kitten = new Kitten
                {
                    Name = model.Name,
                    Age = model.Age,
                    User = user,
                    Breed = breed
                };
                context.Kittens.Add(kitten);
                context.SaveChanges();
            }

            return View();
        }
        [HttpGet]
        public IActionResult All()
        {
            using (var context = new KittenAppContext())
            {
                var kittens = context.Kittens.Select(x=> new {x.Breed,x.User,x.Age,x.Name}).ToList();
                var sb= new StringBuilder();
                sb.AppendLine(@"<h1 align=""center"">All Kittens</h1></br></br>");
                sb.AppendLine("");
                for (int i = 0; i < kittens.Count; i++)
                {
                    if (i % 5 == 0 && i!=0)
                    {
                        sb.AppendLine("</br></br></br>");
                    }
                    sb.AppendLine($@"<div class=""col-2"">
                        <img class=""img-thumbnail"" src=""../../Content/jpg/{dbToVisual[kittens[i].Breed.ToString()]}.jpg"" alt=""{
                            kittens[i].Name
                        }'s photo"" />
                        <div>
                            <h5>Name: {kittens[i].Name}</h5>
                            <h5>Age: {kittens[i].Age}</h5>
                            <h5>Breed: {kittens[i].Breed}</h5>
                            <h5>Owner: {kittens[i].User.Username}</h5>
                        </div>
                    </div>");
                }

                this.Model.Data["kittens"] = sb.ToString();
            }

            return View();
        }
        private readonly string sort = "";
    }
}
