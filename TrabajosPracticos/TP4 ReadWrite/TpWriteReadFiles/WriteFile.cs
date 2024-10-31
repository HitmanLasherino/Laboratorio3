using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;
using System.Globalization;



namespace TpWriteReadFiles
{
    internal class WriteFile
    {
        static void Main(string[] args)
        {
            // Conexion a BD
            Conexion conexion = new Conexion();
            MySqlConnection conx = conexion.conexion();

            if (conx == null)
            {
                Console.WriteLine("No se pudo establecer la conexión a la base de datos.");
                return;
            }

            //PRIMERA PARTE Escritura del Archivo
            WriteToFile(conx);

            //SEGUNDA PARTE Lectura del Archivo
            ReadFromFileAndInsert(conx);

        }


        //Codigo primera parte
        private static void WriteToFile(MySqlConnection conx)
        {
            
            try
            {
                conx.Open();

                StreamWriter writer = new StreamWriter(@"C:\Users\sahid\OneDrive\Documentos\articulos.txt");
                StringBuilder buffer = new StringBuilder();

                //Definimos la cantidad de articulos a utilizar
                int numArt = 0;
                const int limite = 50;

                //Creamos la primer Fila que lleva los nombres de la tabla
                buffer.Append("ID");
                buffer.Append("\t");
                buffer.Append("FechaAlta");
                buffer.Append("\t");
                buffer.Append("Codigo");
                buffer.Append("\t");
                buffer.Append("Denominacion");
                buffer.Append("\t");
                buffer.Append("Precio");
                buffer.Append("\t");
                buffer.Append("Publicado");

                //Abrimos el bucle que va a leer los archivos de la bd
                for (numArt = 0; ; numArt += limite)
                {
                    string query = $"SELECT * FROM articulo LIMIT {numArt},{limite}";
                    using (MySqlCommand command = new MySqlCommand(query, conx))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows) break; // Sale del bucle si no quedan filas
                            for (int i = 1; reader.Read(); i++)
                            {
                                buffer.Append("\n");
                                buffer.Append(reader["ID"]);
                                buffer.Append("\t");
                                buffer.Append(reader["fechaAlta"]);
                                buffer.Append("\t");
                                buffer.Append(reader["Codigo"]);
                                buffer.Append("\t");
                                buffer.Append(reader["Denominacion"]);
                                buffer.Append("\t");
                                buffer.Append(reader["Precio"]);
                                buffer.Append("\t");
                                buffer.Append(reader["Publicado"]);
                            }
                        }
                    }
                }
                writer.Write(buffer.ToString());
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            finally
            {
                if (conx != null)
                {
                    conx.Close();
                }

            }
        }

        //Codigo segunda parte
        private static void ReadFromFileAndInsert(MySqlConnection conx)
        {
            conx.Open();

            try
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\sahid\OneDrive\Documentos\articulos.txt"))
                {
                    string line;
                    MySqlCommand myCommand = conx.CreateCommand();
                    int contador = 0;

                    // Saltamos la primera línea
                    reader.ReadLine();
                    myCommand.Connection = conx;
                    
                    decimal precio;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split('\t');

                        // Convertimos la fecha
                        if (fields.Length >= 6 && DateTime.TryParse(fields[1], out DateTime fechaAlta))
                        {
                            string formattedDate = fechaAlta.ToString("yyyy-MM-dd HH:mm:ss");

                            // Reemplazar la coma por un punto en el precio
                            string precioStr = fields[4].Replace(',', '.');

                            if (contador % 50 == 0)
                            {
                                MySqlTransaction myTrans = conx.BeginTransaction();
                                myCommand.Transaction = myTrans;

                                try
                                {
                                    // Asignamos parámetros
                                    myCommand.CommandText = "INSERT INTO articulo_copy (ID, FechaAlta, Codigo, Denominacion, Precio, Publicado) VALUES (@id, @fechaAlta, @codigo, @denominacion, @precio, @publicado) " +
                                                            "ON DUPLICATE KEY UPDATE FechaAlta=@fechaAlta, Denominacion=@denominacion, Precio=@precio, Publicado=@publicado";

                                    // Converti y asigna precio
                                    if (decimal.TryParse(precioStr, NumberStyles.Any, CultureInfo.InvariantCulture, out precio))
                                    {
                                        myCommand.Parameters.Clear();
                                        myCommand.Parameters.AddWithValue("@id", fields[0]);
                                        myCommand.Parameters.AddWithValue("@fechaAlta", formattedDate);
                                        myCommand.Parameters.AddWithValue("@codigo", fields[2]);
                                        myCommand.Parameters.AddWithValue("@denominacion", fields[3]);
                                        myCommand.Parameters.AddWithValue("@precio", precio); 
                                        myCommand.Parameters.AddWithValue("@publicado", fields[5]);

                                        myCommand.ExecuteNonQuery();
                                        // Comiteamos
                                        myTrans.Commit();
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Precio inválido: {precioStr}");
                                        myTrans.Rollback();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    myTrans.Rollback();
                                    Console.WriteLine($"Error en transacción: {ex.Message}");
                                }
                            }
                            else
                            {
                                // En caso de que no se pueda realizar la transaccion
                                myCommand.CommandText = "INSERT INTO articulo_copy (ID, FechaAlta, Codigo, Denominacion, Precio, Publicado) VALUES (@id, @fechaAlta, @codigo, @denominacion, @precio, @publicado) " +
                                                        "ON DUPLICATE KEY UPDATE FechaAlta=@fechaAlta, Denominacion=@denominacion, Precio=@precio, Publicado=@publicado";

                                // Convertimos y asignar precio
                                if (decimal.TryParse(precioStr, NumberStyles.Any, CultureInfo.InvariantCulture, out precio))
                                {
                                    myCommand.Parameters.Clear();
                                    myCommand.Parameters.AddWithValue("@id", fields[0]);
                                    myCommand.Parameters.AddWithValue("@fechaAlta", formattedDate);
                                    myCommand.Parameters.AddWithValue("@codigo", fields[2]);
                                    myCommand.Parameters.AddWithValue("@denominacion", fields[3]);
                                    myCommand.Parameters.AddWithValue("@precio", precio); 
                                    myCommand.Parameters.AddWithValue("@publicado", fields[5]);

                                    myCommand.ExecuteNonQuery();
                                }
                                else
                                {
                                    Console.WriteLine($"Precio inválido: {precioStr}");
                                }
                            }

                            contador++;
                        }
                        else
                        {
                            Console.WriteLine($"Fecha inválida o formato incorrecto: {fields[1]}");
                        }
                    }
                }

                // Verificamos que los registros sean los mismos
                using (MySqlCommand countCommand = new MySqlCommand("SELECT COUNT(*) FROM articulo", conx))
                {
                    int countArticulos = Convert.ToInt32(countCommand.ExecuteScalar());

                    countCommand.CommandText = "SELECT COUNT(*) FROM articulo_copy";
                    int countArticuloCopy = Convert.ToInt32(countCommand.ExecuteScalar());

                    if (countArticulos == countArticuloCopy)
                    {
                        Console.WriteLine("La cantidad de registros es la misma en ambas tablas.");
                    }
                    else
                    {
                        Console.WriteLine($"La cantidad de registros es diferente: {countArticulos} en articulo y {countArticuloCopy} en articulo_copy.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                if (conx != null)
                {
                    conx.Close();
                }
            }
        }
    }
}