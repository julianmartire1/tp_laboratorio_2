using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Instructor : PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        #region Constructores

        static Instructor()
        {
            _random = new Random();
        }
        /// <summary>
        /// Creo el constructor por defento para que pueda serializar.
        /// </summary>
        public Instructor()
        {

        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClase();

        }

        #endregion

        #region Metodos
        /// <summary>
        /// Asigna dos clases aleatorias al Instructor
        /// </summary>
        private void _randomClase()
        {
            int random_1 = _random.Next(0, 3);
            int random_2 = _random.Next(0, 3);

            this._clasesDelDia.Enqueue((Gimnasio.EClases)random_1);
            this._clasesDelDia.Enqueue((Gimnasio.EClases)random_2);
        }
        /// <summary>
        /// Muestra los datos del Instructor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }
        /// <summary>
        /// Retorna la cadena "CLASES DEL DÍA " junto al nombre de la clases que da el Instructor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--Clases del dia--");
            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// Sobrecargo el ToString para que muestro los datos del Instructor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Verifica si el Instructor esta dando la Clase.
        /// </summary>
        /// <param name="instructor"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Instructor instructor, Gimnasio.EClases clase)
        {
            foreach (Gimnasio.EClases item in instructor._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Verifica si el Instructor NO esta dando la Clase.
        /// </summary>
        /// <param name="instructor"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Instructor instructor, Gimnasio.EClases clase)
        {
            return !(instructor == clase);
        }

        #endregion
    }
}
