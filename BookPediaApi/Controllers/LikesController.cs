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
    public class LikesController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Likes
        public IQueryable<Like> GetLikes()
        {
            return db.Likes;
        }

        // GET: api/Likes/5
        [ResponseType(typeof(Like))]
        public IHttpActionResult GetLike(int id)
        {
            Like like = db.Likes.Find(id);
            if (like == null)
            {
                return NotFound();
            }

            return Ok(like);
        }

        // GET: api/likes?userId=12&&postId=12
        [ResponseType(typeof(Like))]
        public IHttpActionResult GetUser(int userId, int postId)
        {
            var likes = db.Likes.Where(e => e.inventoryId == postId && e.UserId == userId).Include(r => r.User).Include(r => r.inventory).ToList();
            return Ok(likes);
        }

        // GET: api/Ratings?postId=12
        [ResponseType(typeof(Like))]
        public IHttpActionResult GetUser(int postId)
        {
            //var posts = db.comments.Where(e => e.postId== postId).ToList();
            //var ratings = db.Ratings.Where(e => e.inventoryId == postId).ToList();
            var likes = db.Likes.Where(e => e.inventoryId == postId).Include(r => r.User).Include(r => r.inventory).ToList();
            return Ok(likes);
        }

        // PUT: api/Likes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLike(int id, Like like)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != like.id)
            {
                return BadRequest();
            }

            db.Entry(like).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikeExists(id))
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

        // POST: api/Likes
        [ResponseType(typeof(Like))]
        public IHttpActionResult PostLike(Like like)
        {
            var likes = db.Likes.SingleOrDefault((c) => c.UserId == like.UserId && c.inventoryId == like.inventoryId);
            if (likes != null)
            {
                //return StatusCode(HttpStatusCode.NoContent);
                return Ok(likes);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Likes.Add(like);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = like.id }, like);
        }

        // DELETE: api/Likes/5
        [ResponseType(typeof(Like))]
        public IHttpActionResult DeleteLike(int id)
        {
            Like like = db.Likes.Find(id);
            if (like == null)
            {
                return NotFound();
            }

            db.Likes.Remove(like);
            db.SaveChanges();

            return Ok(like);
        }

      /*  protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/

        private bool LikeExists(int id)
        {
            return db.Likes.Count(e => e.id == id) > 0;
        }
    }
}