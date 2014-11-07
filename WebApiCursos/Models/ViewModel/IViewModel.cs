using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCursos.Models.ViewModel
{
   public interface IViewModel<TModelo> where TModelo:class
   {

       TModelo ToModel();
       void FromModel(TModelo model);
       void UpdateModel(TModelo model);
       int[] GetPk();

   }
}
