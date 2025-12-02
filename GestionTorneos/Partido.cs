using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTorneos
{
    public class Partido
    {

            [Key]
            public int IdPartido { get; set; }
            public string Fase { get; set; }      // Grupo, Cuartos, etc.
            public DateTime Fecha { get; set; }
            public int GolesLocal { get; set; }
            public int GolesVisitante { get; set; }
            public string Estado { get; set; }    // Programado, Jugado


            // FK hacia Equipos
            public int IdEquipoLocal { get; set; }
            public int IdEquipoVisitante { get; set; }

            // FK hacia Torneo
            public int IdTorneo { get; set; }


            // Navegación
            public Torneo? Torneo { get; set; }
            public Equipo? EquipoLocal { get; set; }
            public Equipo? EquipoVisitante { get; set; }
        }
}

