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

namespace MAD
{
    public partial class Form11 : Form
    {

        bool edicion = false;
        int ID = 0, IDtemp = 0;
        string usser;
        static private SqlConnection _conexion { get; set; }
        static private SqlCommand _comandosql { get; set; }
        static private SqlDataAdapter _adaptador { get; set; }
        static private SqlDataReader _lector { get; set; }
      
        public Form11(string tusser, int tID)
        {
            ID = tID;
            usser = tusser;
            edicion = true;
            InitializeComponent();
        }

        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (edicion)
            {
                //MODIFICAR
                string tFecha = DateTime.Now.ToString("dd-mm-yyyy");
                ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
                _conexion = conectar.conectar();
                string query1 = String.Format("UPDATE Empleados SET Nombre='" + textBox1.Text + "', Apellido='" + textBox2.Text + "', Usuario='" + textBox6.Text + "',Nacimiento='" + dateTimePicker1.Text + "' WHERE Id_Empleado=" + ID + ";");
                conectar.executeQuery1(query1, _conexion, _comandosql, _adaptador);
                int cp = Int32.Parse(textBox12.Text);
                string query2 = String.Format("UPDATE Domicilio SET Municipio='" + textBox10.Text + "', Estado='" + textBox11.Text + "', CP=" + cp + ",Calle='" + textBox7.Text + "', Numero='" + textBox8.Text + "' WHERE ID_EMP=" + ID + ";");
                conectar.executeQuery1(query2, _conexion, _comandosql, _adaptador);
                MessageBox.Show("Se han modificado los datos.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                usser = textBox6.Text;
                this.Close();
                Thread th = new Thread(NewForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                //REGISTRO
                int cp = Int32.Parse(textBox12.Text);

                if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox13.Text == "" || textBox6.Text == "" || textBox3.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "")
                {
                    MessageBox.Show("Llena todos los campos.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
                _conexion = conectar.conectar();
                string query = String.Format("INSERT INTO Empleados (Nombre,Apellido,RFC,Nacimiento,Usuario,Contraseña,CURP,FechaAlta)"
                 + "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}','{5}', '{6}', GETDATE())", textBox1.Text, textBox2.Text, textBox13.Text, dateTimePicker1.Text, textBox6.Text, textBox3.Text, textBox4.Text, DateTime.Now.ToString("yyyy-MM-dd"));

                //string query = String.Format("EXEC SP_EMPLEADO '" + textBox1.Text + "','" + textBox2.Text + "', "  + textBox13.Text + ",'" + dateTimePicker1.Text + "','" + textBox6.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "';");
                conectar.executeQuery1(query, _conexion, _comandosql, _adaptador);

                string query3 = String.Format("SELECT Id_Empleado FROM Empleados WHERE Usuario='" + textBox6.Text + "'");
                ID = conectar.executeQuery2(query3, _conexion, _comandosql, _lector, ID, IDtemp);


                string query1 = String.Format("INSERT INTO Domicilio (Municipio,Estado,CP,Calle,Numero,ID_EMP)"
                 + "VALUES ('{0}', '{1}', {2}, '{3}', {4}, {5})", textBox10.Text, textBox11.Text, cp, textBox7.Text,  textBox8.Text, ID);
                conectar.executeQuery1(query1, _conexion, _comandosql, _adaptador);
                string query2 = String.Format("EXEC SP_ROL '" + "Empleado" + "'," + ID + ";");
                conectar.executeQuery1(query2, _conexion, _comandosql, _adaptador);

                this.Close();
                Thread th = new Thread(NewForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();

            }

        }

        private void NewForm()
        {
            Application.Run(new Form8(usser, ID));
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar))
            {
                errorProvider1.SetError(label6, "Por favor, escriba únicamente números.");
                label6.Text = "Por favor, escriba únicamente números.";
            }
            else
            {
                errorProvider1.SetError(label6, "");
                label6.Text = "";
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Form11_Load(object sender, EventArgs e)
        {
            if (edicion == true)
            {
                ConexionBasedeDatos conectar = ConexionBasedeDatos.GetInstance();
                _conexion = conectar.conectar();
                string query = String.Format("SELECT e.Nombre, e.Apellido, e.CURP, e.RFC, e.Nacimiento, e.FechaAlta, e.Contraseña, d.Municipio, d.Estado, d.CP, d.Calle, d.Numero, e.Usuario FROM Empleados e inner join Domicilio d on d.ID_EMP= e.Id_Empleado where e.Id_Empleado='" + ID + "'");
                _comandosql = new SqlCommand(query, _conexion);
                _conexion.Open();
                _lector = _comandosql.ExecuteReader();

                while (_lector.Read())
                {
                    //int dia, mes, año;
                    //string fecha = _lector.GetString(4);
                    //año = Int32.Parse(fecha);

                    //for (int i = 0; i == fecha[i]; i++)
                    //{
                    //    if (fecha[i] == '-')
                    //    {
                    //        año = fecha[0 + 1 + 2 + 3];
                    //    }
                    //}
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox13.Enabled = false;

                    textBox1.Text = _lector.GetString(0);
                    textBox2.Text = _lector.GetString(1);
                    textBox4.Text = _lector.GetString(2);
                    textBox13.Text = Convert.ToString(_lector.GetInt32(3));
                    label16.Text = "Fecha de creación de la cuenta: " + Convert.ToString(_lector["FechaAlta"]);
                    dateTimePicker1.Value = new DateTime(2012, 05, 28);

                    textBox6.Text = _lector.GetString(12); ;
                    textBox3.Text = _lector.GetString(6);
                    textBox10.Text = _lector.GetString(7);
                    textBox11.Text = _lector.GetString(8);
                    textBox12.Text = Convert.ToString(_lector["CP"]);
                    textBox7.Text = _lector.GetString(10);
                    textBox8.Text = Convert.ToString(_lector["Numero"]);
                    break;
                }
                _comandosql.Dispose();
                _conexion.Close();
            }
        }
    }
}
