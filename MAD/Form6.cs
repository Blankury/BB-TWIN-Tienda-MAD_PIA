using MAD.DBConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAD
{
    public partial class Form6 : Form
    {
        int ID;
        double total = 0, t_productos_c_descuento = 0, total_c_desc = 0;
        string email;
        static private SqlConnection _conexion { get; set; }
        static private SqlCommand _comandosql { get; set; }
        static private SqlDataAdapter _adaptador { get; set; }
        static private SqlDataReader _lector { get; set; }

        public Form6(string t_email, int t_ID)
        {
            ID = t_ID;
            email = t_email;
            InitializeComponent();
        }
        private void obtenertotal()
        {
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string query = String.Format("SELECT Cantidad, Precio, Descuento FROM PRODUCTOS_CARRITO WHERE Canasta= " + ID + "");
            _comandosql = new SqlCommand(query, _conexion);
            _conexion.Open();
            _lector = _comandosql.ExecuteReader();

            while (_lector.Read())
            {
                if (Convert.ToDouble(_lector["Descuento"]) != 0)
                {
                    t_productos_c_descuento = Convert.ToInt32(_lector["Cantidad"]) * (Convert.ToDouble(_lector["Precio"]) - ((Convert.ToInt32(_lector["Descuento"]) * Convert.ToDouble(_lector["Precio"])) / 100));
                }
                else
                {
                    t_productos_c_descuento = Convert.ToInt32(_lector["Cantidad"]) * (Convert.ToDouble(_lector["Precio"]));
                }
                total_c_desc = total_c_desc + t_productos_c_descuento;
                total = total + (Convert.ToInt32(_lector["Cantidad"]) * Convert.ToDouble(_lector["Precio"]));
               
                t_productos_c_descuento = 0;
            }
            label7.Text = "$" + total_c_desc.ToString();
            label9.Text = "$" + total.ToString();
            
            _comandosql.Dispose();
            _conexion.Close();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            obtenertotal();
            llenar_tabla();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void NewForm2()
        {
            Application.Run(new Form7(email, ID, total_c_desc));
        }
        private void NewForm3()
        {
            Application.Run(new Form17(ID));
        }

        private void llenar_tabla()
        {
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string consulta = "SELECT Codigo, Nombre, Cantidad, Descuento, Precio FROM  PRODUCTOS_CARRITO WHERE Canasta= " + ID + "";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, _conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int t_CODIGO = Int32.Parse(dataGridView1.SelectedCells[0].Value.ToString());

            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string consulta = " DELETE FROM LISTA_PRODUCTOS WHERE ID_CARRITO=" + ID + " and CODIGO=" + t_CODIGO + "";
            conectar.executeQuery1(consulta, _conexion, _comandosql, _adaptador);

            llenar_tabla();
            obtenertotal();
            MessageBox.Show("Se ha eliminado.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            total = 0; t_productos_c_descuento = 0; total_c_desc = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            Thread th = new Thread(NewForm3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(NewForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string consulta = " DELETE FROM LISTA_PRODUCTOS where ID_CARRITO=" + ID + "";
            conectar.executeQuery1(consulta, _conexion, _comandosql, _adaptador);

            llenar_tabla();
            obtenertotal();
            MessageBox.Show("Se ha eliminado.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            total = 0; t_productos_c_descuento = 0; total_c_desc = 0;
        }
    }
}
