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
    public class FoollowsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Foollows
        public IEnumerable<Foollow> Getfoollows()
        {
            return db.foollows.Include(r => r.User).ToList(); ;
        }

        // GET: api/Foollows/5
        [ResponseType(typeof(Foollow))]
        public IHttpActionResult GetFoollow(int id)
        {
            Foollow foollow = db.foollows.Find(id);
            if (foollow == null)
            {
                return NotFound();
            }

            return Ok(foollow);
        }

        // GET: api/Foollows?userId=12
        [ResponseType(typeof(Comment))]
        public IHttpActionResult GetUser(int userId)
        {
            //var posts = db.comments.Where(e => e.postId== postId).ToList();
            var posts = db.foollows.Where(e => e.UserId == userId).Include(r => r.User).ToList();
            return Ok(posts);
        }

        // GET: api/Foollows?userId=12
        [ResponseType(typeof(Comment))]
        public IHttpActionResult GetUsers(int followingUserId)
        {
            //var posts = db.comments.Where(e => e.postId== postId).ToList();
            var posts = db.foollows.Where(e => e.followingUserId == followingUserId).Include(r => r.User).ToList();
            return Ok(posts);
        }

        // PUT: api/Foollows/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFoollow(int id, Foollow foollow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foollow.id)
            {
                return BadRequest();
            }

            db.Entry(foollow).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoollowExists(id))
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

        // POST: api/Foollows
        [ResponseType(typeof(Foollow))]
        public IHttpActionResult PostFoollow(Foollow foollow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.foollows.Add(foollow);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = foollow.id }, foollow);
        }

        // DELETE: api/Foollows/5
        [ResponseType(typeof(Foollow))]
        public IHttpActionResult DeleteFoollow(int id)
        {
            Foollow foollow = db.foollows.Find(id);
            if (foollow == null)
            {
                return NotFound();
            }

            db.foollows.Remove(foollow);
            db.SaveChanges();

            return Ok(foollow);
        }

     /*   protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/

        private bool FoollowExists(int id)
        {
            return db.foollows.Count(e => e.id == id) > 0;
        }
    }
}