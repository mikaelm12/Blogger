using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Models
{
    public class PostCollection
    {
        public Post[] AllPosts { get; set; }

       public Dictionary<int, Post> postDictionary {get; set;}



        public PostCollection(Post[] posts)
        {
            this.AllPosts = posts;
             
           
        }
    }
}
