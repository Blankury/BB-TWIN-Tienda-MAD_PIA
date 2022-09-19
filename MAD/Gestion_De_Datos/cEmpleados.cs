using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAD.Gestion_De_Datos
{
    class Empleados
    {
        public bool bloqueado = false;
        public int ID;
        public int Num_Ext;
        public int CP;
        public string rol = "";
        public string Nombre;
        public string Usuario;
        public string Apellido;
        private string Contraseña;
        public string Nacimiento;
        public string Fecha_Alta;
        public string RFC;
        public string CURP;
        public string Calle;
        public string Colonia;
        public string Municipio;
        public string Estado;


        //static private SqlConnection _conexion { get; set; }
        //static private SqlCommand _comandosql { get; set; }
        //static private SqlDataAdapter _adaptador { get; set; }

    }
}
