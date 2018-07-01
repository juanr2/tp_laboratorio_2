using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;

namespace Presentacion
{
    public partial class FrmPpal : Form 
    {
        private Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }

        #region EventHandlers

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validamos los campos ingresados para evitar insertar valores vacios en la base de datos.
                ValidateFields();
                Paquete p = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                p.InformarEstado += paq_InformaEstados;
                p.InformarError += paq_InformaErrores;
                correo += p;

                //Limpiamos los campos para futuros ingresos
                CleanFields();                
                ActualizarEstados();
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);          
        }

      
        private void lstEstadoEntregado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void cmsListas_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        #endregion


        #region Methods

        private void MostrarInformacion<T>(IMostrar<T> elemento )
        {
           //Evaluamos si elemento es null para los casos que el usuario no haya seleccionada un item del listbox. 
          if (elemento == null) return;

          rtbMostrar.Text = elemento.MostrarDatos(elemento);
          rtbMostrar.Text.Guardar("salida.txt");
        }

        private void ValidateFields()
        {
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                throw new TrackingIdRepetidoException("Ingrese la dirección");
            }

            if (string.IsNullOrEmpty(mtxtTrackingID.Text))
            {
                throw new TrackingIdRepetidoException("Ingrese el tracking ID");
            }
        }

        private void CleanFields()
        {
            txtDireccion.Text = string.Empty;
            mtxtTrackingID.Text = string.Empty;
        }

        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (var paquete in correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                    break;
                    case EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                    break;
                    case EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete); 
                    break;
                }
            }
        }

        private void paq_InformaEstados(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstados);
                Invoke(d, new object[] {sender, e});
            }
            else
            {
                ActualizarEstados();
            }
        }


        ///Como no es posible capturar una excepción desde otro thread de manera convencional,
        ///capturamos el evento lanzado desde la case Paquete para los casos en los que
        ///se produzca una excepción de base de datos.        
        private void paq_InformaErrores(object sender, Exception e)
        {
            if (InvokeRequired)
            {
                Paquete.DelegadoError d = new Paquete.DelegadoError(paq_InformaErrores);
                Invoke(d, new object[] { sender, e });
            }
            else
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion

     
    }
}
