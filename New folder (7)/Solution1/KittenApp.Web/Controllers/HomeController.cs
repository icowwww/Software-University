using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Interfaces;
using SimpleMvc.Framework.Controllers;

namespace KittenApp.Web.Controllers
{
    public class HomeController:Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (this.User.IsAuthenticated)
            {
                this.Model.Data["welcomeMsg"] = @"<h1>Welcome, " + this.User.Name + "</h1>";
                this.Model.Data["welcomeMsg2"] =
                    "<p>Fluffy, Duffy, Munchkin Cats wishes you a cute and awesome experience.</p>";
            }
            else
            {
                this.Model.Data["welcomeMsg"] = "<h1>Welcome to Fluffy Duffy Munchkin Cats</h1><p>The simplest, cutest, most reliable website for trading cats.</p>";
                this.Model.Data["welcomeMsg2"] = "<p><a href=\"/users/login\">Login</a> to trade or <a href=\"/users/register\">Register</a> if you don't have an account.</p>";
            }
           return this.View();
        }
    }
}
