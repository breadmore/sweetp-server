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
    public class Player_ScrollController : ControllerBase
    {
        private readonly Player_ScrollContext _context;

        public Player_ScrollController(Player_ScrollContext context)
        {
            _context = context;
        }

        // GET: api/Player_Scroll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player_Scroll>>> Getplayer_scroll()
        {
          if (_context.player_scroll == null)
          {
              return NotFound();
          }
            return await _context.player_scroll.ToListAsync();
        }

        // GET: api/Player_Scroll/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player_Scroll>> GetPlayer_Scroll(int id)
        {
          if (_context.player_scroll == null)
          {
              return NotFound();
          }
            var player_Scroll = await _context.player_scroll.FindAsync(id);

            if (player_Scroll == null)
            {
                return NotFound();
            }

            return player_Scroll;
        }

        // PUT: api/Player_Scroll/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer_Scroll(int id, Player_Scroll player_Scroll)
        {
            if (id != player_Scroll.player_id)
            {
                return BadRequest();
            }

            _context.Entry(player_Scroll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Player_ScrollExists(id))
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

        // POST: api/Player_Scroll
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player_Scroll>> PostPlayer_Scroll(Player_Scroll player_Scroll)
        {
          if (_context.player_scroll == null)
          {
              return Problem("Entity set 'Player_ScrollContext.player_scroll'  is null.");
          }
            _context.player_scroll.Add(player_Scroll);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer_Scroll", new { id = player_Scroll.player_id }, player_Scroll);
        }

        // DELETE: api/Player_Scroll/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer_Scroll(int id)
        {
            if (_context.player_scroll == null)
            {
                return NotFound();
            }
            var player_Scroll = await _context.player_scroll.FindAsync(id);
            if (player_Scroll == null)
            {
                return NotFound();
            }

            _context.player_scroll.Remove(player_Scroll);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Player_ScrollExists(int id)
        {
            return (_context.player_scroll?.Any(e => e.player_id == id)).GetValueOrDefault();
        }
    }
}
