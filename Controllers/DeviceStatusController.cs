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
using Jarvis.Models;

namespace Jarvis.Controllers
{
    public class DeviceStatusController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DeviceStatus
        public IQueryable<DeviceStatus> GetDeviceStatus()
        {
            return db.DeviceStatus;
        }

        // GET: api/DeviceStatus/5
        [ResponseType(typeof(DeviceStatus))]
        public async Task<IHttpActionResult> GetDeviceStatus(int id)
        {
            DeviceStatus deviceStatus = await db.DeviceStatus.FindAsync(id);
            if (deviceStatus == null)
            {
                return NotFound();
            }

            return Ok(deviceStatus);
        }

        // PUT: api/DeviceStatus/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDeviceStatus(int id, DeviceStatus deviceStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deviceStatus.Id)
            {
                return BadRequest();
            }

            db.Entry(deviceStatus).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceStatusExists(id))
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

        // POST: api/DeviceStatus
        [ResponseType(typeof(DeviceStatus))]
        public async Task<IHttpActionResult> PostDeviceStatus(DeviceStatus deviceStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeviceStatus.Add(deviceStatus);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = deviceStatus.Id }, deviceStatus);
        }

        // DELETE: api/DeviceStatus/5
        [ResponseType(typeof(DeviceStatus))]
        public async Task<IHttpActionResult> DeleteDeviceStatus(int id)
        {
            DeviceStatus deviceStatus = await db.DeviceStatus.FindAsync(id);
            if (deviceStatus == null)
            {
                return NotFound();
            }

            db.DeviceStatus.Remove(deviceStatus);
            await db.SaveChangesAsync();

            return Ok(deviceStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeviceStatusExists(int id)
        {
            return db.DeviceStatus.Count(e => e.Id == id) > 0;
        }
    }
}