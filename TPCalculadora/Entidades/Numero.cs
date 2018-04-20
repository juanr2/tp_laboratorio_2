using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class Numero
    {
        private double numero;

        public Numero(string numero) {
            SetNumero = numero;
        }

        //setea un numero validado
        private string SetNumero {
            set
            {
                numero = ValidarNumer(value);
            }
        }

        public static double operator +(Numero numero1, Numero numero2)
        {
            return numero1.numero + numero2.numero;
        }

        public static double operator -(Numero numero1, Numero numero2)
        {
            return numero1.numero - numero2.numero;
        }

        public static double operator *(Numero numero1, Numero numero2)
        {
            return numero1.numero * numero2.numero;
        }

        public static double operator /(Numero numero1, Numero numero2)
        {
            if (numero2.numero == 0)
            {
                throw new Exception("ERROR!");
            }

            return numero1.numero / numero2.numero;
        }

        //recibe un string, si es un numero lo devuelve como string y si es otro tipo de caracter devuelve un string que representa el numero cero
        private double ValidarNumer(string strNumero)
        {
            double result = 0;

            double.TryParse(strNumero, out result);

            return result;
        }
        //este método recibe un string que representa un numero en sistema decimal y lo convierte en un string que representa un numero en sistema binario
        public static string DecimalBinario(string numero)
        {
            int value=0;
            int.TryParse(numero, out value);
            if (value == 0) return null;
            var n = (int)(Math.Log(value) / Math.Log(2));
            var a = new int[n + 1];
            for (var i = n; i >= 0; i--)
            {
                n = (int)Math.Pow(2, i);
                if (n > value) continue;
                a[i] = 1;
                value -= n;
            }
            Array.Reverse(a);
            return string.Join("", a);

        }
        //este método recibe un string que representa un numero binario y lo convierte en un string que representa un numero en sistema decimal
        public static string BinarioDecimal(string binario)
        {
            var reversedBin = binario.Reverse().ToArray();
              int num = 0;
            string numstring = null;

         
            for (var power = 0; power < reversedBin.Count(); power++)
            {
                var currentBit = reversedBin[power];
                if (currentBit == '1')
                {
                    int currentNum = (int)Math.Pow(2, power);
                    num += currentNum;

                    numstring = num.ToString();
                }
            }

            return numstring;
          
        }
    }
}
