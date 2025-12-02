using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionTorneos;

    public class TorneosAPIContext : DbContext
    {
        public TorneosAPIContext (DbContextOptions<TorneosAPIContext> options)
            : base(options)
        {
        }

        public DbSet<GestionTorneos.Equipo> Equipos { get; set; } = default!;

public DbSet<GestionTorneos.Torneo> Torneos { get; set; } = default!;

public DbSet<GestionTorneos.EventoJugador> EventosJugadores { get; set; } = default!;

public DbSet<GestionTorneos.Jugador> Jugadores { get; set; } = default!;

public DbSet<GestionTorneos.Partido> Partidos { get; set; } = default!;

public DbSet<GestionTorneos.TorneoEquipo> TorneosEquipos { get; set; } = default!;
    }
