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
            int randomUno = _random.Next(0, 3); 
            int randomDos= _random.Next(0, 3);

            this._clasesDelDia.Enqueue((Gimnasio.EClases)randomUno);
            this._clasesDelDia.Enqueue((Gimnasio.EClases)randomDos);
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

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas

        public static bool operator ==(Instructor instructor, Gimnasio.EClases clase)
        {
            foreach (var item in instructor._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }

            return false;
        }

        public static bool operator !=(Instructor instructor, Gimnasio.EClases clase)
        {
            return !(instructor == clase);
        }

        #endregion
    }
}
