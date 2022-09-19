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
    public partial class Form13 : Form
    {
        int ID;
        string usser, rol = "";
        static private SqlConnection _conexion { get; set; }
        static private SqlCommand _comandosql { get; set; }
        static private SqlDataAdapter _adaptador { get; set; }
        static private SqlDataReader _lector { get; set; }

        public Form13(string _usser, int _ID)
        {
            usser = _usser;
            ID = _ID;
            InitializeComponent();
        }


        private void llenar_tabla_clientes()
        {
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string consulta = "SELECT Nombre, CURP, Email, ID FROM CLIENTES_BLOQUEADOS;";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, _conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void llenar_tabla_empleados()
        {
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string consulta = "SELECT Nombre, CURP, Usuario, ID FROM EMPLEADOS_BLOQUEADOS";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, _conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
               }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
                _conexion = conectar.conectar();
                string consulta = " DELETE FROM BLOQUEADOS_C where ID_USUARIO_CLIENTE=" + dataGridView1.SelectedCells[3].Value.ToString();
                conectar.executeQuery1(consulta, _conexion, _comandosql, _adaptador);
                llenar_tabla_clientes();
                MessageBox.Show("Se ha desbloqueado el cliente.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception)
            {
                return;
            }
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string consulta = " DELETE FROM BLOQUEADOS_E where ID_USUARIO_EMPLEADO=" + dataGridView2.SelectedCells[3].Value.ToString();
            conectar.executeQuery1(consulta, _conexion, _comandosql, _adaptador);
            llenar_tabla_empleados();
            MessageBox.Show("Se ha desbloqueado el empleado.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void Form13_Load(object sender, EventArgs e)
        {
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string query = String.Format("SELECT Rol FROM Rol WHERE Id_Empleado= " + ID);
            _comandosql = new SqlCommand(query, _conexion);
            _conexion.Open();

            _lector = _comandosql.ExecuteReader();

            while (_lector.Read())
            {
                rol = Convert.ToString(_lector["Rol"]);
            }
            _comandosql.Dispose();
            _conexion.Close();
            if (rol != "Administrador")
            {
                dataGridView2.Enabled = false;
                label2.Text = "";
                button3.Text = "";
                button3.Enabled = false;

            }
            else
            {
                llenar_tabla_empleados();
            }
            llenar_tabla_clientes ();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
