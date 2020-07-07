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
using Kaiban.Models;
using Kaiban.ViewModel;

namespace Kaiban.Controllers.Api
{
    public class AdsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Ads
        public IQueryable<Ads> GetAds()
        {
            return db.Adses;
        }

        // GET: api/Ads/5
        [ResponseType(typeof(Ads))]
        public IHttpActionResult GetAds(int id)
        {
            Ads ads = db.Adses.Find(id);
            if (ads == null)
            {
                return NotFound();
            }

            return Ok(ads);
        }

        // PUT: api/Ads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAds(int id, Ads ads)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ads.Id)
            {
                return BadRequest();
            }

            db.Entry(ads).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdsExists(id))
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

        // POST: api/Ads
        [ResponseType(typeof(Ads))]
        public IHttpActionResult PostAds(Ads ads)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Adses.Add(ads);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ads.Id }, ads);
        }

        // DELETE: api/Ads/5
        [ResponseType(typeof(Ads))]
        public IHttpActionResult DeleteAds(int id)
        {
            Ads ads = db.Adses.Find(id);
            if (ads == null)
            {
                return NotFound();
            }

            db.Adses.Remove(ads);
            db.SaveChanges();

            return Ok(ads);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdsExists(int id)
        {
            return db.Adses.Count(e => e.Id == id) > 0;
        }



    }
}