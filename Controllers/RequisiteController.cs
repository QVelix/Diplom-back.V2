using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Diplom_back.Database;
using Diplom_back.Models;

namespace Diplom_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisiteController : ControllerBase
    {
        private readonly Diplom_backContext _context;

        public RequisiteController(Diplom_backContext context)
        {
            _context = context;
        }

        // GET: api/Requisite
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requisite>>> GetRequisites()
        {
          if (_context.Requisites == null)
          {
              return NotFound();
          }
            return await _context.Requisites.ToListAsync();
        }

        // GET: api/Requisite/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requisite>> GetRequisite(int id)
        {
          if (_context.Requisites == null)
          {
              return NotFound();
          }
            var requisite = await _context.Requisites.FindAsync(id);

            if (requisite == null)
            {
                return NotFound();
            }

            return requisite;
        }

        // PUT: api/Requisite/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequisite(int id, Requisite requisite)
        {
            if (id != requisite.Id)
            {
                return BadRequest();
            }

            _context.Entry(requisite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequisiteExists(id))
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

        // POST: api/Requisite
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Requisite>> PostRequisite(Requisite requisite)
        {
          if (_context.Requisites == null)
          {
              return Problem("Entity set 'Diplom_backContext.Requisites'  is null.");
          }
            _context.Requisites.Add(requisite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequisite", new { id = requisite.Id }, requisite);
        }

        // DELETE: api/Requisite/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequisite(int id)
        {
            if (_context.Requisites == null)
            {
                return NotFound();
            }
            var requisite = await _context.Requisites.FindAsync(id);
            if (requisite == null)
            {
                return NotFound();
            }

            _context.Requisites.Remove(requisite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequisiteExists(int id)
        {
            return (_context.Requisites?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
