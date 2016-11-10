using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        public bool guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo, false);

                sw.Write(datos);
                sw.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool leer(string archivo, out string datos)
        {
            try
            {
                StreamReader sr = new StreamReader(archivo);

                datos = sr.ReadToEnd();
                sr.Close();

                return true;
            }
            catch (Exception e)
            {
                datos = default(string);
                throw new ArchivosException(e);
            }
        }
    }
}
