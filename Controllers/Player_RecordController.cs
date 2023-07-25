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
    public class Player_RecordController : ControllerBase
    {
        private readonly Player_RecordContext _context;

        public Player_RecordController(Player_RecordContext context)
        {
            _context = context;
        }

        // GET: api/Player_Record
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player_Record>>> Getplayer_record()
        {
          if (_context.player_record == null)
          {
              return NotFound();
          }
            return await _context.player_record.ToListAsync();
        }

        // GET: api/Player_Record/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player_Record>> GetPlayer_Record(int id)
        {
          if (_context.player_record == null)
          {
              return NotFound();
          }
            var player_Record = await _context.player_record.FindAsync(id);

            if (player_Record == null)
            {
                return NotFound();
            }

            return player_Record;
        }

        // PUT: api/Player_Record/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer_Record(int id, Player_Record player_Record)
        {
            if (id != player_Record.player_id)
            {
                return BadRequest();
            }

            _context.Entry(player_Record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Player_RecordExists(id))
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

        // POST: api/Player_Record
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player_Record>> PostPlayer_Record(Player_Record player_Record)
        {
          if (_context.player_record == null)
          {
              return Problem("Entity set 'Player_RecordContext.player_record'  is null.");
          }
            _context.player_record.Add(player_Record);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer_Record", new { id = player_Record.player_id }, player_Record);
        }

        // DELETE: api/Player_Record/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer_Record(int id)
        {
            if (_context.player_record == null)
            {
                return NotFound();
            }
            var player_Record = await _context.player_record.FindAsync(id);
            if (player_Record == null)
            {
                return NotFound();
            }

            _context.player_record.Remove(player_Record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Player_RecordExists(int id)
        {
            return (_context.player_record?.Any(e => e.player_id == id)).GetValueOrDefault();
        }
    }
}
