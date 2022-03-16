using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPediaApi.Models
{
    public class Foollow
    {
        public int id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int followingUserId { get; set; }
        public string followingUserDisplayName { get; set; }
        public string followingUserEmail { get; set; }
        public string followingUserPhotoURL { get; set; }
        public int follow { get; set; }

    }
}