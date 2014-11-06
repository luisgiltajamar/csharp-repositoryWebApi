using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCursos.Repositorio
{
    interface IRepositorio<TEntidad>
    {
        int Add(TEntidad modelo);
        int Borrar(TEntidad modelo);
        int Borrar(Expression<Func<TEntidad, bool>> lam);
        int Actualizar(TEntidad modelo);
        List<TEntidad> Get();
        List<TEntidad> Get(Expression<Func<TEntidad, bool>> lam);
        TEntidad Get(int pk);


    }
}
