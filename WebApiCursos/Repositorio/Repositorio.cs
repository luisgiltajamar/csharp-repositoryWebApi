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

        public virtual int Add(TEntidad modelo)
        {
            DbSet.Add(modelo);
            int n = 0;
            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return n;
        }

        public virtual int Borrar(int id)
        {

            var obj = Get(id);

            DbSet.Remove(obj);
            int n = 0;
            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return n;
        }

        public virtual int Borrar(Expression<Func<TEntidad, bool>> lam)
        {
            var datos = Get(lam);
            DbSet.RemoveRange(datos);
            int n = 0;
            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return n;

        }

        public virtual int Actualizar(TEntidad modelo)
        {

            Context.Entry(modelo).State = EntityState.Modified;
            int n = 0;
            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return n;

        }
         
        public virtual List<TEntidad> Get()
        {
            return DbSet.ToList();
        }

        public virtual List<TEntidad> Get(Expression<Func<TEntidad, bool>> lam)
        {
            return DbSet.Where(lam).ToList();
        }

        public virtual TEntidad Get(int pk)
        {
            return DbSet.Find(pk);
        }
    }
}