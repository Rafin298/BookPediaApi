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
    public class UsersController : ApiController
    {
        private MyDbContext db = new MyDbContext();

         //GET: api/Users
      //    public IEnumerable<User> Getusers()
       //    {
       //      return db.users.ToList();
        // }
         public IQueryable<User> Getusers()
          {
              return db.users;
         }

        /*  [HttpGet]
          public HttpResponseMessage Getusers(string gender = "All")
          {
              switch (gender.ToLower())
              {
                  case "all":
                      return Request.CreateResponse(db.users.ToList());
                  case "male":
                      return Request.CreateResponse(db.users.Where(e => e.gender == "male").ToList());
                  case "female":
                      return Request.CreateResponse(db.users.Where(e => e.gender == "female").ToList());
                  default:
                      return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Value for gender must be Male,Female or All." + gender +
                                                         " is invalid.");
              }
          }   */

        // GET: api/Users?email=email
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string email)
        {
            User user = db.users.SingleOrDefault((c)=>c.email==email);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }  

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.id)
            {
                return BadRequest(ModelState);
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        //put: api/Users?email=email
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(string email, User user)
        {
            User userr = db.users.SingleOrDefault((c) => c.email == email);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          //  if (email != user.email)
          //  {
          //      return BadRequest(ModelState);
          //  }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(userr.id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            User userr = db.users.SingleOrDefault((c) => c.email == user.email);
            if (userr != null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

      /*  protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/

        private bool UserExists(int id)
        {
            return db.users.Count(e => e.id == id) > 0;
        }
    }
}