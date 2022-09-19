using MAD.DBConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MAD.DBConnection;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MAD
{
    public partial class Form5 : Form
    {
        int cod, ID;
        string email;
        static private SqlConnection _conexion { get; set; }
        static private SqlCommand _comandosql { get; set; }
        static private SqlDataAdapter _adaptador { get; set; }
        static private SqlDataReader _lector { get; set; }
        
        public Form5(int t_cod, string t_email, int t_ID)
        {
            cod = t_cod;
            email = t_email;
            ID = t_ID;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string query = String.Format("EXEC SP_LISTA_PRODUCTOS " +  cod + "," + numericUpDown1.Value.ToString() + "," + ID +"");
            conectar.executeQuery1(query, _conexion, _comandosql, _adaptador);
            MessageBox.Show("Se añadió al carrito.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


            this.Close();

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string query = "SELECT Codigo, Producto, Descuento, Precio, Detalles,Categoría FROM PRODUCTOS_DISPONIBLES WHERE Codigo='" + cod + "'";
            _comandosql = new SqlCommand(query, _conexion);
            _conexion.Open();

            _lector = _comandosql.ExecuteReader();

            while (_lector.Read())
            {
                label6.Text = Convert.ToString(_lector["Producto"]);
                label7.Text = Convert.ToString(_lector["Codigo"]);
                label8.Text = "$" + Convert.ToString(_lector["Precio"]);
                label9.Text = Convert.ToString(_lector["Descuento"]);
                label6.Text = Convert.ToString(_lector["Categoría"]);
                richTextBox1.Text = Convert.ToString(_lector["Detalles"]);

            }
            _comandosql.Dispose();
            _conexion.Close();
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                errorProvider1.SetError(label11, "Por favor, escriba únicamente números.");
                label11.Text = "Por favor, escriba únicamente números.";
            }
            else
            {
                errorProvider1.SetError(label11, "");
                label11.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
