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
    public class Weapon_TBController : ControllerBase
    {
        private readonly Weapon_TBContext _context;

        public Weapon_TBController(Weapon_TBContext context)
        {
            _context = context;
        }

        // GET: api/Weapon_TB
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weapon_TB>>> Getweapon_tb()
        {
          if (_context.weapon_tb == null)
          {
              return NotFound();
          }
            return await _context.weapon_tb.ToListAsync();
        }

        // GET: api/Weapon_TB/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weapon_TB>> GetWeapon_TB(int id)
        {
          if (_context.weapon_tb == null)
          {
              return NotFound();
          }
            var weapon_TB = await _context.weapon_tb.FindAsync(id);

            if (weapon_TB == null)
            {
                return NotFound();
            }

            return weapon_TB;
        }

        // PUT: api/Weapon_TB/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeapon_TB(int id, Weapon_TB weapon_TB)
        {
            if (id != weapon_TB.weapon_id)
            {
                return BadRequest();
            }

            _context.Entry(weapon_TB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Weapon_TBExists(id))
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

        // POST: api/Weapon_TB
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Weapon_TB>> PostWeapon_TB(Weapon_TB weapon_TB)
        {
          if (_context.weapon_tb == null)
          {
              return Problem("Entity set 'Weapon_TBContext.weapon_tb'  is null.");
          }
            _context.weapon_tb.Add(weapon_TB);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeapon_TB", new { id = weapon_TB.weapon_id }, weapon_TB);
        }

        // DELETE: api/Weapon_TB/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeapon_TB(int id)
        {
            if (_context.weapon_tb == null)
            {
                return NotFound();
            }
            var weapon_TB = await _context.weapon_tb.FindAsync(id);
            if (weapon_TB == null)
            {
                return NotFound();
            }

            _context.weapon_tb.Remove(weapon_TB);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Weapon_TBExists(int id)
        {
            return (_context.weapon_tb?.Any(e => e.weapon_id == id)).GetValueOrDefault();
        }
    }
}
