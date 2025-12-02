using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTorneos
{
    public class Equipo
    {
        [Key]
            public int IdEquipo { get; set; }
            public string Nombre { get; set; }
            public string? Ciudad { get; set; }

            // Navegación
            public List<Jugador>? Jugadores { get; set; }                 // jugadores del equipo
            public List<TorneoEquipo>? TorneosEquipos { get; set; }       // torneos donde participa
            public List<Partido>? PartidosComoLocal { get; set; }         // partidos donde fue local
            public List<Partido>? PartidosComoVisitante { get; set; }     // partidos donde fue visitante
        
    }

}
