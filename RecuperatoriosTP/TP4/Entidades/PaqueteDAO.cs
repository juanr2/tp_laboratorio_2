using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlConnection _conexion;
        private static SqlCommand _comando;
        #endregion

        #region Constructores
        static PaqueteDAO()
        {
            //Se genera una nueva conexión tomando el connection string desde app.config
            _conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["correo-sp-2017"].ConnectionString);
            _comando = new SqlCommand();         
            _comando.CommandType = System.Data.CommandType.Text;         
            _comando.Connection = _conexion;
        }
        #endregion

        #region Métodos        

        #region Insertar Persona
        public static void  Insertar(Paquete paquete)
        {
            string sql = string.Format("INSERT INTO Paquetes(direccionEntrega, trackingID, alumno) VALUES('{0}', '{1}', '{2}')", paquete.DireccionEntrega, paquete.TrackingID, "Roa Juan");
            EjecutarNonQuery(sql);
        }

        #endregion    

        private static void EjecutarNonQuery(string sql)
        {            
            try
            {                
                _comando.CommandText = sql;                
                _conexion.Open();                
                _comando.ExecuteNonQuery();                
            }           
            finally
            {
                //si la operación finaliza correctamente, tenemos que cerrar la conexión.
                if (_conexion.State == ConnectionState.Open)
                    _conexion.Close();
            }
            
        }
        #endregion
    }
}