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
    public class MundialsController : ApiController
    {
        private QuinielaEntities2 db = new QuinielaEntities2();

        // GET: api/Mundials
        public IQueryable<Mundial> GetMundial()
        {
            return db.Mundial;
        }

        // GET: api/Mundials/5
        [ResponseType(typeof(Mundial))]
        public async Task<IHttpActionResult> GetMundial(int id)
        {
            Mundial mundial = await db.Mundial.FindAsync(id);
            if (mundial == null)
            {
                return NotFound();
            }

            return Ok(mundial);
        }

        // PUT: api/Mundials/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMundial(int id, Mundial mundial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mundial.idMundial)
            {
                return BadRequest();
            }

            db.Entry(mundial).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MundialExists(id))
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

        // POST: api/Mundials
        [ResponseType(typeof(Mundial))]
        public async Task<IHttpActionResult> PostMundial(Mundial mundial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mundial.Add(mundial);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mundial.idMundial }, mundial);
        }

        // DELETE: api/Mundials/5
        [ResponseType(typeof(Mundial))]
        public async Task<IHttpActionResult> DeleteMundial(int id)
        {
            Mundial mundial = await db.Mundial.FindAsync(id);
            if (mundial == null)
            {
                return NotFound();
            }

            db.Mundial.Remove(mundial);
            await db.SaveChangesAsync();

            return Ok(mundial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MundialExists(int id)
        {
            return db.Mundial.Count(e => e.idMundial == id) > 0;
        }
    }
}