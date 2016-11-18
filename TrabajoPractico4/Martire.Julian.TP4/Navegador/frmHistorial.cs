using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Archivos;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Texto arch = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

            List<string> historico;

            if (arch.leer(out historico))
                lstHistorial.DataSource = historico;
            else
                MessageBox.Show("No se puede leer historial.", "ERROR!!!");
        }
    }
}
