using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;
using EntidadesAbstractas;
using Archivos;

namespace EntidadesInstanciables
{
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(PersonaGimnasio))]
    [XmlInclude(typeof(Persona))]
    [Serializable]
    public class Gimnasio
    {
        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;

        #region Propiedades


        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
        }
        public List<Jornada> Jornada
        {
            get { return this._jornada; }
        }

        public List<Instructor> Instructores
        {
            get { return this._instructores; }
        }

        public Jornada this[int i]
        {
            get { return this._jornada[i]; }
        }

        #endregion

        #region EClases

        public enum EClases
        {
            CrossFit, Natacion, Pilates, Yoga
        }

        #endregion

        #region Constructores

        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los datos del gimnasio que se pasa por parametro en xml.
        /// </summary>
        /// <param name="gimnasio"></param> gimnasio a guardar.
        /// <returns></returns>
        public static bool Guardar(Gimnasio gimnasio)
        {
            string pathXml = "gimnasio.xml";

            Xml<Gimnasio> xmlFile = new Xml<Gimnasio>();

            xmlFile.guardar(pathXml, gimnasio);

            return true;
        }
        /// <summary>
        /// Lee los datos del gimnasio.
        /// </summary>
        /// <returns></returns>
        public static Gimnasio Leer()
        {
            Gimnasio auxGimnasio = null;
            string archivo = "gimnasio.xml";

            Xml<Gimnasio> deserializador = new Xml<Gimnasio>();
            deserializador.leer(archivo, out auxGimnasio);

            return auxGimnasio;
        }
        /// <summary>
        /// Muestras los alumnos , la jornada y los instructores del gimnasio que se pasa por parametro.
        /// </summary>
        /// <param name="gim"></param> gimnasio que se va a mostrar los datos.
        /// <returns></returns>
        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < gim._jornada.Count; i++)
            {
                sb.AppendLine(gim._jornada[i].ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }

        #endregion

        #region Sobrecargas

        public static bool operator ==(Gimnasio gim, Alumno a)
        {
            foreach (Alumno item in gim._alumnos)
            {
                if (gim._alumnos.Contains(a))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Gimnasio gim, Alumno a)
        {
            return !(gim == a);
        }

        public static Instructor operator ==(Gimnasio gim, EClases clase)
        {
            foreach (Instructor item in gim._instructores)
            {
                if (item == clase)
                {
                    return item;
                }
            }

            throw new SinInstructorException();
        }

        public static Instructor operator !=(Gimnasio gim, EClases clase)
        {
            try
            {
                foreach (Instructor item in gim._instructores)
                {
                    if (item != clase)
                    {
                        return item;
                    }

                }
                throw new Exception("Todos los instructores estan en esa clase");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }



        }

        public static bool operator ==(Gimnasio gim, Instructor ins)
        {
            int i;
            for (i = 0; i < gim._instructores.Count; i++)
            {
                if (gim._instructores[i] == ins)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Gimnasio gim, Instructor i)
        {
            return !(gim == i);
        }

        public static Gimnasio operator +(Gimnasio gim, Alumno alu)
        {
            int i;
            for (i = 0; i < gim._alumnos.Count; i++)
            {
                if (gim._alumnos[i] == alu)
                    throw new AlumnoRepetidoException();
            }
            if (i == gim._alumnos.Count)
                gim._alumnos.Add(alu);

            return gim;
        }

        public static Gimnasio operator +(Gimnasio gim, EClases clase)
        {
            Jornada j = new Jornada(clase, (gim == clase));
            foreach (Alumno item in gim._alumnos)
            {
                if (item == clase)
                    j += item;
            }
            gim._jornada.Add(j);
            return gim;
        }

        public static Gimnasio operator +(Gimnasio gim, Instructor i)
        {
            try
            {
                if (gim != i)
                {
                    gim._instructores.Add(i);

                }
                else
                {
                    throw new Exception("Instructor repetido");
                }


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }
            return gim;



        }

        #endregion
    }
}
