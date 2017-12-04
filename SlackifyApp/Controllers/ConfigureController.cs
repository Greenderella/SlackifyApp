using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SlackifyApp.Models;

namespace SlackifyApp.Controllers
{
    public class ConfigureController : ApiController
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: api/Configure
        public IQueryable<DataBaseConfigure> GetDB()
        {
            return db.DB;
        }

        // GET: api/Configure/5
        [ResponseType(typeof(DataBaseConfigure))]
        public IHttpActionResult GetDataBaseConfigure(int id)
        {
            DataBaseConfigure dataBaseConfigure = db.DB.Find(id);
            if (dataBaseConfigure == null)
            {
                return NotFound();
            }

            return Ok(dataBaseConfigure);
        }

        // PUT: api/Configure/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDataBaseConfigure(int id, DataBaseConfigure dataBaseConfigure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dataBaseConfigure.ID)
            {
                return BadRequest();
            }

            db.Entry(dataBaseConfigure).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataBaseConfigureExists(id))
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

        // POST: api/Configure
        [ResponseType(typeof(DataBaseConfigure))]
        public IHttpActionResult PostDataBaseConfigure(DataBaseConfigure dataBaseConfigure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DB.Add(dataBaseConfigure);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dataBaseConfigure.ID }, dataBaseConfigure);
        }

        // DELETE: api/Configure/5
        [ResponseType(typeof(DataBaseConfigure))]
        public IHttpActionResult DeleteDataBaseConfigure(int id)
        {
            DataBaseConfigure dataBaseConfigure = db.DB.Find(id);
            if (dataBaseConfigure == null)
            {
                return NotFound();
            }

            db.DB.Remove(dataBaseConfigure);
            db.SaveChanges();

            return Ok(dataBaseConfigure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DataBaseConfigureExists(int id)
        {
            return db.DB.Count(e => e.ID == id) > 0;
        }
    }
}