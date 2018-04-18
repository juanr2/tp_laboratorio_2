using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {


        private static string ValidarOperador(string operador)
        {
            if(operador != "+ "&& operador != "-" && operador != "/" && operador != "*")
            {

                return "+";
            }
            else
            {
                return operador;

            }


        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double result = 0;

            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "+":

                    result = num1 + num2;
                
                    break;

                case "-":

                    result = num1 - num2;

                    break;

                case "*":

                    result = num1 * num2;

                    break;

                case "/":

                    result = num1 / num2;

                    break;


                 
            }
            return result;
        }
    }
}
