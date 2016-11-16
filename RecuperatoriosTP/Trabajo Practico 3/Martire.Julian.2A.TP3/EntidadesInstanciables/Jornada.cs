using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        #region Propiedades

        //Creo las Propiedades para que Serialize.

        public List<Alumno> ListAlumnos 
        {
            get { return this._alumnos; } 
        }
        public Instructor ListInstructor 
        { 
            get { return this._instructor; }
        }
        public Gimnasio.EClases Clases 
        { 
            get { return this._clase; }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Creo el constructor por defento para que pueda serializar.
        /// </summary>
        public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los datos de la jornada en un archivo xml
        /// </summary>
        /// <param name="jornada"></param> Jornada a guardar
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            string pathTexto = "jornada.txt";

            Texto text = new Texto();

            text.guardar(pathTexto, jornada.ToString());

            return true;
        }
        /// <summary>
        /// Lee los datos de la jornada.
        /// </summary>
        /// <param name="jornada"></param> Jornada a leer
        /// <returns></returns>
        public static string Leer(Jornada jornada)
        {
            string pathTexto = "jornada.txt";
            string aux;

            Texto text = new Texto();
            text.leer(pathTexto, out aux);

            return aux;
        }
        /// <summary>
        /// Sobrecargo el ToString para mostrar los datos de la Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--- JORNADA ---");
            sb.AppendLine("Clase de : " + this._clase);
            sb.AppendLine("Instructor: " + this._instructor);
            sb.AppendLine("Alumnos:");

            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("<----------------------------------------------->");

            return sb.ToString();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Verifica si el Alumno esta en la Jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (j._alumnos.Contains(a))
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Verifica si el Alumno NO esta en la Jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agrega un Alumno a la Jornada si es que no esta repetido.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                    return j;
            }
            j._alumnos.Add(a);

            return j;
        }

        #endregion
    }
}
