using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAD
{
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DATA_SUCURSALES.SUCURSALES_DISPONIBLES' Puede moverla o quitarla según sea necesario.
            this.SUCURSALES_DISPONIBLESTableAdapter.Fill(this.DATA_SUCURSALES.SUCURSALES_DISPONIBLES);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
