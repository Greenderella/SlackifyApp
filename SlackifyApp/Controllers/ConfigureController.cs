using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using SlackifyApp.Models;

namespace SlackifyApp.Controllers
{
    public class ConfigureController : ApiController
    {
        private ConfigureDBContext _db = new ConfigureDBContext();

        // GET: api/Configure
        public IQueryable<DataBaseConfigure> GetDb()
        {
            return _db.DB;
        }

        // GET: api/Configure/5
        [ResponseType(typeof(DataBaseConfigure))]
        public IHttpActionResult GetDataBaseConfigure(int id)
        {
            DataBaseConfigure dataBaseConfigure = _db.DB.Find(id);
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

            _db.Entry(dataBaseConfigure).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
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

            _db.DB.Add(dataBaseConfigure);
            _db.SaveChanges();

            return Redirect("/Home/Configure#ProximoPaso");
        }

        // DELETE: api/Configure/5
        [ResponseType(typeof(DataBaseConfigure))]
        public IHttpActionResult DeleteDataBaseConfigure(int id)
        {
            DataBaseConfigure dataBaseConfigure = _db.DB.Find(id);
            if (dataBaseConfigure == null)
            {
                return NotFound();
            }

            _db.DB.Remove(dataBaseConfigure);
            _db.SaveChanges();

            return Ok(dataBaseConfigure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DataBaseConfigureExists(int id)
        {
            return _db.DB.Count(e => e.ID == id) > 0;
        }
    }
}