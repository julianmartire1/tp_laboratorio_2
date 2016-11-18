using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _nombreDelArhcivo;

        /// <summary>
        /// Constructor que recibe el NOMBRE DEL ARCHIVO del archivo.
        /// </summary>
        /// <param name="archivo"></param>
        public Texto(string archivo)
        {
            this._nombreDelArhcivo = archivo;
        }

        /// <summary>
        /// Si no falla, guarda los datos que se pasa por parametro en un archivo de texto.
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(this._nombreDelArhcivo, true);
                sw.WriteLine(datos);

                sw.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Si no falla, lee todos los datos del Arhivo.
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            try
            {
                StreamReader sr = new StreamReader(this._nombreDelArhcivo);

                datos = new List<string>();

                while (!sr.EndOfStream)
                {
                    datos.Add(sr.ReadLine());
                }

                sr.Close();

                return true;
            }
            catch (Exception)
            {
                datos = default(List<string>);
                return false;
            }
        }
    }
}
