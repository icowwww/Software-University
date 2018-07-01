namespace MeTube.App.Helpers
{
    using Models;
    using Services;

    public static class HtmlHelpers
    {
        public static string ToHtml(this TubeViewModel tube)
            => $@"
                <div class=""card col-3 thumbnail text-center"">
                    <a href=""/tubes/details?id={tube.Id}"" target=""_self""> 
                    <img class=""card-image-top img-fluid img-thumbnail"" width=""450"" 
                    onerror=""this.src='https://i.yt`.com/vi/{tube.VideoId}/maxresdefault.jpg';"" src=""{tube.VideoId}"" border=""0"" />
                    </a>
                   
                    <div class=""card-body"">
                        <h4 class=""card-title text-center"">{tube.Title}</h4>
                        <p class=""card-text text-center""><strong>Author</strong> - {tube.Author}</p>
                    </div>
                   
                </div>";
    }
}
