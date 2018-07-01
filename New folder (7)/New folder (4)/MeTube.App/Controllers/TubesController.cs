namespace MeTube.App.Controllers
{
    using Helpers;
    using Models;
    using Services;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class TubesController : BaseController
    {
        public const string CreateNoteErrorMessage = @"<p>Check your form for errors.</p><p>Author's name must be 3 symbols minimum.</p><p>Title must be 3 symbols minimum.</p><p>Description must be 4 symbols minimum.</p><p>VideoId must be 11 symbols precise.</p>";

        private readonly UsersService users;
        private readonly TubesService tubes;

        public TubesController()
        {
            this.users = new UsersService();
            this.tubes = new TubesService();
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            int userId = this.users.GetByName(this.User.Name).Id;
            this.Model["id"] = userId.ToString();

            this.Model.Data["username"] = this.User.Name;
            return View();
        }


        [HttpPost]
        public IActionResult Add(TubeCreateModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                RedirectToLogin();
            }

            if (!this.IsValidModel(model))
            {
                ShowError(CreateNoteErrorMessage);
                return View();

                //return RedirectToAction("/tubes/add");
            }

            var username = this.User.Name;

            this.tubes.Add(model.Title.CapitalizeFirstLetter(), model.Author, model.Description, model.VideoId, username);

            //var user = this.users.GetByName(username);

            //this.Model["username"] = user.Username;
            //this.Model["notes"] =
            //    user.Notes.Any()
            //        ? string.Join(string.Empty,
            //            user.Notes.Select(n => $@"<li><strong>{n.Title}</strong> - {n.Content}</li>"))
            //        : "No note records";


            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            this.tubes.IncrementViewsByOne(id);
            var tube = this.tubes.GetById(id);



            int userId = this.users.GetByName(this.User.Name).Id;
            this.Model["id"] = userId.ToString();

            this.Model.Data["title"] = tube.Title;
            this.Model.Data["author"] = tube.Author;
            this.Model.Data["description"] = tube.Description;
            this.Model.Data["videoid"] = tube.VideoId;
            this.Model.Data["views"] = tube.Views.ToString();
            return View();
        }
    }
}
