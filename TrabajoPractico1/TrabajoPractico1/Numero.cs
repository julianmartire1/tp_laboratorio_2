using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Numero
    {
        private double _numero;

        #region Constructores
        /// <summary>
        /// Inicia el atributo _numero en cero en 0. 
        /// </summary>
        public Numero()
        {
            this._numero = 0;
        }
        /// <summary>
        /// Recibe un double y carga en número. 
        /// </summary>
        /// <param name="numero"></param> Numero a cargar.
        public Numero(double numero)
        {
            this._numero = numero;
        }
        /// <summary>
        /// Recibe un String que valida y carga en número. 
        /// </summary>
        /// <param name="numero"></param> Numero a cargar.
        public Numero(string numero)
        {
            setNumero(numero);
            //this._numero = double.Parse(numero);
        }
        #endregion

        #region Get numero
        public double getNumero()
        {
            return this._numero;
        }
        #endregion

        #region set y validar numero
        private void setNumero(string numero)
        {
            this._numero = validarNumero(numero);
        }
        /// <summary>
        ///  Validará que se trate de un double válido, caso contrario retornará 0. 
        /// </summary>
        /// <param name="numeroString"></param> Retorna numero valido tipo double, caso contrario rentorna 0.
        /// <returns></returns>
        private double validarNumero(string numeroString)
        {
            double numero;

            if (double.TryParse(numeroString, out numero))
                return numero;

            return 0;
        }
        #endregion

        #region Sobrecarga

        public static double operator +(Numero n1, Numero n2)
        {
            return n1._numero + n2._numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1._numero - n2._numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = 0;

            if (n2._numero != 0)
            {
                resultado = n1._numero / n2._numero;
            }

            return resultado;
        }
        #endregion


    }
}
