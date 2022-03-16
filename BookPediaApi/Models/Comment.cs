using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPediaApi.Models
{
    public class Comment
    {
        public int id { get; set; }
        public string comment { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int postId { get; set; }
        
    }
}