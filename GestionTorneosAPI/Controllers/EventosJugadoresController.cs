using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionTorneos;

namespace GestionTorneos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosJugadoresController : ControllerBase
    {
        private readonly TorneosAPIContext _context;

        public EventosJugadoresController(TorneosAPIContext context)
        {
            _context = context;
        }

        // GET: api/EventosJugadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoJugador>>> GetEventoJugador()
        {
            return await _context.EventoJugador.ToListAsync();
        }

        // GET: api/EventosJugadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoJugador>> GetEventoJugador(int id)
        {
            var eventoJugador = await _context.EventoJugador.FindAsync(id);

            if (eventoJugador == null)
            {
                return NotFound();
            }

            return eventoJugador;
        }

        // PUT: api/EventosJugadores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventoJugador(int id, EventoJugador eventoJugador)
        {
            if (id != eventoJugador.IdEvento)
            {
                return BadRequest();
            }

            _context.Entry(eventoJugador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoJugadorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EventosJugadores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventoJugador>> PostEventoJugador(EventoJugador eventoJugador)
        {
            _context.EventoJugador.Add(eventoJugador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventoJugador", new { id = eventoJugador.IdEvento }, eventoJugador);
        }

        // DELETE: api/EventosJugadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventoJugador(int id)
        {
            var eventoJugador = await _context.EventoJugador.FindAsync(id);
            if (eventoJugador == null)
            {
                return NotFound();
            }

            _context.EventoJugador.Remove(eventoJugador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoJugadorExists(int id)
        {
            return _context.EventoJugador.Any(e => e.IdEvento == id);
        }
    }
}
