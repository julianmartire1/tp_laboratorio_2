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
        /// Sobrcarga del Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is PersonaGimnasio);
        }
        /// <summary>
        /// Muestra los datos de PersonaGimnasio
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb;
            sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("ID: " + this._identificador);

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecargas

        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1._identificador == pg2._identificador))
                return true;
            else
                return false;
        }

        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
