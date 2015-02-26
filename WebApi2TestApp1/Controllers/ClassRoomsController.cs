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
using WebApi2TestApp1.Models;

namespace WebApi2TestApp1.Controllers
{
    public class ClassRoomsController : ApiController
    {
        private FuJenClassroomModel db = new FuJenClassroomModel();

        // GET: api/ClassRooms
        public IQueryable<ClassRooms> GetClassRooms()
        {
            return db.ClassRooms;
        }

        // GET: api/ClassRooms/5
        [ResponseType(typeof(ClassRooms))]
        public IHttpActionResult GetClassRooms(int id)
        {
            ClassRooms classRooms = db.ClassRooms.Find(id);
            if (classRooms == null)
            {
                return NotFound();
            }

            return Ok(classRooms);
        }

        // PUT: api/ClassRooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClassRooms(int id, ClassRooms classRooms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classRooms.id)
            {
                return BadRequest();
            }

            db.Entry(classRooms).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassRoomsExists(id))
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

        // POST: api/ClassRooms
        [ResponseType(typeof(ClassRooms))]
        public IHttpActionResult PostClassRooms(ClassRooms classRooms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClassRooms.Add(classRooms);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = classRooms.id }, classRooms);
        }

        // DELETE: api/ClassRooms/5
        [ResponseType(typeof(ClassRooms))]
        public IHttpActionResult DeleteClassRooms(int id)
        {
            ClassRooms classRooms = db.ClassRooms.Find(id);
            if (classRooms == null)
            {
                return NotFound();
            }

            db.ClassRooms.Remove(classRooms);
            db.SaveChanges();

            return Ok(classRooms);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassRoomsExists(int id)
        {
            return db.ClassRooms.Count(e => e.id == id) > 0;
        }
    }
}