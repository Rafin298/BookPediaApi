using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPediaApi.Models
{
    public class Book
    {
        public int id { get; set; }
        public string bookName { get; set; }
        public string bookURL { get; set; }
        public string coverImageURL { get; set; }
        public string category { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}