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
            return numero1.numero / numero2.numero;
        }

        private double ValidarNumer(string strNumero)
        {
            double result = 0;

            double.TryParse(strNumero, out result);

            return result;
        }

        public static string DecimalBinario(string numero)
        {
            int value=0;
            Int32.TryParse(numero, out value);
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

        public static string BinarioDecimal(string binario)
        {
            var reversedBin = binario.Reverse().ToArray();
              string num = null;

         
            for (var power = 0; power < reversedBin.Count(); power++)
            {
                var currentBit = reversedBin[power];
                if (currentBit == '1')
                {
                    string currentNum = Math.Pow(2, power).ToString();
                    num += currentNum;
                }
            }

            return num;
          
        }
    }
}
