using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTorneos
{
    public class TorneoEquipo
    {
        [Key]
            public int Id { get; set; }   // Id normal, como en Animal

            // FK
            public int IdTorneo { get; set; } // sirve: para relacionar con la tabla Torneo
            public int IdEquipo { get; set; } // sirve: para relacionar con la tabla Equipo

            public string? Grupo { get; set; } // A, B, C, D

            // Navegación
            public Torneo? Torneo { get; set; } // sirve: para navegar al Torneo
            public Equipo? Equipo { get; set; } // sirve: para navegar al Equipo
        
    }

}
