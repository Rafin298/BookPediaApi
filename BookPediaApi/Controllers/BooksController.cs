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
    public class BooksController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Books
        public IQueryable<Book> Getbooks()
        {
            return db.books;
        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            Book book = db.books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

     /*   // GET: api/Books?all=gg
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(string all)
        {
            var books = (from ep in db.books
                         join e in db.users on ep.UserId equals e.id
                         join t in db.blogs on e.id equals t.UserId
                         select new
                         {
                             authorName = e.displayName,
                             userMail = e.email,
                             postTitle = t.blogTitle,
                             bookName = ep.bookName,
                             bookURL = ep.bookURL,
                             blogPost = t.blogDetails,
                             category = ep.category
                         });
            /*   var book = db.books.Include(r => r.User)
                   .Join(db.blogs,
                         p => p.UserId,
                         e => e.UserId,
                         (p, e) => new {
                             authorName = p.bookName,
                             userMail = e.blogTitle,
                             postTitle= e.blogTitle,
                             bookURL =
                             blogPost=
                             category=
                         }
                         ).Take(5); */
         /*   if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }*/
        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.id)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.id }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

      /*  protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/

        private bool BookExists(int id)
        {
            return db.books.Count(e => e.id == id) > 0;
        }
    }
}