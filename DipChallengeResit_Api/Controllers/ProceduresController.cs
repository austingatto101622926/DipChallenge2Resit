﻿using System;
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
using DipChallengeResit_Api.Models;

namespace DipChallengeResit_Api.Controllers
{
    public class ProceduresController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Procedures
        public IQueryable<Procedure> GetProcedures()
        {
            return db.Procedures;
        }

        // GET: api/Procedures/5
        [ResponseType(typeof(Procedure))]
        public async Task<IHttpActionResult> GetProcedure(int id)
        {
            Procedure procedure = await db.Procedures.FindAsync(id);
            if (procedure == null)
            {
                return NotFound();
            }

            return Ok(procedure);
        }

        // PUT: api/Procedures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProcedure(int id, Procedure procedure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != procedure.ProcedureID)
            {
                return BadRequest();
            }

            db.Entry(procedure).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedureExists(id))
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

        // POST: api/Procedures
        [ResponseType(typeof(Procedure))]
        public async Task<IHttpActionResult> PostProcedure(Procedure procedure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Procedures.Add(procedure);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = procedure.ProcedureID }, procedure);
        }

        // DELETE: api/Procedures/5
        [ResponseType(typeof(Procedure))]
        public async Task<IHttpActionResult> DeleteProcedure(int id)
        {
            Procedure procedure = await db.Procedures.FindAsync(id);
            if (procedure == null)
            {
                return NotFound();
            }

            db.Procedures.Remove(procedure);
            await db.SaveChangesAsync();

            return Ok(procedure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProcedureExists(int id)
        {
            return db.Procedures.Count(e => e.ProcedureID == id) > 0;
        }
    }
}