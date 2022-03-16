using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPediaApi.Models
{
    public class Usersaved
    {
        public int id { get; set; }
        public string userEmail { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Inventory inventory { get; set; }
        public int inventoryId { get; set; }
    }
}