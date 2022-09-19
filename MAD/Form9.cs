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
using System.Data.OleDb;
using MAD.Gestion_De_Datos;

namespace MAD
{
    public partial class Form9 : Form
    {

        int ID;
        string usser;
        static private SqlConnection _conexion { get; set; }
        static private SqlCommand _comandosql { get; set; }
        static private SqlDataAdapter _adaptador { get; set; }
        static private SqlDataReader _lectorasies { get; set; }

        public Form9(string _usser, int _ID)
        {
            usser = _usser;
            ID = _ID;
            InitializeComponent();
        }
        
       
        private void llenar_tabla()
        {
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string consulta = "SELECT Sucursal, Numero, Direccion, Encargado, ID_Empleado_Encargado, Agragada FROM SUCURSALES_DISPONIBLES;";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, _conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || richTextBox1.Text == "")
                {
                    MessageBox.Show("Llena todos los campos.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (comboBox1.SelectedIndex == 0)
                {
                    MessageBox.Show("Selecciona un encargado.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
                _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
                string query = String.Format("EXEC SP_SUCURSAL " + textBox1.Text + ", '" + textBox2.Text + "', '" + richTextBox1.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', " + comboBox1.SelectedIndex + "");
                conectar.executeQuery1(query, _conexion, _comandosql, _adaptador);
                llenar_tabla();
            }
            catch (Exception)
            {
                MessageBox.Show("Ya existe una sucursal con el número: " + textBox1.Text + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToLongDateString();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            llenar_tabla();
            comboBox1.SelectedIndex = 0;
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar();
            string query = String.Format("SELECT Nombre from Empleados");
            conectar.executecmb(query, _conexion, _comandosql, _lectorasies, comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(NewForm3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void NewForm3()
        {
            Application.Run(new Form19());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
                _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
                string consulta = " DELETE FROM SUCURSAL where NUMERO=" + textBox1.Text + "";
                conectar.executeQuery1(consulta, _conexion, _comandosql, _adaptador);
                MessageBox.Show("Se ha eliminado.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                llenar_tabla();
            }
            catch(Exception)
            {
                MessageBox.Show("No se puede eliminar la sucursal porque hay pedidos pendientes en ella.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedCells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedCells[2].Value.ToString();

            int indice;
            string temp1 = dataGridView1.SelectedCells[4].Value.ToString();
            if (temp1 == "")
            {
                comboBox1.SelectedIndex = 0;
                return;
            }
            indice = Int16.Parse(temp1);
            comboBox1.SelectedIndex = indice;

            label7.Text = dataGridView1.SelectedCells[3].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ofdInsertar.ShowDialog();
            string flnm = ofdInsertar.FileName;
            datosCSV(flnm);
        }

        private void datosCSV(string flnm)
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(flnm);

            if (lines.Length > 0)
            {
                string firstline = lines[0];
                string[] title = firstline.Split(',');
                foreach (string cTitle in title)
                {
                    dt.Columns.Add(new DataColumn(cTitle));
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] valores = lines[i].Split(',');
                    rep(valores, lines);
                }
                MessageBox.Show("Sucursales cargadas.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void rep (string[] valores, string[] lines)
        {

            try
            {
                ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
                _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
                string query = String.Format("INSERT INTO SUCURSAL (NUMERO, NOMBRE,DIRECCION,FECHA_ALTA, ID_Empleado_ENCARGADO)"
                  + "VALUES ({0}, '{1}', '{2}', '{3}', {4})", valores[0], valores[1], valores[2], valores[3], 3);
                conectar.executeQuery1(query, _conexion, _comandosql, _adaptador);
                llenar_tabla();
              }
            catch (Exception)
            {

                MessageBox.Show("Error en la lectura.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //MODIFICAR
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string consulta = String.Format("Update SUCURSAL set NOMBRE= '" + textBox2.Text + "', DIRECCION='" + richTextBox1.Text + "', FECHA_ALTA='" + DateTime.Now.ToString("yyyy-MM-dd")  + "', ID_EMPLEADO_Encargado=" + comboBox1.SelectedIndex + " Where NUMERO =" + textBox1.Text);
            conectar.executeQuery1(consulta, _conexion, _comandosql, _adaptador);
            MessageBox.Show("Se modificó con éxito.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            llenar_tabla();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                errorProvider1.SetError(label8, "Por favor, escriba únicamente números.");
                label8.Text = "Por favor, escriba únicamente números.";
            }
            else
            {
                errorProvider1.SetError(label8, "");
                label8.Text = "";
            }
        }
    }
}
