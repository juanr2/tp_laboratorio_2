﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{



    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Changuito
    {
        List<Producto> _productos;
        int _espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        private Changuito()
        {
            this._productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible) : this()
        {            
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concecionaria y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }

        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito c, ETipo tipo) //quitar static
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c._productos.Count, c._espacioDisponible);
            sb.AppendLine("\n");

            foreach (Producto v in c._productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:

                        if (v is Snacks)
                        {
                            sb.AppendLine(v.Mostrar());                            
                        }          
              
                        break;
                    case ETipo.Dulce:

                        if (v is Dulce)
                        {
                            sb.AppendLine(v.Mostrar());
                        }   
                       
                        break;
                    case ETipo.Leche:

                        if (v is Leche)
                        {
                            sb.AppendLine(v.Mostrar());
                        }   

                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }

        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            if (c._productos.Count >= c._espacioDisponible) return c;

            foreach (Producto v in c._productos)
            {
                if (v == p)
                    return c;
            }

            c._productos.Add(p);

            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            bool exists = false;

            foreach (Producto v in c._productos)
            {
                if (v == p)
                {
                    exists = true;
                    break;
                }
            }

            if (exists)
            {
                c._productos.Remove(p);
            }

            return c;
        }


        #endregion
    }
}
