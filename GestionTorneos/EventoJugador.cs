using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTorneos
{
    public class EventoJugador
    {
        [Key]
            public int IdEvento { get; set; }
            public string Tipo { get; set; }   // Gol, Amarilla, Roja
            public int Minuto { get; set; }

            // FK
            public int IdPartido { get; set; } // sirve: para relacionar con la tabla Partido
            public int IdJugador { get; set; } // sirve: para relacionar con la tabla Jugador

            // Navegación
            public Partido? Partido { get; set; } // sirve: para navegar al Partido
            public Jugador? Jugador { get; set; } // sirve: para navegar al Jugador
        
    }
}
