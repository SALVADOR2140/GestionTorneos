using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace GestionTorneos.ApiTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7222/");

            int idTorneo = 1;

            Console.WriteLine("=== INSCRIBIENDO 16 EQUIPOS AL TORNEO ===\n");

            for (int idEquipo = 1; idEquipo <= 16; idEquipo++)
            {
                var content = new StringContent("{}", Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(
                    $"api/Torneos/{idTorneo}/equipos/{idEquipo}",
                    content).Result;

                var json = response.Content.ReadAsStringAsync().Result;

                var resultado = JsonConvert.DeserializeObject<GestionTorneos.ApiResult<GestionTorneos.TorneoEquipo>>(json);

                if (resultado != null && resultado.Success)
                {
                    Console.WriteLine($"Equipo {idEquipo}: ✓ Inscrito correctamente");
                }
                else
                {
                    Console.WriteLine($"Equipo {idEquipo}: ✗ Error - {resultado?.Message}");
                }
            }

            Console.WriteLine("\n=== FIN ===");
            Console.WriteLine("Presiona ENTER para salir...");
            Console.ReadLine();
        }
    }
}
