using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        #region Propiedades

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }

        public int DNI
        {
            get { return this._dni; }
            set { this._dni = this.ValidarDNI(this._nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }

        public string StringToDNI
        {
            set { this._dni = this.ValidarDNI(this._nacionalidad, value); }
        }

        #endregion

        #region Enum ENacionalidad

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Creo el constructor por defento para que pueda serializar.
        /// </summary>
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }        

        #endregion

        #region Metodos

        
        /// <summary>
        /// Valida el dni teniendo en cuenta la nacionalidad y que sea, si es Argentino, mayor a 0 y menor a 90.000.000
        /// </summary>
        /// <param name="nacionalidad"></param> nacionalidad para poder validar dni
        /// <param name="dato"></param> dni a validar(int)
        /// <returns></returns>
        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {

            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato > 0 && dato < 90000000)
                    return dato;
                else
                    throw new DniInvalidoException("Nacionalidad no se condice con el numero de DNI");
            }
            else
            {
                if (dato > 90000000 && nacionalidad == ENacionalidad.Extranjero)
                    return dato;
                throw new NacionalidadInvalidaException("Nacionalidad Invalida");

            }
        }
        /// <summary>
        /// Valida el dni teniendo en cuenta la nacionalidad y que sea, si es Argentino, mayor a 0 y menor a 90.000.000
        /// </summary>
        /// <param name="nacionalidad"></param> nacionalidad para poder validar dni
        /// <param name="dato"></param> dni a validar(string)
        /// <returns></returns>
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDNI(nacionalidad, int.Parse(dato));
        }
        /// <summary>
        /// Validará que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se cargará.
        /// </summary>
        /// <param name="dato"></param> Nombre y Apellido a validar
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (char.IsDigit(dato[i]))
                    throw new Exception("Nombre Invalido");
            }

            return dato;
        }
        /// <summary>
        /// Sobrecarga del ToString para que muestro los datos de la persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.Nombre + " " + this.Apellido);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return sb.ToString();
        }

        #endregion

    }
}