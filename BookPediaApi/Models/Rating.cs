using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPediaApi.Models
{
    public class Rating
    {
        public int id { get; set; }
        public float rating { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Inventory inventory { get; set; }
        public int inventoryId { get; set; }
    }
}