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
            _conexion = new SqlConnection(@"Data Source = .\SQLEXPRESS;Initial Catalog = correo-sp-2017; User Id=J; Password = R; MultipleActiveResultSets=true;");
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
                //EL BLOQUE FINALLY SE EJECUTA SIEMPRE, INDEPENDIENTEMENTE QUE EXISTA O NO EXISTA ERROR.
                if (_conexion.State == ConnectionState.Open)
                    _conexion.Close();
            }
            
        }
        #endregion
    }
}