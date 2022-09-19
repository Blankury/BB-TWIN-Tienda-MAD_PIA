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
    public partial class Form21 : Form
    {
        int ID;
        public Form21(int _ID)
        {
            ID = _ID;
            InitializeComponent();
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'Data_horas.HORAS_TRABAJADAS' Puede moverla o quitarla según sea necesario.
            this.HORAS_TRABAJADASTableAdapter.Fill(this.Data_horas.HORAS_TRABAJADAS, ID);

            this.reportViewer1.RefreshReport();
        }
    }
}
