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
    public class Weapon_MarketController : ControllerBase
    {
        private readonly Weapon_MarketContext _context;

        public Weapon_MarketController(Weapon_MarketContext context)
        {
            _context = context;
        }

        // GET: api/Weapon_Market
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weapon_Market>>> Getweapon_market()
        {
          if (_context.weapon_market == null)
          {
              return NotFound();
          }
            return await _context.weapon_market.ToListAsync();
        }

        // GET: api/Weapon_Market/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weapon_Market>> GetWeapon_Market(int id)
        {
          if (_context.weapon_market == null)
          {
              return NotFound();
          }
            var weapon_Market = await _context.weapon_market.FindAsync(id);

            if (weapon_Market == null)
            {
                return NotFound();
            }

            return weapon_Market;
        }

        // PUT: api/Weapon_Market/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeapon_Market(int id, Weapon_Market weapon_Market)
        {
            if (id != weapon_Market.weapon_id)
            {
                return BadRequest();
            }

            _context.Entry(weapon_Market).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Weapon_MarketExists(id))
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

        // POST: api/Weapon_Market
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Weapon_Market>> PostWeapon_Market(Weapon_Market weapon_Market)
        {
          if (_context.weapon_market == null)
          {
              return Problem("Entity set 'Weapon_MarketContext.weapon_market'  is null.");
          }
            _context.weapon_market.Add(weapon_Market);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeapon_Market", new { id = weapon_Market.weapon_id }, weapon_Market);
        }

        // DELETE: api/Weapon_Market/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeapon_Market(int id)
        {
            if (_context.weapon_market == null)
            {
                return NotFound();
            }
            var weapon_Market = await _context.weapon_market.FindAsync(id);
            if (weapon_Market == null)
            {
                return NotFound();
            }

            _context.weapon_market.Remove(weapon_Market);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Weapon_MarketExists(int id)
        {
            return (_context.weapon_market?.Any(e => e.weapon_id == id)).GetValueOrDefault();
        }
    }
}
