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
    public sealed class Alumno : PersonaGimnasio
    {
        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #region Enum EEstadoCuenta

        public enum EEstadoCuenta
        {
            MesPrueba,Deudor,AlDia
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Creo el constructor por defento para que pueda serializar.
        /// </summary>
        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        

        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            sb.AppendLine("Estado de cuenta: " + this._estadoCuenta);

            return sb.ToString();
        }
        /// <summary>
        /// Retorna la cadena "TOMA CLASE DE " junto al nombre de la clase que toma el Alumno.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return ("Toma clase de: " + this._claseQueToma);
        }
        /// <summary>
        /// Sobrecargo el ToString para que muestre los datos del Alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Se fija si el alumno toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno alumno, Gimnasio.EClases clase)
        {
            if (alumno._claseQueToma == clase && alumno._estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Se fija si el alumno NO toma esa clase y su estado de cuenta ES Deudor.
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno alumno, Gimnasio.EClases clase)
        {
            return !(alumno == clase);
        }

        #endregion
    }
}
