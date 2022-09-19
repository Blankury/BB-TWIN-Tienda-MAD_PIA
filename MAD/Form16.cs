using MAD.DBConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAD
{
    public partial class Form16 : Form
    {

        static private SqlConnection _conexion { get; set; }
        static private SqlCommand _comandosql { get; set; }
        static private SqlDataAdapter _adaptador { get; set; }

        bool eliminar;
        int ID;
        public Form16(int _ID)
        {
            ID = _ID;
            InitializeComponent();
        }
        public Form16(int _ID, bool _eliminar)
        {
            eliminar = _eliminar;
            ID = _ID;
            InitializeComponent();
        }
        private void Form16_Load(object sender, EventArgs e)
        {
           
            // TODO: esta línea de código carga datos en la tabla 'DATA_RECIBOS.PRODUCTOS_CARRITO' Puede moverla o quitarla según sea necesario.
            this.PRODUCTOS_CARRITOTableAdapter.Fill(this.DATA_RECIBOS.PRODUCTOS_CARRITO, ID);
            // TODO: esta línea de código carga datos en la tabla 'DATA_RECIBOS.RECIBO' Puede moverla o quitarla según sea necesario.
            this.RECIBOTableAdapter.Fill(this.DATA_RECIBOS.RECIBO, ID);

            this.reportViewer1.RefreshReport();

            if (eliminar)
            {
                ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
                _conexion = conectar.conectar();
                string consulta = " DELETE FROM LISTA_PRODUCTOS where ID_CARRITO=" + ID + "";
                conectar.executeQuery1(consulta, _conexion, _comandosql, _adaptador);
            }
        }
    }
}
