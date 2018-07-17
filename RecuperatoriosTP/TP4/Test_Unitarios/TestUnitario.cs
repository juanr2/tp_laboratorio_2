using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test_Unitarios
{
    [TestClass]
    public class TestUnitario
    {   
        //Prueba que la lista de correo haya sido inicializada.
        [TestMethod]
        public void Prueba_De_Lista_Inicicalizada()
        {   
            //Arrange
            Correo correo = new Correo();

            //Assert
            Assert.IsTrue(correo.Paquetes != null);
        }

        //El método espera una excepción de tipo TrackingIdRepetidoException que se lanza cuando se ingresan dos paquetes con igual trackingID.
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void Prueba_Paquetes_Con_Igual_Tid()
        {
            //Arrange.
            Correo correo = new Correo();

            Paquete paquete = new Paquete("dir", "id");
            Paquete paquete2 = new Paquete("dir2", "id");

            //Act.
            correo += paquete;
            correo += paquete2;

            //Assert.
            Assert.AreNotEqual(paquete.TrackingID, paquete2.TrackingID);
        }
    }
}
