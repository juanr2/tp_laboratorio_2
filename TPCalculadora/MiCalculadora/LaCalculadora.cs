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
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
            LoadCombo();
        }



        #region Methods

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

            if ((int.Parse(numero1) != 0) && (int.Parse(numero2) == 0) && (operador == "/"))
            {

                break;
                
               

            }

                Numero nro1 = new Numero(numero1);
                Numero nro2 = new Numero(numero2);

            
            

            return Calculadora.Operar(nro1, nro2, operador);
        }

        #endregion

        #region EventHandlers

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString()).ToString();
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


            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);


        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }

        #endregion
    }
}
