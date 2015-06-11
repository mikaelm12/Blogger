using Blogger.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Blogger.Controllers
{
    public class PostController : Controller
    {

        [FromServices]
        public ApplicationDbContext DbContext { get; set; }


        [HttpPost]
        public IActionResult Index(MinPost postMin)
        {
            var newPost = new Post();
            newPost.PosterEmail = Context.User.Identity.Name;
            if (postMin.Title == null)
            {
                newPost.Title = "No Title " + DateTime.Now.ToString();
            }
            else
            {
                newPost.Title = postMin.Title;
            }
            
            newPost.Text = postMin.Text;
            newPost.PostId = postMin.Id;
            newPost.TimeStamp =   DateTime.Now;
            newPost.PosterId = Context.User.Identity.GetHashCode();

            AddPost(newPost);

            var allPosts = new PostCollection(DbContext.Posts.ToArray());
            return View("~/Views/Home/Index", allPosts);

        
        }

        public IActionResult Index()
        {


            var allPosts = new PostCollection(DbContext.Posts.ToArray());
            return View("~/Views/Home/Index",allPosts);


        }


        
        public IActionResult SinglePost(int id)
        {
            try
            {
                var singlePost = (Post)DbContext.Posts.Single(p => p.PostId == id);
                return View(singlePost);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml", "**waives hand This is not the post you're looking for");


            }

        }



        [Authorize]
        public void AddPost(Post Post)
        {

            DbContext.Posts.Add(Post);
            DbContext.SaveChanges();
            return;

        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            
            try
            {
                Post post = (Post)DbContext.Posts.Single(p => p.PostId == id);
                if (post != null)
                {

                    if (Context.User.Identity.Name == post.PosterEmail)
                    {
                        DbContext.Posts.Remove(post);
                        DbContext.SaveChanges();
                        var allMyPosts = new PostCollection(DbContext.Posts
                            .Where(p => p.PosterEmail == Context.User.Identity.Name).ToArray());

                        return View("~/Views/Home/Profile", allMyPosts);
                    }
                    else
                    {
                        return View("~/Views/Shared/Error.cshtml", "You are not authorized to delete this post");
                    }
                }
            }
            catch (Exception)
            {
                return View("~/Views/Shared/Error.cshtml");

            }
            return View("~/Views/Shared/Error.cshtml");
        }


        [Authorize]
        [HttpGet]
        public IActionResult GetEditPostView(int id)
        {
            try
            {
                var post = DbContext.Posts.Single(p => p.PostId == id);
                if (post.PosterEmail == Context.User.Identity.Name) { 
                    return View("EditPost", post);
                }
            }
            catch (Exception)
            {

                return View("~/Views/Shared/Error.cshtml");
            }

            return View("~/Views/Shared/Error.cshtml");

        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(MinPost minPost) 
        {
            try
            {
                var updatedPost = DbContext.Posts.Single(p => p.PostId == minPost.Id);
                if (Context.User.Identity.Name == updatedPost.PosterEmail)
                {
                    if (minPost.Title == null)
                    {
                        updatedPost.Title = updatedPost.TimeStamp.ToString();
                    }
                    else
                    {
                        updatedPost.Title = minPost.Title;
                    }

                    updatedPost.Text = minPost.Text;
                    
                    DbContext.SaveChanges();
                    return View("~/Views/Post/SinglePost", updatedPost);
                }
            }
            catch (Exception)
            {

                return View("~/Views/Shared/Error.cshtml");
            }

             return View("~/Views/Shared/Error.cshtml");


        }


        [Authorize]
        public IActionResult NewPost()
        {
            return View();
        }
    }

}

