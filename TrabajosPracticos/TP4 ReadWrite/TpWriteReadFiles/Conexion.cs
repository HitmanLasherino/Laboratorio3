using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TpWriteReadFiles

{
    class Conexion
    {
        public MySqlConnection conexion()
        {
            string servidor = "localhost";
            string bd = "utn";
            string usuario = "root";
            string password = "#1234";

            string cadenaConexion = $"Server={servidor}; Database={bd}; User Id={usuario}; Password={password};";

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
