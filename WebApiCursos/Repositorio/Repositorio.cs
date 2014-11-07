using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApiCursos.Models;
using WebApiCursos.Models.ViewModel;


namespace WebApiCursos.Repositorio
{
    public class Repositorio<TViewModel,TEntidad> :
        IRepositorio<TViewModel, TEntidad>
        where TViewModel : class,IViewModel<TEntidad>, new()
        where TEntidad : class
       
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

        public virtual TViewModel Add(TViewModel modelo)
        {
            var m = modelo.ToBaseDatos();

            DbSet.Add(m);
           
            try
            {
               Context.SaveChanges();
                modelo.FromBaseDatos(m);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

            return modelo;
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

        public virtual int Actualizar(TViewModel modelo)
        {
            var datos = GetModelDesdeViewModel(modelo);
          
            modelo.UpdateBaseDatos(datos);


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

        public TEntidad GetModelDesdeViewModel(TViewModel modelo)
        {
            var datos = DbSet.Find(modelo.GetPk());

            return datos;
        }

        public virtual List<TViewModel> Get()
        {
            var datos = DbSet;

            List<TViewModel> list=new List<TViewModel>();

            foreach (var entidad in datos)
            {
                var v=new TViewModel();
                v.FromBaseDatos(entidad);
                list.Add(v);
            }


            return list;
        }

        public virtual List<TViewModel> Get(Expression<Func<TEntidad, bool>> lam)
        {
            var datos = DbSet.Where(lam);

            List<TViewModel> list = new List<TViewModel>();

            foreach (var entidad in datos)
            {
                var v = new TViewModel();
                v.FromBaseDatos(entidad);
                list.Add(v);
            }


            return list;
        }

        public virtual TViewModel Get(int pk)
        {
            var v = new TViewModel();
           var entidad= DbSet.Find(pk);
            v.FromBaseDatos(entidad);
            return v;
        }
    }
}