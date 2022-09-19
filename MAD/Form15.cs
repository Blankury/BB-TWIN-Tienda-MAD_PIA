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
    public partial class Form15 : Form
    {
        bool edicion = false;
        int ID = 0, IDtemp = 0, id =  0;
        string usser;
        static private SqlConnection _conexion { get; set; }
        static private SqlCommand _comandosql { get; set; }
        static private SqlDataAdapter _adaptador { get; set; }
        static private SqlDataReader _lector { get; set; }

        public Form15(string tusser, int tID)
        {
            ID = tID;
            usser = tusser;
            edicion = true;
            InitializeComponent();
        }
        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
        private void Modificar_Click(object sender, EventArgs e)
        {
            string tFecha = DateTime.Now.ToString("dd-mm-yyyy");
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string query1 = String.Format("UPDATE Empleados SET Nombre='" + textBox1.Text + "', Apellido='" + textBox2.Text + "', Usuario='" + textBox6.Text + "',Nacimiento='" + dateTimePicker1.Text + "' WHERE Id_Empleado=" + id  + ";");
            conectar.executeQuery1(query1, _conexion, _comandosql, _adaptador);
            int cp = Int32.Parse(textBox12.Text);
            string query2 = String.Format("UPDATE Domicilio SET Municipio='" + textBox10.Text + "', Estado='" + textBox11.Text + "', CP=" + cp + ",Calle='" + textBox7.Text + "', Numero='" + textBox8.Text + "' WHERE ID_EMP=" + id + ";");
            conectar.executeQuery1(query2, _conexion, _comandosql, _adaptador);
            MessageBox.Show("Se han modificado los datos.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            usser = textBox6.Text;
            llenar_tabla();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            llenar_tabla();
        }
        private void llenar_tabla()
        {
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar(); 
            string consulta = String.Format("SELECT e.Nombre, e.Apellido, e.CURP, e.RFC, e.Nacimiento, e.FechaAlta, d.Municipio, d.Estado, d.CP, d.Calle, d.Numero, e.Usuario FROM Empleados e inner join Domicilio d on d.ID_EMP = e.Id_Empleado where e.Id_Empleado != " + ID );
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, _conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            //ELIMINAR
            if (textBox6.Text == "")
            {
                MessageBox.Show("Añade el Codigo del empleado a eliminar.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string consulta = " DELETE FROM Empleados where Id_Empleado=" + ID + "";
            conectar.executeQuery1(consulta, _conexion, _comandosql, _adaptador);
            llenar_tabla();
            MessageBox.Show("Se ha eliminado el empleado.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox13.Text = dataGridView1.SelectedCells[3].Value.ToString();
            textBox6.Text = dataGridView1.SelectedCells[11].Value.ToString();
            //fecha
            label16.Text = "Fecha de creación de la cuenta: " + dataGridView1.SelectedCells[5].Value.ToString();
            textBox10.Text = dataGridView1.SelectedCells[6].Value.ToString();
            textBox11.Text = dataGridView1.SelectedCells[7].Value.ToString();
            textBox12.Text = dataGridView1.SelectedCells[8].Value.ToString();
            textBox7.Text = dataGridView1.SelectedCells[9].Value.ToString();
            textBox8.Text = dataGridView1.SelectedCells[10].Value.ToString();

            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string query3 = String.Format("SELECT Id_Empleado from Empleados WHERE Usuario='" + textBox6.Text + "'");
            id = conectar.executeQuery2(query3, _conexion, _comandosql, _lector, ID, IDtemp);

            //id = Int32.Parse(textBox6.Text);

        }

        private void NewForm()
        {
            Application.Run(new Form8(usser, ID));
        }
    }
}
