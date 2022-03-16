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
    public class BlogsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Blogs
        public IQueryable<Blog> Getblogs()
        {
            return db.blogs;
        }

        // GET: api/Blogs/5
        [ResponseType(typeof(Blog))]
        public IHttpActionResult GetBlog(int id)
        {
            Blog blog = db.blogs.Find(id);
            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        // PUT: api/Blogs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBlog(int id, Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blog.id)
            {
                return BadRequest();
            }

            db.Entry(blog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
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

        // POST: api/Blogs
        [ResponseType(typeof(Blog))]
        public IHttpActionResult PostBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.blogs.Add(blog);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = blog.id }, blog);
        }

        // DELETE: api/Blogs/5
        [ResponseType(typeof(Blog))]
        public IHttpActionResult DeleteBlog(int id)
        {
            Blog blog = db.blogs.Find(id);
            if (blog == null)
            {
                return NotFound();
            }

            db.blogs.Remove(blog);
            db.SaveChanges();

            return Ok(blog);
        }

     /*   protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/

        private bool BlogExists(int id)
        {
            return db.blogs.Count(e => e.id == id) > 0;
        }
    }
}