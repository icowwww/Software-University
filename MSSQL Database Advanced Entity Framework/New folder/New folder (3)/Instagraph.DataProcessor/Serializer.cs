using System;
using System.Linq;
using Instagraph.Data;
using Newtonsoft.Json;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts.Where(x => x.Comments.Count == 0).Select(e => new
            {
                e.Id,
                Picture = e.Picture.Path,
                User = e.User.Username
            }).OrderBy(e => e.Id);
            return JsonConvert.SerializeObject(posts, Formatting.Indented);
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            
            var users = context.Users.Where(e => e.Posts.Any(p => p.Comments.Any(c => context.UsersFollowers.Where(x=> x.UserId == e.Id).Select(l=> l.FollowerId).Contains(c.UserId))))
                .OrderBy(e=> e.Id)
                .Select(e => new
                {
                    e.Username,
                    Followers = e.Followers.Count
                });
            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            throw new NotImplementedException();
        }
    }
}
