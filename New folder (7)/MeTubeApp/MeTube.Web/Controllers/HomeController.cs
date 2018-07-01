namespace MeTube.Web.Controllers
{
    using System.Linq;
    using System.Text;
    using Data;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var sb = new StringBuilder();
            if (!this.User.IsAuthenticated)
            {
                sb.AppendLine(
                    "<p class=\"h1 display-3\">Welcome to MeTube&trade;!</p> <p class=\"h3\">The simplest, easiest to use, most comfortable Multimedia Application.</p> <hr class=\"my-3\"> <p><a href=\"/login\">Login</a> if you have an account or <a href=\"/register\">Register</a> now and start tubing.</p>");
                this.Model.Data["index"] = sb.ToString();
                return View();
            }

            using (var context = new MeTubeContext())
            {
                var tubes = context.Tubes.Where(e => e.User.Username == this.User.Name)
                    .Select(e => new {e.User, e.Author, e.Views, e.Description, e.YoutubeId}).ToList();
                sb.AppendLine(@"<h1 align=""center"">Welcome, " + tubes.FirstOrDefault().User.Username +
                              "!</h1><hr class=\"my-3\"/></br></br>");
                sb.AppendLine("");
                for (int i = 0; i < tubes.Count; i++)
                {
                    if (i % 5 == 0 && i != 0)
                    {
                        sb.AppendLine("</br></br></br>");
                    }

                    sb.AppendLine($@"<div class=""col-4"">
                        <object width=""210"" height=""160""
data=""https://www.youtube.com/v/tgbNymZ7vqY"">
</object>
                        
                            <h5>Name: {tubes[i].Author}</h5>
                    </div>");
                }
                //this.Model.Data["index"] = sb.ToString();
                return this.View();

            }
        }
    }
}
