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

        public DbSet<GestionTorneos.Equipo> Equipo { get; set; } = default!;

public DbSet<GestionTorneos.Torneo> Torneo { get; set; } = default!;

public DbSet<GestionTorneos.EventoJugador> EventoJugador { get; set; } = default!;

public DbSet<GestionTorneos.Jugador> Jugador { get; set; } = default!;

public DbSet<GestionTorneos.Partido> Partido { get; set; } = default!;

public DbSet<GestionTorneos.TorneoEquipo> TorneoEquipo { get; set; } = default!;
    }
