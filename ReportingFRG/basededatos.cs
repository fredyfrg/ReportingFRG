using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ReportingFRG
{
    class basededatos
    {
        public static SqlConnection ObtenerConexion(string host,string bd,string usuario,string contraseña)
        {
            SqlConnection conectar = new SqlConnection("Server="+host+"; database="+bd+"; Integrated Security = false; User ID ="+usuario+"; Password ="+contraseña+";");
            conectar.Open();
            return conectar;
        }
    }
}
