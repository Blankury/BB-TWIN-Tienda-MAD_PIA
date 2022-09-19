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
using MAD.Gestion_De_Datos;
using System.IO;
using CsvHelper;

namespace MAD
{
    public partial class Form10 : Form
    {
        string usser; int ID;
        List<Productos> list = new List<Productos>();

        public Form10(string _usser, int _ID)
        {
            usser = _usser;
            ID = _ID;
            InitializeComponent();
        }

        private void llenar_list()
        {
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string query = "SELECT Codigo, Producto, Descuento, Precio, Detalles,Categoría FROM  PRODUCTOS_DISPONIBLES";

            _comandosql = new SqlCommand(query, _conexion);
            _conexion.Open();

            _lector = _comandosql.ExecuteReader();

            while (_lector.Read())
            {
                list.Add(ConvertirEmpleado(_lector, false));
            }
            _comandosql.Dispose();
            _conexion.Close();
        }
        private static Productos ConvertirEmpleado(IDataReader reader, bool cargarRelaciones)
        {
            Productos producto = new Productos();

            producto.Nombre = Convert.ToString(reader["Producto"]);
            producto.Codigo = Convert.ToInt32(reader["Codigo"]);
            producto.Precio = Convert.ToInt32(reader["Precio"]);
            producto.Descuento = Convert.ToInt32(reader["Descuento"]);
            producto.Categoría = Convert.ToString(reader["Categoría"]);
            producto.Descripcion = Convert.ToString(reader["Detalles"]);


            return producto;
        }

        static private SqlConnection _conexion { get; set; }
        static private SqlCommand _comandosql { get; set; }
        static private SqlDataAdapter _adaptador { get; set; }
        static private SqlDataReader _lector { get; set; }

        private void Form10_Load(object sender, EventArgs e)
        {
            llenar_list();
            llenar_tabla();
            comboBox1.SelectedIndex = 0;
        }

        private void llenar_tabla()
        {
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string consulta = "SELECT Codigo, Producto, Descuento, Precio, Detalles,Categoría FROM  PRODUCTOS_DISPONIBLES";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, _conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            string tDesc;

            tDesc = numericUpDown1.Text;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Llena todos los campos.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string query = String.Format("EXEC SP_PRODUCTOS " + textBox2.Text + ", '" + textBox1.Text + "', " + tDesc + ", "+ textBox3.Text + ",' " + richTextBox1.Text + "', "+comboBox1.SelectedIndex +"");
            conectar.executeQuery1(query, _conexion, _comandosql, _adaptador);

            llenar_tabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ofdInsertar.ShowDialog();
            string flnm = ofdInsertar.FileName;
            datosCSV(flnm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(NewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //MODIFICAR
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string consulta = String.Format("UPDATE PRODUCTOS set NOMBRE= '" + textBox1.Text + "', DESCUENTO=" + numericUpDown1.Text
                + ", PRECIO= " + textBox3.Text + ", DESCRIPCION= '" + richTextBox1.Text + "', ID_CATEGORIA= " + comboBox1.SelectedIndex + " WHERE CODIGO=" + textBox2.Text + "");
            conectar.executeQuery1(consulta, _conexion, _comandosql, _adaptador);
            MessageBox.Show("Cambios guardados.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            llenar_tabla();
        }
     
        private void button6_Click(object sender, EventArgs e)
        {
            //ELIMINAR
            if ( textBox2.Text == "" )
            {
                MessageBox.Show("Añade el Codigo del producto a eliminar.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string consulta = " DELETE FROM PRODUCTOS where CODIGO=" + textBox2.Text + "";
            conectar.executeQuery1(consulta, _conexion, _comandosql, _adaptador);

            llenar_tabla();
            MessageBox.Show("Se ha eliminado.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedCells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
            numericUpDown1.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[3].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedCells[4].Value.ToString();
            int indice;
            string temp1 = dataGridView1.SelectedCells[5].Value.ToString();
            if (temp1 == "")
            {
                comboBox1.SelectedIndex =0;
                return;
            }
            else if (temp1 == "Despensa")
            {
                comboBox1.SelectedIndex = 1;
            }
            else if (temp1 == "Bebidas")
            {
                comboBox1.SelectedIndex = 2;
            }
            else if (temp1 == "Mascotas")
            {
                comboBox1.SelectedIndex = 3;
            }
            else if (temp1 == "Bebes")
            {
                comboBox1.SelectedIndex = 4;
            }
            else if (temp1 == "CuidadoPersonal")
            {
                comboBox1.SelectedIndex = 5;
            }
            else if (temp1 == "Limpieza")
            {
                comboBox1.SelectedIndex = 6;
            }
        }

        private void NewForm()
        {
            Application.Run(new Form8(usser, ID));
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
                MessageBox.Show("Productos cargados.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        int temp_;
        private void rep(string[] valores, string[] lines)
        {
            temp_ = Int32.Parse(valores[0]);

            try
            {
                    ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
                    _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
                    string query = String.Format("INSERT INTO PRODUCTOS (CODIGO,NOMBRE,DESCUENTO,PRECIO,DESCRIPCION,ID_CATEGORIA)"
                        + "VALUES ({0}, '{1}', {2}, {3}, '{4}', {5})", temp_, valores[1], valores[2], valores[3], valores[4], valores[5]);
                    conectar.executeQuery1(query, _conexion, _comandosql, _adaptador);
                    llenar_tabla();
                }
                catch (Exception)
                {
                    temp_++;
                }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(NewForm3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void NewForm3()
        {
            Application.Run(new Form18());
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                errorProvider1.SetError(label3, "Por favor, escriba únicamente números.");
                label3.Text = "Por favor, escriba únicamente números.";
            }
            else
            {
                errorProvider1.SetError(label3, "");
                label3.Text = "";
            }
        }
    }
}
