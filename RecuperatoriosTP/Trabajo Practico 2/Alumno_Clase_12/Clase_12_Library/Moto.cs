using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Moto : Vehiculo
    {
        #region Constructor

        public Moto(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        {
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Las motos tienen 2 ruedas
        /// </summary>        
        public override short CantidadRuedas
        {
            get
            {
                return 2;
            }
            set
            {

            }
        }
        #endregion

        #region Metodo
        /// <summary>
        /// Muestra los datos de la Moto
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : " + this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
