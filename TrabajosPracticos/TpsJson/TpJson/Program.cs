using MySqlConnector;
using Newtonsoft.Json;

public class Program
{
    public static void Main()
    {
        // Cadena de conexión a la base de datos
        string connString = "Server=bemseqjmdfzpnhjhnnkd-mysql.services.clever-cloud.com;Port=3306;Database=bemseqjmdfzpnhjhnnkd;Uid=uvymgx1zcwunagvy;Pwd=ajiCSofHy6DEhNMXOoRl;SslMode=none;";

        // Lista para almacenar los escritores
        List<Escritor> listaEscritores = new List<Escritor>();

        // Abrir la conexión con la base de datos
        using (var dbConnection = new MySqlConnection(connString))
        {
            dbConnection.Open();
            Console.WriteLine("Conexión establecida con éxito a la base de datos.");

            // Definición de la consulta SQL
            string sqlQuery = @"
                SELECT e.id, e.apellido, e.nombre, e.dni, l.nombre AS nombreLibro, l.anioPublicacion, l.editorial
                FROM Escritor e
                INNER JOIN Libro l ON e.id = l.idEscritor";

            // Crear y ejecutar el comando SQL
            using (var sqlCommand = new MySqlCommand(sqlQuery, dbConnection))
            {
                using (var dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        // Leer el id del escritor
                        int escritorId = dataReader.GetInt32(0);

                        // Verificar si el escritor ya está en la lista
                        var escritor = listaEscritores.Find(e => e.Id == escritorId);
                        if (escritor == null)
                        {
                            escritor = new Escritor
                            {
                                Id = escritorId,
                                Apellido = dataReader.GetString(1),
                                Nombre = dataReader.GetString(2),
                                Dni = dataReader.GetString(3),
                                Libros = new List<Libro>()
                            };
                            listaEscritores.Add(escritor);
                        }

                        // Agregar el libro a la lista de libros del escritor
                        escritor.Libros.Add(new Libro
                        {
                            Nombre = dataReader.GetString(4),
                            AnioPublicacion = dataReader.GetInt32(5),
                            Editorial = dataReader.GetString(6)
                        });
                    }
                }
            }
        }

        // Convertir la lista de escritores a formato JSON
        string jsonOutput = JsonConvert.SerializeObject(listaEscritores, Formatting.Indented);

        // Guardar el JSON en un archivo
        File.WriteAllText("escritores.json", jsonOutput);

        Console.WriteLine("Los datos han sido guardados correctamente en el archivo escritores.json");
    }
}
