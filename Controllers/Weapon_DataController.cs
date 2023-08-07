using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class Weapon_DataController : ControllerBase
    {
        private readonly Weapon_DataContext _context;

        public Weapon_DataController(Weapon_DataContext context)
        {
            _context = context;
        }

        // GET: api/Weapon_Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weapon_Data>>> Getweapon_data()
        {
          if (_context.weapon_data == null)
          {
              return NotFound();
          }
            return await _context.weapon_data.ToListAsync();
        }

        // GET: api/Weapon_Data/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weapon_Data>> GetWeapon_Data(int id)
        {
          if (_context.weapon_data == null)
          {
              return NotFound();
          }
            var weapon_Data = await _context.weapon_data.FindAsync(id);

            if (weapon_Data == null)
            {
                return NotFound();
            }

            return weapon_Data;
        }

        // GET: api/Weapon_Data/weapon/1
        [HttpGet("weapon/{id}")]
        public async Task<ActionResult<Weapon_Data>> GetWeaponWithOwnerID(int id)
        {
            if (_context.weapon_data == null)
            {
                return NotFound();
            }
            var weapon_Data = await _context.weapon_data.FirstOrDefaultAsync(e => e.weapon_id == id);

            if (weapon_Data == null)
            {
                return NotFound();
            }

            return weapon_Data;
        }

        [HttpGet("weapon/sale")]
        public async Task<ActionResult<IEnumerable<Weapon_Data>>> GetWeaponWithSale()
        {
            if (_context.weapon_data == null)
            {
                return NotFound();
            }
            var weaponsOnSale = await _context.weapon_data
       .Where(weapon => weapon.weapon_sale == 1)
       .ToListAsync();

            return weaponsOnSale;
        }
        // PUT: api/Weapon_Data/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeapon_Data(int id, Weapon_Data weapon_Data)
        {
            if (id != weapon_Data.weapon_id)
            {
                return BadRequest();
            }

            _context.Entry(weapon_Data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Weapon_DataExists(id))
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

        [HttpPut("weapon/{id}")]
        public async Task<IActionResult> PutWeapon_Data_Sale(int id, int weapon_sale)
        {
            var weapon_Data = await _context.weapon_data.FindAsync(id);

            if (weapon_Data == null)
            {
                return NotFound();
            }

            weapon_Data.weapon_sale = weapon_sale;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Weapon_DataExists(id))
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

        // POST: api/Weapon_Data
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Weapon_Data>> PostWeapon_Data(Weapon_Data weapon_Data)
        {
          if (_context.weapon_data == null)
          {
              return Problem("Entity set 'Weapon_DataContext.weapon_data'  is null.");
          }
            _context.weapon_data.Add(weapon_Data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeapon_Data", new { id = weapon_Data.weapon_id }, weapon_Data);
        }

        // DELETE: api/Weapon_Data/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeapon_Data(int id)
        {
            if (_context.weapon_data == null)
            {
                return NotFound();
            }
            var weapon_Data = await _context.weapon_data.FindAsync(id);
            if (weapon_Data == null)
            {
                return NotFound();
            }

            _context.weapon_data.Remove(weapon_Data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Weapon_DataExists(int id)
        {
            return (_context.weapon_data?.Any(e => e.weapon_id == id)).GetValueOrDefault();
        }
    }
}
