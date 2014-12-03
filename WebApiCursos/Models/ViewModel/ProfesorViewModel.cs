using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCursos.Models.ViewModel
{
    public class ProfesorViewModel:IViewModel<Profesor>
    {
        public int idProfesor { get; set; }
        public string nombre { get; set; }
        public Nullable<int> experiencia { get; set; }
        public Profesor ToBaseDatos()
        {
            var model = new Profesor()
            {
                idProfesor = idProfesor,
                nombre = nombre,
                experiencia = experiencia

            };
            return model;
        }

        public void FromBaseDatos(Profesor model)
        {
            idProfesor = model.idProfesor;
            nombre = model.nombre;
            experiencia = model.experiencia;
        }

        public void UpdateBaseDatos(Profesor model)
        {
            model.idProfesor = idProfesor;
            model.nombre = nombre;
            model.experiencia = experiencia;
        }

        public int[] GetPk()
        {
            return new[] {idProfesor};
        }
    }
}