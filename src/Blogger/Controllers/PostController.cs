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
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult NewPost(MinPost postMin)
        {
            //TODO add a check for a post that already has the slug.
            /*
            DbContext.Posts.Single(p => p.Slug == postMin.Slug);
            */
            //  var count = DbContext.Posts.Any(p => p.Slug == postMin.Slug);
            var newPost = new Post();
            newPost.PosterEmail = Context.User.Identity.Name;
            if (postMin.Title == null)
            {
                // TODO Replace the ToString call
                newPost.Title = DateTimeOffset.Now.ToString();
            }
            else
            {
                newPost.Title = postMin.Title;
            }
            newPost.Text = postMin.Text;
            newPost.PostId = postMin.Id;
            newPost.Slug = postMin.Slug;
            newPost.TimeStamp = DateTimeOffset.Now;

            if (DbContext.Posts.Any(p => p.Slug == postMin.Slug))
            {
                return View(newPost);
            }
            
           

            AddPost(newPost);
            //DbContext.Posts.Or
            return RedirectToAction("Index", "Home");


        }

        public IActionResult Index()
        {


            var allPosts = new PostCollection(DbContext.Posts.ToArray());
            return View("~/Views/Home/Index",allPosts);


        }


        
        //public IActionResult SinglePost(int id)
        //{
        //    try
        //    {
        //        var singlePost = DbContext.Posts.Single(p => p.PostId == id);
        //        return View(singlePost);
        //    }
        //    catch (Exception)
        //    {
        //        return View("~/Views/Shared/Error.cshtml", "**waives hand This is not the post you're looking for");


        //    }

        //}

        public IActionResult SinglePost(string slug)
        {

                var singlePost = DbContext.Posts.Single(p => p.Slug == slug);
                return View(singlePost);
            


        }

       public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml", " *Waives hand* This is not the post you are looking for");
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
            
           
                var post = DbContext.Posts.SingleOrDefault(p => p.PostId == id);
                
                if (post != null)
                {
                    if (Context.User.Identity.Name == post.PosterEmail)
                    {
                        DbContext.Posts.Remove(post);
                        DbContext.SaveChanges();

                        return RedirectToAction("Profile", "Home");
                    }
                    else
                    {
                        return View("~/Views/Shared/Error.cshtml", "You are not authorized to delete this post");
                    }
                }
            
            return  RedirectToAction("Error", "Home");
        }


        [Authorize]
        [HttpGet]
        public IActionResult GetEditPostView(int id)
        {
            
                var post = DbContext.Posts.SingleOrDefault(p => p.PostId == id);
                if (post.PosterEmail == Context.User.Identity.Name) { 
                    return View("EditPost", post);
                }
            
           
                return RedirectToAction("Error", "Home");

        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(MinPost minPost) 
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
            
                return RedirectToAction("Error", "Home");


        }

        [HttpGet]
        [Authorize]
        public IActionResult NewPost()
        {
            return View();
        }


    }

}

