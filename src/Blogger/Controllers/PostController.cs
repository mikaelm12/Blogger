using Blogger.Models;
using Microsoft.AspNet.Mvc;
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
            Post newPost = new Post();
            newPost.PosterEmail = Context.User.Identity.Name;
            newPost.Title = postMin.Title;
            newPost.Text = postMin.Text;
            newPost.PostId = postMin.Id;
            newPost.TimeStamp =   DateTime.Now;
            newPost.PosterId = Context.User.Identity.GetHashCode();

            AddPost(newPost);

            PostCollection allPosts = new PostCollection(DbContext.Posts.ToArray());
            return View(allPosts);

        
        }

        public IActionResult Index()
        {


            PostCollection allPosts = new PostCollection(DbContext.Posts.ToArray());
            return View(allPosts);


        }

        public IActionResult SinglePost(Post post)
        {

            return View(post);
        }


        public void AddPost(Post Post)
        {



            DbContext.Posts.Add(Post);
            DbContext.SaveChanges();
            return;
           
        }
    }

}

