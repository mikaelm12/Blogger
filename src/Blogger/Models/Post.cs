using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Models
{
    public class Post
    {
       
        public int PostId { get; set; }
        
        public String Title { get; set; }

        public String Text { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        public String PosterEmail { get; set; }
        public int PosterId { get; set; }

       public string Slug { get; set; }

    }
}