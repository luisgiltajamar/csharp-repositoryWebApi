using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCursos.Models;
using WebApiCursos.Models.ViewModel;
using WebApiCursos.Repositorio;

namespace WebApiCursos.Controllers
{
    public class CursoController : ApiController
    {
        private IRepositorio<Curso> repo=
            new Repositorio<Curso>(new cursoEntities());

        // GET: api/Curso
        public IEnumerable<Curso> Get()
        {
            var data = repo.Get();
           /* List<CursoViewModel> lc=new List<CursoViewModel>();

            foreach (var curso in data)
            {
                lc.Add(new CursoViewModel()
                {
                    idCurso = curso.idCurso,
                    NombreProfesor = curso.Profesor1.nombre,
                    nombre = curso.nombre,
                    duracion = curso.duracion,
                    inicio = curso.inicio,
                    profesor = curso.profesor


                });
            }
            */

            return data;
        }

        // GET: api/Curso/5
        public Curso Get(int id)
        {
            return repo.Get(id);
        }

        // POST: api/Curso
        public void Post([FromBody]Curso value)
        {
            repo.Add(value);

        }

        // PUT: api/Curso/5
        public void Put([FromBody]Curso value)
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
