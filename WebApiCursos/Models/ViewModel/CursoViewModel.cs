using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCursos.Models.ViewModel
{
    public class CursoViewModel:IViewModel<Curso>
    {
        public int idCurso { get; set; }
        public string nombre { get; set; }
        public Nullable<int> profesor { get; set; }
        public System.DateTime inicio { get; set; }
        public int duracion { get; set; }
        public String NombreProfesor { get; set; }

        public Curso ToModel()
        {
            var model = new Curso()
            {
                idCurso = idCurso,
                nombre = nombre,
                profesor = profesor,
                inicio = inicio,
                duracion = duracion

            };
            return model;
        }

        public void FromModel(Curso model)
        {
            idCurso = model.idCurso;
            nombre = model.nombre;
            profesor = model.profesor;
            inicio = model.inicio;
            duracion = model.duracion;
            try
            {
                NombreProfesor = model.Profesor1.nombre;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void UpdateModel(Curso model)
        {
            model.idCurso = idCurso;
            model.nombre = nombre;
            model.profesor = profesor;
            model.inicio = inicio;
            model.duracion = duracion;
        }

        public int[] GetPk()
        {
            return new[] {idCurso};
        }
    }
}