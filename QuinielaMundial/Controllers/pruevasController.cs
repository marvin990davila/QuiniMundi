using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using QuinielaMundial.Models;

namespace QuinielaMundial.Controllers
{
    public class pruevasController : ApiController
    {
        private QuinielaEntities2 db = new QuinielaEntities2();

        // GET: api/pruevas
        public IQueryable<pruevas> Getpruevas()
        {
            return db.pruevas;
        }

        // GET: api/pruevas/5
        [ResponseType(typeof(pruevas))]
        public async Task<IHttpActionResult> Getpruevas(int id)
        {
            pruevas pruevas = await db.pruevas.FindAsync(id);
            if (pruevas == null)
            {
                return NotFound();
            }

            return Ok(pruevas);
        }

        // PUT: api/pruevas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpruevas(int id, pruevas pruevas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pruevas.idPrueva)
            {
                return BadRequest();
            }

            db.Entry(pruevas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pruevasExists(id))
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

        // POST: api/pruevas
        [ResponseType(typeof(pruevas))]
        public async Task<IHttpActionResult> Postpruevas(pruevas pruevas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pruevas.Add(pruevas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pruevas.idPrueva }, pruevas);
        }

        // DELETE: api/pruevas/5
        [ResponseType(typeof(pruevas))]
        public async Task<IHttpActionResult> Deletepruevas(int id)
        {
            pruevas pruevas = await db.pruevas.FindAsync(id);
            if (pruevas == null)
            {
                return NotFound();
            }

            db.pruevas.Remove(pruevas);
            await db.SaveChangesAsync();

            return Ok(pruevas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool pruevasExists(int id)
        {
            return db.pruevas.Count(e => e.idPrueva == id) > 0;
        }
    }
}