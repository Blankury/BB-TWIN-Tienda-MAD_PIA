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
    public partial class Form8 : Form
    {
        int ID;
        string usser;
        static private SqlConnection _conexion { get; set; }
        static private SqlCommand _comandosql { get; set; }
        static private SqlDataReader _lector { get; set; }
        static private SqlDataAdapter _adaptador { get; set; }

        public Form8(string t_usser, int t_ID)
        {
            ID = t_ID;
            usser = t_usser;
            InitializeComponent();
        }
        private void llenar_tabla(string categ)
        {
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string consulta = "SELECT Codigo, Producto FROM PRODUCTOS_DISPONIBLES WHERE Categoría='" + categ + "'";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, _conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label10.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToString("HH:mm:ss");
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString("HH:mm:ss");
            button2.Enabled = false;
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string query = String.Format("INSERT INTO Horario(DIAS, ENTRADA, SALIDA, Id_Empleado)"
                + "VALUES ('{0}', '{1}', '{2}', {3})", DateTime.Now.ToString("yyyy - MM - dd"), label8.Text, label7.Text, ID);

            conectar.executeQuery1(query, _conexion, _comandosql, _adaptador);
            label13.Text = "Ya ha guardado su hora de entrada y salida hoy.";
        }

        private void generarReporteDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(NewForm1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(NewForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void editarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(NewForm3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            label4.Text = usser;
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string query = "SELECT Nombre, Apellido, RFC, CURP FROM Empleados WHERE Id_Empleado='" +ID + "'";
            _comandosql = new SqlCommand(query, _conexion);
            _conexion.Open();
            _lector = _comandosql.ExecuteReader();
            while (_lector.Read())
            {
                label6.Text = "NOMBRE: " + Convert.ToString(_lector["Nombre"]) + " " + Convert.ToString(_lector["Apellido"]);
                label5.Text = "CURP: " + Convert.ToString(_lector["CURP"]);
                label12.Text = "RFC: " + Convert.ToString(_lector["RFC"]);

            }
            _comandosql.Dispose();
            _conexion.Close();
            
            conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string query1 = "SELECT DIAS, ENTRADA, SALIDA, Id_Empleado FROM Horario WHERE Id_Empleado='" + ID + "'";
            _comandosql = new SqlCommand(query1, _conexion);
            _conexion.Open();

            _lector = _comandosql.ExecuteReader();
            string dia = "";
            while (_lector.Read())
            {
                dia = Convert.ToString(_lector["DIAS"]);
                if (dia == DateTime.Now.ToString("yyyy - MM - dd"))
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    label13.Text = "Ya ha guardado su hora de entrada y salida hoy.";
                    label8.Text = Convert.ToString(_lector["ENTRADA"]);
                    label7.Text = Convert.ToString(_lector["SALIDA"]);
                    return;
                }
            }
            _comandosql.Dispose();
            _conexion.Close();

            if (dia == DateTime.Now.ToString("yyyy - MM - dd"))
            {
                button1.Enabled = false;
                button2.Enabled = false;
                label13.Text = "Ya ha guardado su hora de entrada y salida hoy.";
                return;
            }
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string cat1 = "Despensa";
            llenar_tabla(cat1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string cat1 = "Bebidas";
            llenar_tabla(cat1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string cat1 = "Mascotas";
            llenar_tabla(cat1);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string cat1 = "Bebes";
            llenar_tabla(cat1);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string cat1 = "CuidadoPersonal";
            llenar_tabla(cat1);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string cat1 = "Limpieza";
            llenar_tabla(cat1);
        }

        private void desbloquearCuentaDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(NewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void NewForm()
        {
            Application.Run(new Form13(usser, ID));
        }
        private void NewForm1()
        {
            Application.Run(new Form10(usser, ID));
        }
        private void NewForm2()
        {
            Application.Run(new Form9(usser, ID));
        }
        private void NewForm3()
        {
            Application.Run(new Form11(usser, ID));
        }
        private void NewForm4()
        {

            Application.Run(new Form2());
        }
        private void NewForm5()
        {

            Application.Run(new Form21(ID));
        }
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(NewForm4);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void historialDeHorasTrabajadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(NewForm5);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
