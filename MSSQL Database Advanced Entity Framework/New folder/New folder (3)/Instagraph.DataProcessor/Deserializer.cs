using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

using Newtonsoft.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Instagraph.Data;
using Instagraph.DataProcessor.DtoModels;
using Instagraph.Models;

namespace Instagraph.DataProcessor
{
    public class Deserializer
    {
        public static readonly List<string> UniquePaths = new List<string>();
        public const string errorMSG = "Error: Invalid data.";
        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            var pictures = JsonConvert.DeserializeObject<Picture[]>(jsonString);
            var sb = new StringBuilder();
            foreach (var picture in pictures)
            {
                if (String.IsNullOrWhiteSpace(picture.Path) || picture.Size<=0 || context.Pictures.Any(e=> e.Path== picture.Path))
                {
                    sb.AppendLine(errorMSG);
                    continue;
                }
                UniquePaths.Add(picture.Path);
                context.Pictures.Add(picture);
                sb.AppendLine($"Successfully imported Picture {picture.Path}.");
                context.SaveChanges();
            }
            return sb.ToString().Trim();
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            var usersToAdd = JsonConvert.DeserializeObject<UserDto[]>(jsonString);
            var sb = new StringBuilder();
            foreach (var user in usersToAdd)
            {
                
                var isPictureValid = !String.IsNullOrWhiteSpace(user.ProfilePicture) &&
                                     context.Pictures.Any(x => x.Path == user.ProfilePicture);

                var isUsernameValid = !String.IsNullOrWhiteSpace(user.Username) && user.Username.Length <= 30 && !context.Users.Any(u=> u.Username == user.Username);
                var isPasswordValid = !String.IsNullOrWhiteSpace(user.Password) && user.Password.Length <= 20;
                if (!isPasswordValid || !isPictureValid || !isUsernameValid)
                {
                    sb.AppendLine(errorMSG);
                    continue;
                }
                var picture = context.Pictures.FirstOrDefault(e => e.Path == user.ProfilePicture);
                var userToAdd = new User
                {
                    ProfilePicture = picture,
                    Username = user.Username,
                    Password = user.Password
                };
                context.Users.Add(userToAdd);
                sb.AppendLine($"Successfully imported User {user.Username}.");
                context.SaveChanges();
            }
            return sb.ToString().Trim();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var followersToAdd = JsonConvert.DeserializeObject<UserFollowerDto[]>(jsonString);
            var sb = new StringBuilder();
            foreach (var follower in followersToAdd)
            {
                var user = context.Users.FirstOrDefault(u => u.Username == follower.User);
                var followerToadd = context.Users.FirstOrDefault(u => u.Username == follower.Follower);
                if (user == null || followerToadd ==null)
                {
                    sb.AppendLine(errorMSG);
                    continue;
                }
                var userFollower = new UserFollower
                {
                    Follower = followerToadd,
                    User = user
                };
                if (context.UsersFollowers.Any(e=> e.UserId == user.Id && e.FollowerId == followerToadd.Id))
                {
                    sb.AppendLine(errorMSG);
                    continue;
                }
                context.UsersFollowers.Add(userFollower);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported Follower {follower.Follower} to User {follower.User}.");
            }
            return sb.ToString().Trim();
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var xml = XDocument.Parse(xmlString);
            var posts = xml.Root?.Elements();
            var sb = new StringBuilder();
            foreach (var xElement in posts)
            {
                var caption = xElement.Element("caption")?.Value;
                var username = xElement.Element("user")?.Value;
                var picturePath = xElement.Element("picture")?.Value;
                if (String.IsNullOrWhiteSpace(caption) || String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(picturePath))
                {
                    sb.AppendLine(errorMSG);
                    continue;
                }
                var user = context.Users.FirstOrDefault(e => e.Username == username);
                var picture = context.Pictures.FirstOrDefault(e => e.Path == picturePath);
                if (user == null || picture == null)
                {
                    sb.AppendLine(errorMSG);
                    continue;
                }

                var post = new Post
                {
                    Caption = xElement.Element("caption").Value,
                    User = user,
                    Picture = picture
                };
                context.Posts.Add(post);
                sb.AppendLine($"Successfully imported Post {caption}.");
                context.SaveChanges();
            }
            return sb.ToString().Trim();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var xml = XDocument.Parse(xmlString);
            var comments = xml.Root?.Elements();
            var sb = new StringBuilder();
            foreach (var comment in comments)
            {
                var content = comment.Element("content")?.Value;
                var username = comment.Element("user")?.Value;
                var postId = comment.Element("post")?.Attribute("id")?.Value;
                if (String.IsNullOrWhiteSpace(content) || String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(postId))
                {
                    sb.AppendLine(errorMSG);
                    continue;
                }
                var user = context.Users.FirstOrDefault(e => e.Username == username);
                var post = context.Posts.FirstOrDefault(e => e.Id == int.Parse(postId));
                if (user == null || post == null)
                {
                    sb.AppendLine(errorMSG);
                    continue;
                }
                var commentToAdd = new Comment
                {
                    Content = content,
                    Post = post,
                    User = user
                };
                context.Comments.Add(commentToAdd);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported Comment {content}.");
            }
            return sb.ToString().Trim();
        }
    }
}
