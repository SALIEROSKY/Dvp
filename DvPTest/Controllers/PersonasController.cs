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
using DvPTest.Models;

namespace DvPTest.Controllers
{
    public class PersonasController : ApiController
    {
        private testworkEntities db = new testworkEntities();

        // GET: api/Personas
        public IQueryable<Persona> GetPersonas()
        {
            return db.Personas;
        }

        // GET: api/Personas/5
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> GetPersona(decimal id)
        {
            Persona persona = await db.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT: api/Personas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersona(decimal id, Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.Id)
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

            db.Personas.Add(persona);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonaExists(persona.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = persona.Id }, persona);
        }

        // DELETE: api/Personas/5
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> DeletePersona(decimal id)
        {
            Persona persona = await db.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            db.Personas.Remove(persona);
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

        private bool PersonaExists(decimal id)
        {
            return db.Personas.Count(e => e.Id == id) > 0;
        }
    }
}