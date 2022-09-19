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
    public partial class Form20 : Form
    {
        int ID, ANO, MES;
        public Form20(int id, int año, int mes)
        {
            ID = id;
            ANO = año;
            MES = mes;
            InitializeComponent();
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DATA_HISTORIAL_RECIBOS.RECIBO' Puede moverla o quitarla según sea necesario.
            this.RECIBOTableAdapter.Fill(this.DATA_HISTORIAL_RECIBOS.RECIBO,ID,ANO,MES);

            this.reportViewer1.RefreshReport();
        }
    }
}
