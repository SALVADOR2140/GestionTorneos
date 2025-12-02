using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTorneos
{
    public class Jugador
    {
            [Key]
            public int IdJugador { get; set; }
            public string Nombre { get; set; }
            public int Dorsal { get; set; }

            // FK
            public int IdEquipo { get; set; } // sirve: para relacionar con la tabla Equipo

            // Navegación
            public Equipo? Equipo { get; set; }                    // sirve: para navegar al Equipo
            public List<EventoJugador>? Eventos { get; set; }      // goles y tarjetas del jugador
        
    }

}
