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
    public class QuinielasController : ApiController
    {
        private QuinielaEntities2 db = new QuinielaEntities2();

        // GET: api/Quinielas
        public IQueryable<Quiniela> GetQuiniela()
        {
            return db.Quiniela;
        }

        // GET: api/Quinielas/5
        [ResponseType(typeof(Quiniela))]
        public async Task<IHttpActionResult> GetQuiniela(int id)
        {
            Quiniela quiniela = await db.Quiniela.FindAsync(id);
            if (quiniela == null)
            {
                return NotFound();
            }

            return Ok(quiniela);
        }

        // PUT: api/Quinielas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuiniela(int id, Quiniela quiniela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quiniela.idQui)
            {
                return BadRequest();
            }

            db.Entry(quiniela).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuinielaExists(id))
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

        // POST: api/Quinielas
        [ResponseType(typeof(Quiniela))]
        public async Task<IHttpActionResult> PostQuiniela(Quiniela quiniela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Quiniela.Add(quiniela);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = quiniela.idQui }, quiniela);
        }

        // DELETE: api/Quinielas/5
        [ResponseType(typeof(Quiniela))]
        public async Task<IHttpActionResult> DeleteQuiniela(int id)
        {
            Quiniela quiniela = await db.Quiniela.FindAsync(id);
            if (quiniela == null)
            {
                return NotFound();
            }

            db.Quiniela.Remove(quiniela);
            await db.SaveChangesAsync();

            return Ok(quiniela);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuinielaExists(int id)
        {
            return db.Quiniela.Count(e => e.idQui == id) > 0;
        }
    }
}