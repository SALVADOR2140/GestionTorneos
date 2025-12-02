using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionTorneos;

namespace GestionTorneos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorneosController : ControllerBase
    {
        private readonly TorneosAPIContext _context;

        public TorneosController(TorneosAPIContext context)
        {
            _context = context;
        }

        // GET: api/Torneos
        [HttpGet]
        public async Task<ActionResult<ApiResult<List<Torneo>>>> GetTorneos()
        {
            var torneos = await _context.Torneos.ToListAsync();
            return ApiResult<List<Torneo>>.Ok(torneos);
        }

        // GET: api/Torneos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult<Torneo>>> GetTorneo(int id)
        {
            var torneo = await _context.Torneos.FindAsync(id);

            if (torneo == null)
                return ApiResult<Torneo>.Fail("Torneo no encontrado.");

            return ApiResult<Torneo>.Ok(torneo);
        }

        // PUT: api/Torneos/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult<Torneo>>> PutTorneo(int id, Torneo torneo)
        {
            if (id != torneo.IdTorneo)
                return ApiResult<Torneo>.Fail("No coinciden los identificadores.");

            torneo.FechaInicio = DateTime.SpecifyKind(torneo.FechaInicio, DateTimeKind.Utc);
            torneo.FechaFin = DateTime.SpecifyKind(torneo.FechaFin, DateTimeKind.Utc);

            _context.Entry(torneo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return ApiResult<Torneo>.Ok(torneo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TorneoExists(id))
                    return ApiResult<Torneo>.Fail("Torneo no encontrado.");

                throw;
            }
        }

        // POST: api/Torneos
        [HttpPost]
        public async Task<ActionResult<ApiResult<Torneo>>> PostTorneo(Torneo torneo)
        {
            // Forzar fechas a UTC para evitar error con PostgreSQL
            torneo.FechaInicio = DateTime.SpecifyKind(torneo.FechaInicio, DateTimeKind.Utc);
            torneo.FechaFin = DateTime.SpecifyKind(torneo.FechaFin, DateTimeKind.Utc);

            _context.Torneos.Add(torneo);
            await _context.SaveChangesAsync();

            return ApiResult<Torneo>.Ok(torneo);
        }

        // DELETE: api/Torneos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult<Torneo>>> DeleteTorneo(int id)
        {
            var torneo = await _context.Torneos.FindAsync(id);
            if (torneo == null)
                return ApiResult<Torneo>.Fail("Torneo no encontrado.");

            _context.Torneos.Remove(torneo);
            await _context.SaveChangesAsync();

            return ApiResult<Torneo>.Ok(torneo);
        }

        // POST: api/Torneos/{idTorneo}/equipos/{idEquipo}
        [HttpPost("{idTorneo}/equipos/{idEquipo}")]
        public async Task<ActionResult<ApiResult<TorneoEquipo>>> InscribirEquipo(int idTorneo, int idEquipo)
        {
            var torneo = await _context.Torneos.FindAsync(idTorneo);
            if (torneo == null)
                return ApiResult<TorneoEquipo>.Fail("Torneo no encontrado.");

            if (torneo.Estado != "Pendiente")
                return ApiResult<TorneoEquipo>.Fail("No se pueden inscribir equipos a un torneo ya iniciado.");

            var inscritos = await _context.TorneosEquipos
                .CountAsync(te => te.IdTorneo == idTorneo);

            if (inscritos >= 32)
                return ApiResult<TorneoEquipo>.Fail("Máximo 32 equipos por torneo.");

            var te = new TorneoEquipo
            {
                IdTorneo = idTorneo,
                IdEquipo = idEquipo
            };

            _context.TorneosEquipos.Add(te);
            await _context.SaveChangesAsync();

            return ApiResult<TorneoEquipo>.Ok(te);
        }

        private bool TorneoExists(int id)
        {
            return _context.Torneos.Any(e => e.IdTorneo == id);
        }
    }
}
