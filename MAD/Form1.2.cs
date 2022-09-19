using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAD.DBConnection;

namespace MAD
{
    public partial class Form14 : Form
    {

        int attempt = 0, ID = 0, IDtemp = 0;
        string s_usser = "", s_password = "", rol = "", acc_ant = "";
        static private SqlConnection _conexion { get; set; }
        static private SqlCommand _comandosql { get; set; }
        static private SqlDataReader _lector { get; set; }
        static private SqlDataAdapter _adaptador { get; set; }

        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            Leer();
            if (s_password != "" && s_usser != "")
            {
                checkBox1.Checked = true;
                textBox1.Text = s_password.ToString();
                textBox2.Text = s_usser.ToString();
            }
            else return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(NewForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tUsser = "", tContraseña = "";
            if (acc_ant != textBox2.Text)
            {
                attempt = 0;
            }
            acc_ant = textBox2.Text;
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Ingresa el usuario y la contraseña.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
            _conexion = conectar.conectar();
            string query = String.Format("SELECT e.Contraseña, e.Usuario, e.Id_Empleado, r.Rol FROM Empleados e inner join Rol r on r.Id_Empleado= e.Id_Empleado where e.Usuario='" + textBox2.Text + "'");
            _comandosql = new SqlCommand(query, _conexion);
            _conexion.Open();
            _lector = _comandosql.ExecuteReader();

            while (_lector.Read())
            {
                tContraseña = _lector.GetString(0);
                tUsser = _lector.GetString(1);
                ID = _lector.GetInt32(2);
                rol = _lector.GetString(3);
                break;
            }
            _comandosql.Dispose();
            _conexion.Close();

            if (String.IsNullOrEmpty(tContraseña) && String.IsNullOrEmpty(tUsser))
            {
                MessageBox.Show("La cuenta no existe.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ConexionBasedeDatos conectar1 = ConexionBasedeDatos.GetInstance();
            _conexion = conectar1.conectar();
            string query1 = String.Format("SELECT ID_USUARIO_EMPLEADO from BLOQUEADOS_E WHERE ID_USUARIO_EMPLEADO=" + ID + "");
            IDtemp = conectar.executeQuery2(query1, _conexion, _comandosql, _lector, ID, IDtemp);

            if (IDtemp == ID)
            {
                MessageBox.Show("Cuenta bloqueada.", "CUENTA BLOQUEADA", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (tContraseña != textBox1.Text)
            {
                attempt++;
                MessageBox.Show("Contraseña incorrecta.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (attempt == 3)
                {
                    if (rol == "Administrador")
                    {
                        return;
                        attempt = 0;
                    }
                    conectar = ConexionBasedeDatos.GetInstance();
                    _conexion = conectar.conectar();
                    query = String.Format("INSERT INTO BLOQUEADOS_E (ID_USUARIO_EMPLEADO)"
                        + "VALUES ({0})", ID);
                    conectar.executeQuery1(query, _conexion, _comandosql, _adaptador);
                    MessageBox.Show("Has excedido el número de intentos.\nPongase en contacto con un administrador para habilitar la cuenta nuevamente.", "CUENTA BLOQUEADA", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    attempt = 0;
                    return;
                }
                return;
            }

            if (checkBox1.Checked == true)
            {
                s_usser = textBox2.Text;
                s_password = textBox1.Text;
                Guardar();
            }
            else
            {
                s_usser = "";
                s_password = "";
                Guardar();
            }
            
            this.Close();
            Thread th = new Thread(NewForm1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();


        }
        private void Guardar()
        {
            TextWriter Writer = new StreamWriter("Load_e.txt");
            Writer.WriteLine(s_usser);
            Writer.WriteLine(s_password);
            Writer.Close();
        }

        private void Leer()
        {
            try
            {
                TextReader Reader = new StreamReader("Load_e.txt");

                s_usser = Reader.ReadLine();
                s_password = Reader.ReadLine();

                Reader.Close();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void NewForm1()
        {
            if (rol == "Administrador")
            {
                Application.Run(new Form12(s_usser, ID));
            }
            else
            Application.Run(new Form8(s_usser, ID));
        }

        private void NewForm2()
        {
            Application.Run(new Form11());
        }

    }
}
