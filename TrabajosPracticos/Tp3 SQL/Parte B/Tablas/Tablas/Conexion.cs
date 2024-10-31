using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablas

{
    class Conexion
    {
        public  MySqlConnection conexion()
        {
            string servidor = "localhost";
            string bd = "tienda";
            string usuario = "root";
            string password = "#Tomba1921";

            string cadenaConexion = "Database= " + bd + "; Data Source= " + servidor + "; User Id=" + usuario + "; Password=" + password + "";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                return conexionBD;
            }
            catch (MySqlException ex)
            {

                Console.WriteLine("Error: " + ex.Message);
                return null;
            }

        }

    }


}
