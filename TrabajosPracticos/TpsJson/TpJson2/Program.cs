using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TpJson
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Definición de la URL de la API
            string apiUrl = "https://randomuser.me/api/?results=10";

            // Instancia de HttpClient para realizar la solicitud
            using (var httpClient = new HttpClient())
            {
                try
                {
                    // Solicitar los datos en formato JSON desde la API
                    var response = await httpClient.GetStringAsync(apiUrl);

                    // Convertir el JSON en un objeto de tipo RandomUserApiResponse
                    var userApiResponse = JsonConvert.DeserializeObject<RandomUserApiResponse>(response);

                    // Recorrer y mostrar la información de cada usuario
                    foreach (var randomUser in userApiResponse.Results)
                    {
                        Console.WriteLine($"Nombre: {randomUser.Name.First}");
                        Console.WriteLine($"Apellido: {randomUser.Name.Last}");
                        Console.WriteLine($"Nombre de Usuario: {randomUser.Login.Username}");
                        Console.WriteLine($"Contraseña: {randomUser.Login.Password}");
                        Console.WriteLine(new string('-', 40));
                    }
                }
                catch (Exception error)
                {
                    // Manejo de errores en caso de fallo
                    Console.WriteLine($"Se ha producido un error: {error.Message}");
                }
            }
        }
    }
}
