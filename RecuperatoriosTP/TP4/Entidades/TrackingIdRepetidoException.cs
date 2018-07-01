using System;

namespace Entidades
{
    public class TrackingIdRepetidoException: Exception
    {
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {
            
        }

        public TrackingIdRepetidoException(string mensaje, Exception inner)
            : base(mensaje, inner)
        {
            
        }
    }
}
