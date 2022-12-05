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
    public class VaticiniosController : ApiController
    {
        private QuinielaEntities2 db = new QuinielaEntities2();

        // GET: api/Vaticinios
        public IQueryable<Vaticinio> GetVaticinio()
        {
            return db.Vaticinio;
        }

        // GET: api/Vaticinios/5
        [ResponseType(typeof(Vaticinio))]
        public async Task<IHttpActionResult> GetVaticinio(int id)
        {
            Vaticinio vaticinio = await db.Vaticinio.FindAsync(id);
            if (vaticinio == null)
            {
                return NotFound();
            }

            return Ok(vaticinio);
        }

        // PUT: api/Vaticinios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVaticinio(int id, Vaticinio vaticinio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vaticinio.idVati)
            {
                return BadRequest();
            }

            db.Entry(vaticinio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaticinioExists(id))
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

        // POST: api/Vaticinios
        [ResponseType(typeof(Vaticinio))]
        public async Task<IHttpActionResult> PostVaticinio(Vaticinio vaticinio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vaticinio.Add(vaticinio);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vaticinio.idVati }, vaticinio);
        }

        // DELETE: api/Vaticinios/5
        [ResponseType(typeof(Vaticinio))]
        public async Task<IHttpActionResult> DeleteVaticinio(int id)
        {
            Vaticinio vaticinio = await db.Vaticinio.FindAsync(id);
            if (vaticinio == null)
            {
                return NotFound();
            }

            db.Vaticinio.Remove(vaticinio);
            await db.SaveChangesAsync();

            return Ok(vaticinio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VaticinioExists(int id)
        {
            return db.Vaticinio.Count(e => e.idVati == id) > 0;
        }
    }
}