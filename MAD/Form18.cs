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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DATA_PRODUCTOS_CARGADOS.PRODUCTOS_DISPONIBLES' Puede moverla o quitarla según sea necesario.
            this.PRODUCTOS_DISPONIBLESTableAdapter.Fill(this.DATA_PRODUCTOS_CARGADOS.PRODUCTOS_DISPONIBLES);

            this.reportViewer1.RefreshReport();
        }
    }
}
