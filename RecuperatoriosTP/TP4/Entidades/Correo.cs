using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Entidades
{
    public class Correo: IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }

        }

        public Correo()
        {
            Paquetes = new List<Paquete>();
            mockPaquetes = new List<Thread>();
        }

        public void FinEntregas()
        {
            foreach (var mockPaquete in mockPaquetes)
            {
                mockPaquete.Abort();
            }
        }
     
        public static Correo operator +(Correo c, Paquete p)
        {            
            foreach (var paquete in c.paquetes)
            {
                if (p == paquete)
                {
                    throw new TrackingIdRepetidoException(string.Format("Ya existe un paquete con TrackingID : {0}", p.TrackingID));
                }
            }

            c.paquetes.Add(p);
            Thread t = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(t);
            t.Start();

            return c;
        }

        public string MostrarDatos(IMostrar<List<Paquete>> data)
        {
           StringBuilder sb = new StringBuilder();

            foreach (var paquete in ((Correo)data).Paquetes)
            {
                sb.AppendLine(paquete.MostrarDatos(paquete));
            } 

           return sb.ToString();
        }
    }
}
