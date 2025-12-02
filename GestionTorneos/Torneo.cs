using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTorneos
{
    public class Torneo
    {
            [Key]
            public int IdTorneo { get; set; }
            public string Nombre { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public string Tipo { get; set; }    // Liga, Copa, Mixto
            public string Estado { get; set; }  // Pendiente, EnCurso, Finalizado

            // Navegación
            public List<TorneoEquipo>? TorneosEquipos { get; set; } // equipos inscritos
            public List<Partido>? Partidos { get; set; }            // todos los partidos del torneo
        
    }

}
