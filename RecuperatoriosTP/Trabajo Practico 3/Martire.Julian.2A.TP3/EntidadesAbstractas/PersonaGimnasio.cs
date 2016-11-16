using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class PersonaGimnasio : Persona
    {
        private int _identificador;

        #region Constructores
        /// <summary>
        /// Creo el constructor por defento para que pueda serializar.
        /// </summary>
        public PersonaGimnasio()
        {

        }

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }

        #endregion

        #region Metodos
        
        /// <summary>
        /// Muestra los datos de PersonaGimnasio
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("ID: " + this._identificador);

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Sobrcarga del Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is PersonaGimnasio)
                return true;
            return false;
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Compara las personas del gimnasio si son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1._identificador == pg2._identificador))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Compara las personas del gimnasio si son distintas.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
