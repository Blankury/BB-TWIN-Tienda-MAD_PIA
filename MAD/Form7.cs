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
    public partial class Form7 : Form
    {
        bool recibo, eliminar;
        int ID, IDsuc;
        string email;
        double total;
        static private SqlConnection _conexion { get; set; }
        static private SqlCommand _comandosql { get; set; }
        static private SqlDataAdapter _adaptador { get; set; }
        static private SqlDataReader _lector { get; set; }

        public Form7(string _email, int _ID, double _total)
        {
            total = _total;
            email = _email;
            ID = _ID;
            InitializeComponent();
        }
        
        private void Form7_Load(object sender, EventArgs e)
        {
            label12.Text = "$" + total;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string query = String.Format("SELECT Nombre, Apellido, Telefono, Domicilio FROM Clientes WHERE Id_Cliente=" + ID);
            _comandosql = new SqlCommand(query, _conexion);
            _conexion.Open();
            _lector = _comandosql.ExecuteReader();

            while (_lector.Read())
            {
                label2.Text = _lector.GetString(0) + _lector.GetString(1);
                label4.Text = _lector.GetString(2);
                textBox1.Text = _lector.GetString(3);
            }
            _comandosql.Dispose();
            _conexion.Close();
            
            conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string query2 = String.Format("SELECT Nombre from Sucursal");
            conectar.executecmb(query2, _conexion, _comandosql, _lector, comboBox2);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { 
            if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.Enabled = true;
            }
            else { 
                comboBox2.Enabled = false;
                comboBox2.SelectedIndex = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                textBox2.Enabled = true;
                
            }
            else
            {
                textBox2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (textBox2.Text == "" && comboBox3.SelectedIndex == 0)
            {
                MessageBox.Show("Ingresa el número de tarjeta.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 0) {
                MessageBox.Show("Selecciona la sucursal", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (recibo == false && comboBox3.SelectedIndex == 0)
            {
                MessageBox.Show("Descargue el recibo antes de pagar.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string query = "SELECT NUMERO FROM SUCURSAL WHERE NOMBRE='" + comboBox2.GetItemText(comboBox2.SelectedItem) + "'";
            _comandosql = new SqlCommand(query, _conexion);
            _conexion.Open();
            _lector = _comandosql.ExecuteReader();
            while (_lector.Read())
            {
                IDsuc = Convert.ToInt32(_lector["NUMERO"]);
            }
            _comandosql.Dispose();
            _conexion.Close();

            conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string query2 = String.Format("select Nombre from PRODUCTOS_CARRITO where Canasta=" + ID);
            _comandosql = new SqlCommand(query2, _conexion);
            _conexion.Open();
            _lector = _comandosql.ExecuteReader();
            string nombres = "";
            while (_lector.Read())
            {
                nombres = nombres + (Convert.ToString(_lector["Nombre"])) + ", ";
            }
            _comandosql.Dispose();
            _conexion.Close();
            
            conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            if (IDsuc != 0)
            {
                string query1 = String.Format("INSERT INTO PAGO_ENVIO (ID_CLIENTE,METODO_PAGO,METODO_ENTREGA,ID_SUCURSAL,FECHA_CREACION,ESTATUS, TOTAL, ANO, MES, PRODUCTOS) "
        + "VALUES ({0}, '{1}', '{2}', {3}, '{4}', '{5}', {6}, {7}, {8}, '{9}')", ID, comboBox3.Text, comboBox1.Text, IDsuc, DateTime.Now.ToString("yyyy/MM/dd"), "Pagado", total, DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), nombres);
                conectar.executeQuery1(query1, _conexion, _comandosql, _adaptador);
            }
            else
            {
                string query1 = String.Format("INSERT INTO PAGO_ENVIO (ID_CLIENTE,METODO_PAGO,METODO_ENTREGA, FECHA_CREACION,ESTATUS, TOTAL, ANO, MES, PRODUCTOS) "
        + "VALUES ({0}, '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7}, '{8}')", ID, comboBox3.Text, comboBox1.Text, DateTime.Now.ToString("yyyy/MM/dd"), "Pagado", total, DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), nombres);
                conectar.executeQuery1(query1, _conexion, _comandosql, _adaptador);
            }
            MessageBox.Show("Se realizó el pago.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string consulta = " DELETE FROM LISTA_PRODUCTOS where ID_CARRITO=" + ID + "";
            conectar.executeQuery1(consulta, _conexion, _comandosql, _adaptador);

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 1)
            {
                ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
                _conexion = conectar.conectar();
                string query = "SELECT NUMERO FROM SUCURSAL WHERE NOMBRE='" + comboBox2.GetItemText(comboBox2.SelectedItem) + "'";
                _comandosql = new SqlCommand(query, _conexion);
                _conexion.Open();
                _lector = _comandosql.ExecuteReader();
                while (_lector.Read())
                {
                    IDsuc = Convert.ToInt32(_lector["NUMERO"]);
                }
                _comandosql.Dispose();
                _conexion.Close();

                conectar = ConexionBasedeDatos.GetInstance();
                _conexion = conectar.conectar();
                string query2 = String.Format("select Nombre from PRODUCTOS_CARRITO where Canasta=" + ID);
                _comandosql = new SqlCommand(query2, _conexion);
                _conexion.Open();
                _lector = _comandosql.ExecuteReader();
                string nombres = "";
                while (_lector.Read())
                {
                    nombres = nombres + (Convert.ToString(_lector["Nombre"])) + ", ";
                }
                _comandosql.Dispose();
                _conexion.Close();

                conectar = ConexionBasedeDatos.GetInstance();
                _conexion = conectar.conectar();
                if (IDsuc != 0)
                {
                    string query1 = String.Format("INSERT INTO PAGO_ENVIO (ID_CLIENTE,METODO_PAGO,METODO_ENTREGA,ID_SUCURSAL,FECHA_CREACION,ESTATUS, TOTAL, ANO, MES, PRODUCTOS) "
            + "VALUES ({0}, '{1}', '{2}', {3}, '{4}', '{5}', {6}, {7}, {8}, '{9}')", ID, comboBox3.Text, comboBox1.Text, IDsuc, DateTime.Now.ToString("yyyy/MM/dd"), "Pendiente", total, DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), nombres);
                    conectar.executeQuery1(query1, _conexion, _comandosql, _adaptador);
                }
                else
                {
                    string query1 = String.Format("INSERT INTO PAGO_ENVIO (ID_CLIENTE,METODO_PAGO,METODO_ENTREGA, FECHA_CREACION,ESTATUS, TOTAL, ANO, MES, PRODUCTOS) "
            + "VALUES ({0}, '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7}, '{8}')", ID, comboBox3.Text, comboBox1.Text, DateTime.Now.ToString("yyyy/MM/dd"), "Pendiente", total, DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), nombres);
                    conectar.executeQuery1(query1, _conexion, _comandosql, _adaptador);
                }
                eliminar = true;
            }
            if (textBox2.Text == "" && comboBox3.SelectedIndex == 0)
            {
                MessageBox.Show("Ingresa el número de tarjeta.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else {
            recibo = true;
            }
            if (eliminar)
            {
                this.Close();
                Thread th = new Thread(NewForm3);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();

            }
            else
            {

            Thread th = new Thread(NewForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            }
        }
        private void NewForm2()
        {
            Application.Run(new Form16(ID));

        }

        private void NewForm3()
        {
            Application.Run(new Form16(ID, true));

        }
    }
}
