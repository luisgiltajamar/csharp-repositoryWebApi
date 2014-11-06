using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApiCursos.Models;


namespace WebApiCursos.Repositorio
{
    public class Repositorio<TEntidad> : IRepositorio<TEntidad> where TEntidad : class 
    {

        protected cursoEntities Context;

        public Repositorio(cursoEntities context)
        {
            Context = context;
        }

        protected DbSet<TEntidad> DbSet
        {
            get { return Context.Set<TEntidad>(); }


        }

        public int Add(TEntidad modelo)
        {
            throw new NotImplementedException();
        }

        public int Borrar(TEntidad modelo)
        {
            throw new NotImplementedException();
        }

        public int Borrar(Expression<Func<TEntidad, bool>> lam)
        {
            throw new NotImplementedException();
        }

        public int Actualizar(TEntidad modelo)
        {
            throw new NotImplementedException();
        }

        public List<TEntidad> Get()
        {
            throw new NotImplementedException();
        }

        public List<TEntidad> Get(Expression<Func<TEntidad, bool>> lam)
        {
            throw new NotImplementedException();
        }

        public TEntidad Get(int pk)
        {
            throw new NotImplementedException();
        }
    }
}