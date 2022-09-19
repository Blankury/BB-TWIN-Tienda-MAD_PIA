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
    public partial class Form17 : Form
    {
        int ID;
        public Form17(int _ID)
        {
            ID = _ID;
            InitializeComponent();
        }

        private void Form17_Load(object sender, EventArgs e)
        {

           
            // TODO: esta línea de código carga datos en la tabla 'DATA_CARRITO.PRODUCTOS_CARRITO' Puede moverla o quitarla según sea necesario.
            this.PRODUCTOS_CARRITOTableAdapter.Fill(this.DATA_CARRITO.PRODUCTOS_CARRITO,ID);

            this.reportViewer1.RefreshReport();
         
        }
    }
}
