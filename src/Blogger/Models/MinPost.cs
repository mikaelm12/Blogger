using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Models
{
    public class MinPost
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }
    }
}
