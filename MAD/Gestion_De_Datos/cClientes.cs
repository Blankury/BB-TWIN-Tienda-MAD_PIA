using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAD.Gestion_De_Datos
{
    class Clientes
    {
        public int ID;
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string CURP { get; set; }
        public string Nacimiento { get; set; }
        public string Fecha { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public bool bloqueado = false;
        private string Contraseña;
        public string contraseña
        {
            get { return Contraseña; }
            set { Contraseña = value; }
        }


        //static private SqlConnection _conexion { get; set; }
        //static private SqlCommand _comandosql { get; set; }
        //static private SqlDataAdapter _adaptador { get; set; }

    }
}
