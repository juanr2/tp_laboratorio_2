using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{

    public enum Conversor
    {
        Binario = 1,
        Decimal
    }

    public partial class LaCalculadora : Form
    {
        public Conversor CurrentConversor { get; set; }
        public LaCalculadora()
        {
            InitializeComponent();
            LoadCombo();
            SetBtnsConversor(Conversor.Decimal);
        }



        #region Methods

        private void SetBtnsConversor(Conversor conversor)
        {
            CurrentConversor = conversor;
            btnConvertirABinario.Enabled = CurrentConversor == Conversor.Decimal;
            btnConvertirADecimal.Enabled = CurrentConversor == Conversor.Binario;
        }

       
        private void LoadCombo()
        {
           
        }

        private void Limpiar()
        {
            lblResultado.Text = string.Empty;
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            cmbOperador.SelectedIndex = -1;

        }

        private static double Operar(string numero1, string numero2, string operador)
        {
         

                Numero nro1 = new Numero(numero1);
                Numero nro2 = new Numero(numero2);


            return Calculadora.Operar(nro1, nro2, operador);
        }

        #endregion

        #region EventHandlers

        private void btnOperar_Click(object sender, EventArgs e)
        {
            try
            {
                SetBtnsConversor(CurrentConversor);
                lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString()).ToString();

                if (CurrentConversor == Conversor.Binario)
                {
                    lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message;
            }

        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

            SetBtnsConversor(Conversor.Binario);
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
        

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            SetBtnsConversor(Conversor.Decimal);
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }

        #endregion

      
    }
}
