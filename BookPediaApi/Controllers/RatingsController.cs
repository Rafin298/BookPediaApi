using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookPediaApi.Models;

namespace BookPediaApi.Controllers
{
    public class RatingsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Ratings
        public IQueryable<Rating> GetRatings()
        {
            return db.Ratings;
        }

        // GET: api/Ratings/5
        [ResponseType(typeof(Rating))]
        public IHttpActionResult GetRating(int id)
        {
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return NotFound();
            }

            return Ok(rating);
        }

        // GET: api/Ratings?userId=12&&postId=12
        [ResponseType(typeof(Rating))]
        public IHttpActionResult GetUser(int userId, int postId)
        {
            var ratings = db.Ratings.Where(e => e.inventoryId == postId && e.UserId == userId).Include(r => r.User).Include(r => r.inventory).ToList();
            return Ok(ratings);
        }

        // GET: api/Ratings?postId=12
        [ResponseType(typeof(Rating))]
        public IHttpActionResult GetUser(int postId)
        {
            //var posts = db.comments.Where(e => e.postId== postId).ToList();
            //var ratings = db.Ratings.Where(e => e.inventoryId == postId).ToList();
            var ratings = db.Ratings.Where(e => e.inventoryId == postId).Include(r => r.User).Include(r => r.inventory).ToList();
            return Ok(ratings);
        }

        // PUT: api/Ratings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRating(int id, Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rating.id)
            {
                return BadRequest();
            }

            db.Entry(rating).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ratings
        [ResponseType(typeof(Rating))]
        public IHttpActionResult PostRating(Rating rating)
        {
            //var ratings = db.Ratings.SingleOrDefault((c) => c.UserId == rating.UserId);
            //var ratings = db.Ratings.Where(e => e.UserId == rating.UserId && e.inventoryId == rating.inventoryId).ToList();
            var ratings = db.Ratings.SingleOrDefault((c) => c.UserId == rating.UserId && c.inventoryId == rating.inventoryId);
            if (ratings != null)
            {
                //return StatusCode(HttpStatusCode.NoContent);
                return Ok(ratings);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ratings.Add(rating);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rating.id }, rating);
        }

        // DELETE: api/Ratings/5
        [ResponseType(typeof(Rating))]
        public IHttpActionResult DeleteRating(int id)
        {
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return NotFound();
            }

            db.Ratings.Remove(rating);
            db.SaveChanges();

            return Ok(rating);
        }

      /*  protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/

        private bool RatingExists(int id)
        {
            return db.Ratings.Count(e => e.id == id) > 0;
        }
    }
}