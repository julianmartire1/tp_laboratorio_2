using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {

        public bool guardar(string archivo, T datos)
        {
            XmlSerializer serializador;
            XmlTextWriter escritor;

            try
            {
                serializador = new XmlSerializer(typeof(T));
                escritor = new XmlTextWriter(archivo, Encoding.UTF8);

                serializador.Serialize(escritor, datos);
                escritor.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

        }

        public bool leer(string archivo, out T datos)
        {
            XmlSerializer serializador;
            XmlTextReader lector;

            try
            {
                serializador = new XmlSerializer(typeof(T));
                lector = new XmlTextReader(archivo);

                datos = (T)serializador.Deserialize(lector);
                lector.Close();

                return true;
            }
            catch (Exception e)
            {
                datos = default(T);
                throw new ArchivosException(e);
            }
        }

    }
}
