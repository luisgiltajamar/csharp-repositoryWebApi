using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiCursos.Models;
using WebApiCursos.Models.ViewModel;
using WebApiCursos.Repositorio;

namespace WebApiCursos.Controllers
{
    [EnableCors("*","*","*")]
    public class CursoController : ApiController
    {
        private IRepositorio<CursoViewModel,Curso> repo=
            new Repositorio<CursoViewModel,Curso>
                (new cursoEntities());

        // GET: api/Curso
        public IEnumerable<CursoViewModel> Get()
        {
            var data = repo.Get();
            return data;
        }

        // GET: api/Curso/5
        public CursoViewModel Get(int id)
        {
            return repo.Get(id);
        }
        [HttpGet]
        public IEnumerable<CursoViewModel> ByNombre(String args)
        {
            return repo.Get(o => o.nombre == args);
        }
        [HttpGet]
        public IEnumerable<CursoViewModel> ByDuracion(int args)
        {
            return repo.Get(o => o.duracion == args);
        }
        [HttpGet]
        public IEnumerable<CursoViewModel> ByDuracionNombre(int args,String args2)
        {
            return repo.Get(o => o.duracion == args && o.nombre==args2);
        }
        // POST: api/Curso
        public void Post([FromBody]CursoViewModel value)
        {
            repo.Add(value);

        }

        // PUT: api/Curso/5
        public void Put([FromBody]CursoViewModel value)
        {
            repo.Actualizar(value);
        }

        // DELETE: api/Curso/5
        public void Delete(int id)
        {
            repo.Borrar(id);
        }
    }
}
