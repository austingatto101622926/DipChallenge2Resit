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
using DipChallengeResit_Api.Models;

namespace DipChallengeResit_Api.Controllers
{
    public class TreatmentsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Treatments
        public IQueryable<Treatment> GetTreatments()
        {
            return db.Treatments;
        }

        // GET: api/Treatments/5
        [ResponseType(typeof(Treatment))]
        public async Task<IHttpActionResult> GetTreatment(int id)
        {
            Treatment treatment = await db.Treatments.FindAsync(id);
            if (treatment == null)
            {
                return NotFound();
            }

            return Ok(treatment);
        }

        // PUT: api/Treatments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTreatment(int id, Treatment treatment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != treatment.TreatmentID)
            {
                return BadRequest();
            }

            db.Entry(treatment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatmentExists(id))
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

        // POST: api/Treatments
        [ResponseType(typeof(Treatment))]
        public async Task<IHttpActionResult> PostTreatment(Treatment treatment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Treatments.Add(treatment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = treatment.TreatmentID }, treatment);
        }

        // DELETE: api/Treatments/5
        [ResponseType(typeof(Treatment))]
        public async Task<IHttpActionResult> DeleteTreatment(int id)
        {
            Treatment treatment = await db.Treatments.FindAsync(id);
            if (treatment == null)
            {
                return NotFound();
            }

            db.Treatments.Remove(treatment);
            await db.SaveChangesAsync();

            return Ok(treatment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TreatmentExists(int id)
        {
            return db.Treatments.Count(e => e.TreatmentID == id) > 0;
        }
    }
}