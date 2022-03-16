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
    public class UsersavedsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Usersaveds
     /*   public IQueryable<Usersaved> GetUsersaveds()
        {
            return db.Usersaveds;
        }*/

        // GET: api/Usersaveds
        public IEnumerable<Usersaved> Getcomments()
        {
            return db.Usersaveds.Include(r => r.User).Include(r =>r.inventory).ToList();
        }

        // GET: api/Usersaveds/5
        [ResponseType(typeof(Usersaved))]
        public IHttpActionResult GetUsersaved(int id)
        {
            Usersaved usersaved = db.Usersaveds.Find(id);
            if (usersaved == null)
            {
                return NotFound();
            }

            return Ok(usersaved);
        }
        // GET: api/Usersaveds?email=email
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult GetUsersaved(string email)
        {
            var saved = db.Usersaveds.Where(e => e.userEmail.ToLower() == email.ToLower()).Include(r => r.User).Include(r => r.inventory).ToList();
            return Ok(saved);

        }

        // PUT: api/Usersaveds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsersaved(int id, Usersaved usersaved)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usersaved.id)
            {
                return BadRequest();
            }

            db.Entry(usersaved).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersavedExists(id))
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

        // POST: api/Usersaveds
        [ResponseType(typeof(Usersaved))]
        public IHttpActionResult PostUsersaved(Usersaved usersaved)
        {
            var usersaveds = db.Usersaveds.SingleOrDefault((c) => c.inventoryId == usersaved.inventoryId);
            if (usersaveds != null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usersaveds.Add(usersaved);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usersaved.id }, usersaved);
        }

        // DELETE: api/Usersaveds/5
        [ResponseType(typeof(Usersaved))]
        public IHttpActionResult DeleteUsersaved(int id)
        {
            Usersaved usersaved = db.Usersaveds.Find(id);
            if (usersaved == null)
            {
                return NotFound();
            }

            db.Usersaveds.Remove(usersaved);
            db.SaveChanges();

            return Ok(usersaved);
        }

       /* protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/

        private bool UsersavedExists(int id)
        {
            return db.Usersaveds.Count(e => e.id == id) > 0;
        }
    }
}