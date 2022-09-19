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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetRecibo.RECIBO' Puede moverla o quitarla según sea necesario.
            int id = 2;
            this.RECIBOTableAdapter.Fill(this.DataSetRecibo.RECIBO,id);
            // TODO: esta línea de código carga datos en la tabla 'DataSetRecibo.PRODUCTOS_CARRITO1' Puede moverla o quitarla según sea necesario.
          

            this.PRODUCTOS_CARRITO1TableAdapter.Fill(this.DataSetRecibo.PRODUCTOS_CARRITO1,id);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
