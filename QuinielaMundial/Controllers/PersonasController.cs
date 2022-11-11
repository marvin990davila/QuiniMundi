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
    public class PersonasController : ApiController
    {
        private QuinielaEntities2 db = new QuinielaEntities2();

        // GET: api/Personas
        public IEnumerable<Models.Persona> Get()
        {
            IEnumerable<Models.Persona> lst;
            using (Models.QuinielaEntities2 db = new Models.QuinielaEntities2())
            {
                lst = db.Persona.ToList();
            }

            return lst;
        }

        /*
        // GET: api/Personas
        public IQueryable<Persona> GetPersona()
        {
            return db.Persona;
        }*/

        // GET: api/Personas/5
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> GetPersona(int id)
        {
            Persona persona = await db.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT: api/Personas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersona(int id, Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.idPersona)
            {
                return BadRequest();
            }

            db.Entry(persona).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/Personas
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> PostPersona(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persona.Add(persona);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = persona.idPersona }, persona);
        }

        // DELETE: api/Personas/5
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> DeletePersona(int id)
        {
            Persona persona = await db.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            db.Persona.Remove(persona);
            await db.SaveChangesAsync();

            return Ok(persona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonaExists(int id)
        {
            return db.Persona.Count(e => e.idPersona == id) > 0;
        }
    }
}