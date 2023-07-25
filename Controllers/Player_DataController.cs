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
    public class Player_DataController : ControllerBase
    {
        private readonly Player_DataContext _context;

        public Player_DataController(Player_DataContext context)
        {
            _context = context;
        }

        // GET: api/Player_Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player_Data>>> Getplayer_data()
        {
          if (_context.player_data == null)
          {
              return NotFound();
          }
            return await _context.player_data.ToListAsync();
        }

        // GET: api/Player_Data/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player_Data>> GetPlayer_Data(int id)
        {
          if (_context.player_data == null)
          {
              return NotFound();
          }
            var player_Data = await _context.player_data.FindAsync(id);

            if (player_Data == null)
            {
                return NotFound();
            }

            return player_Data;
        }

        // PUT: api/Player_Data/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer_Data(int id, Player_Data player_Data)
        {
            if (id != player_Data.player_id)
            {
                return BadRequest();
            }

            _context.Entry(player_Data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Player_DataExists(id))
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

        // POST: api/Player_Data
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player_Data>> PostPlayer_Data(Player_Data player_Data)
        {
          if (_context.player_data == null)
          {
              return Problem("Entity set 'Player_Data_Context.player_data'  is null.");
          }
            _context.player_data.Add(player_Data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer_Data", new { id = player_Data.player_id }, player_Data);
        }

        // DELETE: api/Player_Data/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer_Data(int id)
        {
            if (_context.player_data == null)
            {
                return NotFound();
            }
            var player_Data = await _context.player_data.FindAsync(id);
            if (player_Data == null)
            {
                return NotFound();
            }

            _context.player_data.Remove(player_Data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Player_DataExists(int id)
        {
            return (_context.player_data?.Any(e => e.player_id == id)).GetValueOrDefault();
        }
    }
}
