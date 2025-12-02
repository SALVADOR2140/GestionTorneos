using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestionTorneos.API.Migrations
{
    /// <inheritdoc />
    public partial class TorneosPg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    IdEquipo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Ciudad = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.IdEquipo);
                });

            migrationBuilder.CreateTable(
                name: "Torneos",
                columns: table => new
                {
                    IdTorneo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneos", x => x.IdTorneo);
                });

            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    IdJugador = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Dorsal = table.Column<int>(type: "integer", nullable: false),
                    IdEquipo = table.Column<int>(type: "integer", nullable: false),
                    EquipoIdEquipo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.IdJugador);
                    table.ForeignKey(
                        name: "FK_Jugadores_Equipos_EquipoIdEquipo",
                        column: x => x.EquipoIdEquipo,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo");
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    IdPartido = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fase = table.Column<string>(type: "text", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GolesLocal = table.Column<int>(type: "integer", nullable: false),
                    GolesVisitante = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    IdEquipoLocal = table.Column<int>(type: "integer", nullable: false),
                    IdEquipoVisitante = table.Column<int>(type: "integer", nullable: false),
                    IdTorneo = table.Column<int>(type: "integer", nullable: false),
                    TorneoIdTorneo = table.Column<int>(type: "integer", nullable: true),
                    EquipoLocalIdEquipo = table.Column<int>(type: "integer", nullable: true),
                    EquipoVisitanteIdEquipo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.IdPartido);
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_EquipoLocalIdEquipo",
                        column: x => x.EquipoLocalIdEquipo,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo");
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_EquipoVisitanteIdEquipo",
                        column: x => x.EquipoVisitanteIdEquipo,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo");
                    table.ForeignKey(
                        name: "FK_Partidos_Torneos_TorneoIdTorneo",
                        column: x => x.TorneoIdTorneo,
                        principalTable: "Torneos",
                        principalColumn: "IdTorneo");
                });

            migrationBuilder.CreateTable(
                name: "TorneosEquipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdTorneo = table.Column<int>(type: "integer", nullable: false),
                    IdEquipo = table.Column<int>(type: "integer", nullable: false),
                    Grupo = table.Column<string>(type: "text", nullable: true),
                    TorneoIdTorneo = table.Column<int>(type: "integer", nullable: true),
                    EquipoIdEquipo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TorneosEquipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TorneosEquipos_Equipos_EquipoIdEquipo",
                        column: x => x.EquipoIdEquipo,
                        principalTable: "Equipos",
                        principalColumn: "IdEquipo");
                    table.ForeignKey(
                        name: "FK_TorneosEquipos_Torneos_TorneoIdTorneo",
                        column: x => x.TorneoIdTorneo,
                        principalTable: "Torneos",
                        principalColumn: "IdTorneo");
                });

            migrationBuilder.CreateTable(
                name: "EventosJugadores",
                columns: table => new
                {
                    IdEvento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Minuto = table.Column<int>(type: "integer", nullable: false),
                    IdPartido = table.Column<int>(type: "integer", nullable: false),
                    IdJugador = table.Column<int>(type: "integer", nullable: false),
                    PartidoIdPartido = table.Column<int>(type: "integer", nullable: true),
                    JugadorIdJugador = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosJugadores", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_EventosJugadores_Jugadores_JugadorIdJugador",
                        column: x => x.JugadorIdJugador,
                        principalTable: "Jugadores",
                        principalColumn: "IdJugador");
                    table.ForeignKey(
                        name: "FK_EventosJugadores_Partidos_PartidoIdPartido",
                        column: x => x.PartidoIdPartido,
                        principalTable: "Partidos",
                        principalColumn: "IdPartido");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventosJugadores_JugadorIdJugador",
                table: "EventosJugadores",
                column: "JugadorIdJugador");

            migrationBuilder.CreateIndex(
                name: "IX_EventosJugadores_PartidoIdPartido",
                table: "EventosJugadores",
                column: "PartidoIdPartido");

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_EquipoIdEquipo",
                table: "Jugadores",
                column: "EquipoIdEquipo");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EquipoLocalIdEquipo",
                table: "Partidos",
                column: "EquipoLocalIdEquipo");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EquipoVisitanteIdEquipo",
                table: "Partidos",
                column: "EquipoVisitanteIdEquipo");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_TorneoIdTorneo",
                table: "Partidos",
                column: "TorneoIdTorneo");

            migrationBuilder.CreateIndex(
                name: "IX_TorneosEquipos_EquipoIdEquipo",
                table: "TorneosEquipos",
                column: "EquipoIdEquipo");

            migrationBuilder.CreateIndex(
                name: "IX_TorneosEquipos_TorneoIdTorneo",
                table: "TorneosEquipos",
                column: "TorneoIdTorneo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventosJugadores");

            migrationBuilder.DropTable(
                name: "TorneosEquipos");

            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Torneos");
        }
    }
}
