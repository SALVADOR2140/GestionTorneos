using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace GestionTorneos.ApiTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            var rutaJugadores = "api/Jugadores";   // coincide con tu controller
            httpClient.BaseAddress = new Uri("https://localhost:7014/");

            // LECTURA DE DATOS (GET)
            var response = httpClient.GetAsync(rutaJugadores).Result;
            var json = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine("JSON crudo de la API (GET):");
            Console.WriteLine(json);

            var resultadoJugadores =
                JsonConvert.DeserializeObject<GestionTorneos.ApiResult<List<GestionTorneos.Jugador>>>(json);

            if (resultadoJugadores == null)
            {
                Console.WriteLine("No se pudo deserializar a ApiResult<List<Jugador>>.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("\n=== LECTURA INICIAL ===");
            Console.WriteLine("Success: " + resultadoJugadores.Success);
            Console.WriteLine("Message: " + resultadoJugadores.Message);
            Console.WriteLine("Total jugadores: " + (resultadoJugadores.Data?.Count ?? 0));

            // ELIMINACIÓN DE DATOS (DELETE)
            int idEliminar = 5; // aquí pones el IdJugador que quieras borrar

            response = httpClient.DeleteAsync(
                $"{rutaJugadores}/{idEliminar}").Result;

            json = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine("\nJSON crudo del DELETE:");
            Console.WriteLine(json);

            var resultadoDelete =
                JsonConvert.DeserializeObject<GestionTorneos.ApiResult<GestionTorneos.Jugador>>(json);

            Console.WriteLine("\n=== ELIMINACIÓN ===");
            Console.WriteLine("Success: " + resultadoDelete.Success);
            Console.WriteLine("Message: " + resultadoDelete.Message);
            Console.WriteLine("Id eliminado: " + resultadoDelete.Data?.IdJugador);

            Console.WriteLine("\nFIN. Pulsa ENTER...");
            Console.ReadLine();
        }
    }
}

