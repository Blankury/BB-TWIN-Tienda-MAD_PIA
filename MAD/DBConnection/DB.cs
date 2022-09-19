using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAD.Gestion_De_Datos;
namespace MAD.DBConnection
{
    class ConexionBasedeDatos
    {

        static private ConexionBasedeDatos instance = null;
        static private SqlConnection _conexion;

        private ConexionBasedeDatos()
        {

        }

        static public ConexionBasedeDatos GetInstance()
        {
            if (instance == null)
                instance = new ConexionBasedeDatos();

            return instance;

        }

        public SqlConnection conectar()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ConectarDB"].ToString();
            _conexion = new SqlConnection(conexion);
            return _conexion;
        }

        public void executeQuery1(string query, SqlConnection _conexion, SqlCommand _comandosql, SqlDataAdapter _adaptador)
        {
            _comandosql = new SqlCommand(query, _conexion);
            _conexion.Open();
            _adaptador = new SqlDataAdapter();
            _adaptador.UpdateCommand = new SqlCommand(query, _conexion);
            _adaptador.UpdateCommand.ExecuteNonQuery();
            _comandosql.Dispose();
            _conexion.Close();
        }
        public void executecmb(string query, SqlConnection _conexion, SqlCommand _comandosql, SqlDataReader _lectorasies, ComboBox comboBox1)
        {
            _comandosql = new SqlCommand(query, _conexion);
            _conexion.Open();
            _lectorasies = _comandosql.ExecuteReader();
            while (_lectorasies.Read())
            {
                comboBox1.Items.Add(_lectorasies["Nombre"].ToString());
            }
            _comandosql.Dispose();
            _conexion.Close();
        }

        public int executeQuery2(string query, SqlConnection _conexion, SqlCommand _comandosql, SqlDataReader _lectorasies, int ID, int IDtemp)
        {
            _comandosql = new SqlCommand(query, _conexion);
            _conexion.Open();
            _lectorasies = _comandosql.ExecuteReader();

            while (_lectorasies.Read())
            {
                IDtemp = _lectorasies.GetInt32(0);
            }
            _comandosql.Dispose();
            _conexion.Close();
            return IDtemp;
        }
        

    }
}
