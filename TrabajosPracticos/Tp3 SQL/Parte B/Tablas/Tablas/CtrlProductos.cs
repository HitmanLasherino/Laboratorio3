using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablas
{
    class CtrlProductos : Conexion
    {
        public List<Object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<Object> lista = new List<Object>();
            string sql;

            if (dato == null)
            {
                sql = "SELECT idproductos,codigo,nombre,descripcion,precio_publico, existencias FROM productos ORDER BY nombre ASC";
            }
            else
            {
                sql = "SELECT idproductos,codigo,nombre,descripcion,precio_publico,existencias FROM productos WHERE codigo LIKE '%" + dato + "%' OR nombre LIKE '%" +dato  + "%' OR descripcion LIKE '%" + dato + "%' OR precio_publico LIKE '%" + dato + "%' OR existencias LIKE '%" + dato + "%' ORDER BY nombre ASC";

            }
            try
            {

            
            MySqlConnection conexionBD = base.conexion();
            conexionBD.Open();  
            MySqlCommand comando = new MySqlCommand(sql, conexionBD);       
            reader= comando.ExecuteReader();

            while (reader.Read())
            {
                Productos _producto = new Productos();
                _producto.Id =int.Parse( reader.GetString(0));
                _producto.Codigo = reader[1].ToString();
                _producto.Nombre = reader.GetString("nombre");
                _producto.Descripcion= reader[3].ToString();
                _producto.Precio_publico= double.Parse(reader[4].ToString());
                _producto.Existencias=int.Parse(reader.GetString(5));   

                lista.Add(_producto);

                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            
            }
            return lista;

        }

        public bool insertar(Productos datos)
        {
            bool bandera = false;

            string sql = "INSERT INTO productos (codigo,nombre,descripcion,precio_publico,existencias) VALUES ('" + datos.Codigo + "','" + datos.Nombre + "','" + datos.Descripcion + "','" + datos.Precio_publico + "','" + datos.Existencias + "')";

            try
            {
                MySqlConnection conexionBD = base.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;

            }
            return bandera;
        }

        public bool actualizar(Productos datos)
        {
            bool bandera = false;

            string sql = "UPDATE productos SET codigo= '" + datos.Codigo + "',nombre='" + datos.Nombre + "',descripcion='" + datos.Descripcion + "',precio_publico='" + datos.Precio_publico + "',existencias='" + datos.Existencias + "' WHERE idproductos='" + datos.Id + "'";
            try
            {
                MySqlConnection conexionBD = base.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;

            }
            return bandera;
        }

        public bool eliminar(int id)
        {
            bool bandera = false;

            string sql = "DELETE FROM productos WHERE idproductos='" + id + "'";
            try
            {
                MySqlConnection conexionBD = base.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;

            }
            return bandera;
        }



    }
}
