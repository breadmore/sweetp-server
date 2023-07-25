using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sweetp_server.Models;
using sweetp_server.Models.Context;

namespace sweetp_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Player_TBController : ControllerBase
    {
        private readonly Player_TBContext _context;

        public Player_TBController(Player_TBContext context)
        {
            _context = context;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player_TB>>> GetPlayers()
        {
          if (_context.player_tb == null)
          {
              return NotFound();
          }
            return await _context.player_tb.ToListAsync();
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player_TB>> GetPlayer(int id)
        {
          if (_context.player_tb == null)
          {
              return NotFound();
          }
            var player = await _context.player_tb.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player_TB player)
        {
            if (id != player.player_id)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player_TB>> PostPlayer(Player_TB player)
        {
          if (_context.player_tb == null)
          {
              return Problem("Entity set 'PlayerContext.Players'  is null.");
          }
            _context.player_tb.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayer), new { id = player.player_id }, player);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            if (_context.player_tb == null)
            {
                return NotFound();
            }
            var player = await _context.player_tb.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.player_tb.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(int id)
        {
            return (_context.player_tb?.Any(e => e.player_id == id)).GetValueOrDefault();
        }
    }
}
