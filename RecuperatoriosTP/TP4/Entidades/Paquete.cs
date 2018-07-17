using System;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {       
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public delegate void DelegadoError(object sender, Exception ex);
        //Evento para informar el cambio de estado
        public event DelegadoEstado InformarEstado;
        //Evento para informar cualquier error producido en la base de datos, por lo general errores de conexión a la misma.
        public event DelegadoError InformarError;

        public string DireccionEntrega
        {
            get { return direccionEntrega; }
            set { direccionEntrega = value; }            
        }

        public EEstado Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string TrackingID
        {
            get { return trackingID; }
            set { trackingID = value; }
        }

        public Paquete(string dirEntrega, string tId)
        {
            direccionEntrega = dirEntrega;
            trackingID = tId;
            estado = EEstado.Ingresado;            
        }

        public void MockCicloDeVida()
        {
            int i = 0;

            while (++i < 3)
            {
                Thread.Sleep(1000 * 10);
                Estado = i == 1 ? EEstado.EnViaje : EEstado.Entregado;

                if (InformarEstado != null)
                {
                    InformarEstado(this, null);
                }
            }

            try
            {
                PaqueteDAO.Insertar(this);                       
            }
            catch (Exception ex)
            {
                if (InformarError != null)
                {
                    InformarError(this, ex);
                }                  
            }            
        }     

        // Sobrecarga el operador != para paquetes con distinto trackingId
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !string.Equals(p1.trackingID, p2.trackingID);
        }

        // Sobrecarga el operador == para paquetes con igual trackingId
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return string.Equals(p1.trackingID, p2.trackingID);
        }       
        
        
        public string MostrarDatos(IMostrar<Paquete> data)
        {
            return string.Format("{0} para {1}", ((Paquete)data).trackingID, ((Paquete)data).direccionEntrega);
        }           

        #region Override

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        protected bool Equals(Paquete other)
        {
            return  string.Equals(trackingID, other.trackingID);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Paquete)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (direccionEntrega != null ? direccionEntrega.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)estado;
                hashCode = (hashCode * 397) ^ (trackingID != null ? trackingID.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion


      
    }
}
