using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca 
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

        EMarca _marca;
        string _codigoDeBarras;
        ConsoleColor _colorPrimarioEmpaque;

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
       protected abstract short CantidadCalorias { get; }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public abstract string Mostrar();
        //{
        //    returprn this;
       // }

         public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("CODIGO DE BARRAS: {0}\r", p._codigoDeBarras));
            sb.AppendLine(string.Format("MARCA          : {0}\r", p._marca));
            sb.AppendLine(string.Format("COLOR EMPAQUE  : {0}\r", p._colorPrimarioEmpaque));
            sb.AppendLine(string.Format("CALORIAS  : {0}\r", p.CantidadCalorias));            

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }

        public Producto(string codigoDeBarras,EMarca marca, ConsoleColor color)
        {

            _codigoDeBarras = codigoDeBarras;
            _marca = marca;
            _colorPrimarioEmpaque = color;
        }
    }
}
