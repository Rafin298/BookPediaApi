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
    public class CommentsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Comments
        public IEnumerable<Comment> Getcomments()
        {
            return db.comments.Include(r => r.User).ToList();
        }

        // GET: api/Comments/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult GetComment(int id)
        {
            Comment comment = db.comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // GET: api/Comments?postId=12
        [ResponseType(typeof(Comment))]
        public IHttpActionResult GetUser(int postId)
        {
            //var posts = db.comments.Where(e => e.postId== postId).ToList();
            var posts = db.comments.Where(e => e.postId == postId).Include(r => r.User).ToList();
            return Ok(posts);
        }

        // PUT: api/Comments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComment(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.id)
            {
                return BadRequest();
            }

            db.Entry(comment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        [ResponseType(typeof(Comment))]
        public IHttpActionResult PostComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.comments.Add(comment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comment.id }, comment);
        }

        // DELETE: api/Comments/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult DeleteComment(int id)
        {
            Comment comment = db.comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            db.comments.Remove(comment);
            db.SaveChanges();

            return Ok(comment);
        }

       /* protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/

        private bool CommentExists(int id)
        {
            return db.comments.Count(e => e.id == id) > 0;
        }
    }
}