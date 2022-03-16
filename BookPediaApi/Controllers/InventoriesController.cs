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
    public class InventoriesController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/Inventories
        public IQueryable<Inventory> Getinventory()
        {
            return db.inventory;
        }

        // GET: api/Inventories/5
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult GetInventory(int id)
        {
            Inventory inventory = db.inventory.Find(id);
            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }


       // GET: api/Inventories?email=email
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult GetUser(string email)
        {
            var inventory = db.inventory.Where(e => e.email.ToLower() == email.ToLower()).ToList();
            return Ok(inventory);

        }

        // GET: api/Inventories?email=email
        /*[ResponseType(typeof(Inventory))]
        public IHttpActionResult GetUser(string email)
        {
            Inventory inventory = db.inventory.Where(e => e.email == email).ToList();
            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }*/

        // GET: api/Inventories/5
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult GetInventory(string type)
        {
            Inventory inventory = db.inventory.Find(type);
            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        // PUT: api/Inventories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventory(int id, Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventory.id)
            {
                return BadRequest();
            }

            db.Entry(inventory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
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

        // POST: api/Inventories
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult PostInventory(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.inventory.Add(inventory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = inventory.id }, inventory);
        }

        // DELETE: api/Inventories/5
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult DeleteInventory(int id)
        {
            Inventory inventory = db.inventory.Find(id);
            if (inventory == null)
            {
                return NotFound();
            }

            db.inventory.Remove(inventory);
            db.SaveChanges();

            return Ok(inventory);
        }

     /*   protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/

        private bool InventoryExists(int id)
        {
            return db.inventory.Count(e => e.id == id) > 0;
        }
    }
}