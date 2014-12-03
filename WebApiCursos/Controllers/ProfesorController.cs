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
    public class ProfesorController : ApiController
    {
        IRepositorio<ProfesorViewModel,Profesor> repo=
            new Repositorio<ProfesorViewModel, Profesor>
                (new cursoEntities());

        // GET: api/Profesor
        public IEnumerable<ProfesorViewModel> Get()
        {
            return repo.Get();
        }

        // GET: api/Profesor/5
        public ProfesorViewModel Get(int id)
        {
            return repo.Get(id);
        }

        // POST: api/Profesor
        public void Post([FromBody]ProfesorViewModel value)
        {
            repo.Add(value);
        }

        // PUT: api/Profesor/5
        public void Put( [FromBody]ProfesorViewModel value)
        {
            repo.Actualizar(value);
        }

        // DELETE: api/Profesor/5
        public void Delete(int id)
        {
            repo.Borrar(id);
        }
    }
}
