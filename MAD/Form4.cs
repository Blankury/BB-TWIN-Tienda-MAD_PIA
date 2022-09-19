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
using MAD.DBConnection;
using MAD.Gestion_De_Datos;

namespace MAD
{
    public partial class Form4 : Form
    {
        int ID, año, mes;
        string email;

        public Form4(string t_email, int t_ID)
        {
            ID = t_ID;
            email = t_email;
            InitializeComponent();
        }

        static private SqlConnection _conexion { get; set; }
        static private SqlCommand _comandosql { get; set; }
        static private SqlDataAdapter _adaptador { get; set; }
        static private SqlDataReader _lector { get; set; }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            label4.Text = email;
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
        private void button2_Click(object sender, EventArgs e)
        {
            año = Int32.Parse(comboBox1.SelectedItem.ToString());
            mes = comboBox2.SelectedIndex + 1;
            Thread th = new Thread(NewForm5);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void editarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(NewForm1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void cerrarSesiónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(NewForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Thread th = new Thread(NewForm3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
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

        private void verCarritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(NewForm4);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }



        private void NewForm1()
        {
            Application.Run(new Form3(email, ID));
        }
        private void NewForm2()
        {
            Application.Run(new Form2());
        }
        private void NewForm3()
        {
            try
            {
                string temp = dataGridView1.SelectedCells[0].Value.ToString();
                int t_cod = Int32.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                Application.Run(new Form5(t_cod, email, ID));
            }
            catch (Exception)
            {
                return;
            }
        }
        private void NewForm4()
        {
            Application.Run(new Form6(email, ID));
        }

       
        private void NewForm5()
        {
            Application.Run(new Form20(ID, año, mes));
        }
    }
}
