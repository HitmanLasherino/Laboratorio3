using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            try
            {

            
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String descripcion = txtDescripcion.Text;
            double precio_publico= double.Parse(txtPrecioPublico.Text);
            int existencias = int.Parse(txtExistencias.Text);

            if (codigo !="" && nombre !="" && descripcion !="" && precio_publico>0 && existencias > 0) { 

            string sql = "INSERT INTO productos (codigo,nombre,descripcion,precio_publico,existencias) VALUES ('"+ codigo+ "','"+ nombre+"','"+ descripcion+"','"+ precio_publico+"','"+ existencias+"')";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Guardado");
                limpiar();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar; " + ex.Message);
            }
            finally
            {
                conexionBD.Close();    
            }
            }
                else
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Datos incorrectos: " + fex.Message);
            }
    }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            String codigo= txtCodigo.Text;
            MySqlDataReader reader = null;

            string sql = "SELECT idproductos, codigo, nombre, descripcion, precio_publico, existencias FROM productos WHERE codigo LIKE '"+codigo+ "' LIMIT 1";
            MySqlConnection conexionBD= Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtId.Text = reader.GetString(0);
                        txtCodigo.Text = reader.GetString(1);
                        txtNombre.Text = reader.GetString(2);
                        txtDescripcion.Text = reader.GetString(3);
                        txtPrecioPublico.Text = reader.GetString(4);
                        txtExistencias.Text = reader.GetString(5);

                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            String id = txtId.Text;
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String descripcion = txtDescripcion.Text;
            double precio_publico = double.Parse(txtPrecioPublico.Text);
            int existencias = int.Parse(txtExistencias.Text);

            string sql = "UPDATE productos SET codigo='"+codigo+"', nombre='"+nombre+"',descripcion= '"+descripcion+"',precio_publico='"+precio_publico+"',existencias= '"+existencias+
             "' WHERE idproductos='"+id+"'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Modificado");
                limpiar();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al modificar; " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }


        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            String id = txtId.Text;
           
            string sql = "DELETE FROM productos WHERE idproductos='" + id + "'";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Eliminado");
                limpiar();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar; " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();

        }

        private void limpiar()
        {
            txtId.Text = "";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecioPublico.Text = "";
            txtExistencias.Text = "";
        }

    }
}

