using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPediaApi.Models
{
    public class User
    {
        public int id { get; set; }
        public string displayName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string date { get; set; }
        public string gender { get; set; }
        public string photoUrl { get; set; }
        public string city { get; set; }
        public string work { get; set; }
    }
}