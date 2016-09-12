using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoPractico1
{
    public partial class Form1 : Form
    {
        Numero n1, n2;
        Calculadora operaracion=new Calculadora();
        double res;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            operar();
        }

        public void limpiar()
        {
            res = 0;
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            lblResultado.Text = res.ToString();
        }

        public void operar()
        {
            res = 0;
            n1 = new Numero(txtNumero1.Text);
            n2 = new Numero(txtNumero2.Text);
            res = operaracion.operar(n1, n2, cmbOperacion.Text);
            lblResultado.Text = res.ToString();
        }
    }
}
