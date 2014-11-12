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
using WebApiCursos.Models;

namespace WebApiCursos.Controllers
{
    public class CursoesController : ApiController
    {
        private cursoEntities db = new cursoEntities();

        // GET: api/Cursoes
        public IQueryable<Curso> GetCurso()
        {
            return db.Curso;
        }

        // GET: api/Cursoes/5
        [ResponseType(typeof(Curso))]
        public IHttpActionResult GetCurso(int id)
        {
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        // PUT: api/Cursoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCurso(int id, Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != curso.idCurso)
            {
                return BadRequest();
            }

            db.Entry(curso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
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

        // POST: api/Cursoes
        [ResponseType(typeof(Curso))]
        public IHttpActionResult PostCurso(Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Curso.Add(curso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = curso.idCurso }, curso);
        }

        // DELETE: api/Cursoes/5
        [ResponseType(typeof(Curso))]
        public IHttpActionResult DeleteCurso(int id)
        {
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return NotFound();
            }

            db.Curso.Remove(curso);
            db.SaveChanges();

            return Ok(curso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CursoExists(int id)
        {
            return db.Curso.Count(e => e.idCurso == id) > 0;
        }
    }
}