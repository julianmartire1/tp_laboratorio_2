using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string _mensajeBase;

        public DniInvalidoException()
            : base()
        {

        }

        public DniInvalidoException(Exception e)
            : this(null, e)
        {

        }

        public DniInvalidoException(string message)
            : this(message, null)
        {

        }

        public DniInvalidoException(string message, Exception e)
            : base(e.InnerException.ToString())
        {
            this._mensajeBase = message;
        }
    }
}
