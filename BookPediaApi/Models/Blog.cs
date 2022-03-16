using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPediaApi.Models
{
    public class Blog
    {
        public int id { get; set; }
        public string blogTitle { get; set; }
        public string blogDetails { get; set; }

        public string blogcoverImageURL { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}