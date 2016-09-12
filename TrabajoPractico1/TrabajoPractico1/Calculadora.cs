using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    public class Calculadora
    {
        double resultado;

        #region Metodos

        public double operar(Numero numero1, Numero numero2, string operador)
        {

            switch (validarOperador(operador))
            {
                case "+":
                    resultado = numero1 + numero2;
                    break;
                case "-":
                    resultado = numero1 - numero2;
                    break;
                case "*":
                    resultado = numero1 * numero2;
                    break;
                case "/":
                    resultado = numero1 / numero2;
                    break;
            }
            return resultado;
        }
        public string validarOperador(string operador)
        {
            if (operador != "+" && operador != "/" && operador != "*" && operador != "-")
                return "+";
            else return operador;

        }

        #endregion
    }
}
