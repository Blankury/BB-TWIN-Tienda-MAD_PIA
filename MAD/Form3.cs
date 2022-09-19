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
using MAD.DBConnection;

namespace MAD
{
    public partial class Form3 : Form
    {
        public Form3(string t_email, int tID)
        {
            ID = tID;
            email = t_email;
            edicion = true;
            InitializeComponent();
        }

        public Form3()
        {
            InitializeComponent();
        }

        int ID = 0, IDtemp = 0;
        bool edicion = false;
        string email = "";
        static private SqlConnection _conexion { get; set; }
        static private SqlCommand _comandosql { get; set; }
        static private SqlDataAdapter _adaptador { get; set; }
        static private SqlDataReader _lector { get; set; }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (edicion == true)
            {
                string t_fecha, t_password;
                ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
                _conexion = conectar.conectar();
                string query = String.Format("SELECT c.Nombre, c.Apellido, c.CURP, c.Telefono,  c.Nacimiento, c.Domicilio, c.FechaAlta, c.Contraseña, c.Id_Cliente, e.Email FROM Clientes c inner join Email e on e.Id_Email= c.Id_Cliente where e.Email='" + email + "'");

                _comandosql = new SqlCommand(query, _conexion);
                _conexion.Open();
                _lector = _comandosql.ExecuteReader();

                while (_lector.Read())
                {
                    ////int dia, mes, año;
                    ////string fecha = _lector.GetString(4);
                    ////año = Int16.Parse(fecha);

                    ////for (int i = 0; i == fecha[i]; i++)
                    ////{
                    ////    if (fecha[i] == '-')
                    ////    {
                    ////        año = fecha[0 + 1 + 2 + 3];
                    ////    }
                    ////}

                    textBox1.Text = _lector.GetString(0);
                    textBox2.Text = _lector.GetString(1);
                    textBox4.Text = _lector.GetString(2);
                    textBox4.Enabled = false;
                    textBox13.Text = _lector.GetString(3);
                    dateTimePicker1.Value = new DateTime(2012, 05, 28);
                    textBox6.Enabled = false;
                    richTextBox1.Text = _lector.GetString(5);
                    textBox6.Text = _lector.GetString(7);
                    ID = _lector.GetInt32(8);
                    textBox5.Text = _lector.GetString(9);

                    break;
                }
                _comandosql.Dispose();
                _conexion.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (edicion)
            {
                //MODIFICAR
                string tFecha = DateTime.Now.ToString("dd-mm-yyyy");
                ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
                _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
                string query = String.Format("UPDATE Clientes SET Nombre='" + textBox1.Text + "', Apellido='" + textBox2.Text + "', Telefono='" + textBox13.Text + "',Nacimiento='" + dateTimePicker1.Text + "',Domicilio='" + richTextBox1.Text + "' WHERE Id_Cliente=" + ID + ";");
                conectar.executeQuery1(query, _conexion, _comandosql, _adaptador);
                string query1 = String.Format("UPDATE Email SET Email='" + textBox5.Text + "' WHERE Id_Email=" + ID + ";");
                conectar.executeQuery1(query1, _conexion, _comandosql, _adaptador);

                this.Close();
                Thread th = new Thread(NewForm1);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                //REGISTRO
            string tNacimiento, tFecha;
            tNacimiento = dateTimePicker1.Text;
                tFecha = DateTime.Now.ToString("dd-mm-yyyy");

            if (textBox1.Text == "" || textBox2.Text == "" || textBox13.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox4.Text == "" || tNacimiento == "" || tFecha == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Llena todos los campos.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Clientes temp = new Clientes();
            //temp.Nombre = tNombre;
            //temp.Apellido = tApellido;
            //temp.CURP = tCURP;
            //temp.Domicilio = tDomicilio;
            //temp.Telefono = tTel;
            //temp.Nacimiento = tNacimiento;
            //temp.Email = tCorreo;
            //temp.Fecha = tFecha;
            //temp.contraseña = tContraseña;
            //temp.ID = temp.ID++;
            //Cliente_L.Add(temp);

            ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance(); //instancia del singleton
            _conexion = conectar.conectar(); //usamos el metodo de conectar del singleton
            string query = String.Format("INSERT INTO Clientes (Nombre,Apellido,Contraseña,Telefono,CURP,Nacimiento,Domicilio,FechaAlta)"
                + "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}','{5}', '{6}', GETDATE())", textBox1.Text, textBox2.Text, textBox6.Text, textBox13.Text, textBox4.Text, tNacimiento, richTextBox1.Text, tFecha);
            conectar.executeQuery1(query, _conexion, _comandosql, _adaptador);
            string query2 = String.Format("INSERT INTO Email (Email)"
                    + "VALUES ('{0}')", textBox5.Text);
            conectar.executeQuery1(query2, _conexion, _comandosql, _adaptador);

            string query3 = String.Format("SELECT Id_Email from Email WHERE Email='" + textBox5.Text + "'");
            ID = conectar.executeQuery2(query3, _conexion, _comandosql, _lector, ID, IDtemp);

            string query4 = String.Format("INSERT INTO Clave_Email (Id_Cliente, Id_Email)"
                    + "VALUES ({0}, {1})", ID, ID);
            conectar.executeQuery2(query4, _conexion, _comandosql, _lector, ID, IDtemp);

            string query5 = String.Format("INSERT INTO CARRITO (Id_Cliente)"
                + "VALUES ({0})", ID);
            conectar.executeQuery1(query5, _conexion, _comandosql, _adaptador);

            this.Close();
            Thread th = new Thread(NewForm1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
                
            }
        
        }
        
        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
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
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (edicion)
            {
                this.Close();
                Thread th = new Thread(NewForm1);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                this.Close();
                Thread th = new Thread(NewForm2);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }

        private void NewForm1()
        {
            Application.Run(new Form4(email, ID));
        }

        private void NewForm2()
        {
            Application.Run(new Form1());
        }
    }
}
