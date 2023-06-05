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
    public class CompaniesHasRequisiteController : ControllerBase
    {
        private readonly Diplom_backContext _context;

        public CompaniesHasRequisiteController(Diplom_backContext context)
        {
            _context = context;
        }

        // GET: api/CompaniesHasRequisite
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompaniesHasRequisite>>> GetCompaniesHasRequisites()
        {
          if (_context.CompaniesHasRequisites == null)
          {
              return NotFound();
          }
            return await _context.CompaniesHasRequisites.ToListAsync();
        }

        // GET: api/CompaniesHasRequisite/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompaniesHasRequisite>> GetCompaniesHasRequisite(int id)
        {
          if (_context.CompaniesHasRequisites == null)
          {
              return NotFound();
          }
            var companiesHasRequisite = await _context.CompaniesHasRequisites.FindAsync(id);

            if (companiesHasRequisite == null)
            {
                return NotFound();
            }

            return companiesHasRequisite;
        }

        // PUT: api/CompaniesHasRequisite/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompaniesHasRequisite(int id, CompaniesHasRequisite companiesHasRequisite)
        {
            if (id != companiesHasRequisite.CompaniesId)
            {
                return BadRequest();
            }

            _context.Entry(companiesHasRequisite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompaniesHasRequisiteExists(id))
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

        // POST: api/CompaniesHasRequisite
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompaniesHasRequisite>> PostCompaniesHasRequisite(CompaniesHasRequisite companiesHasRequisite)
        {
          if (_context.CompaniesHasRequisites == null)
          {
              return Problem("Entity set 'Diplom_backContext.CompaniesHasRequisites'  is null.");
          }
            _context.CompaniesHasRequisites.Add(companiesHasRequisite);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompaniesHasRequisiteExists(companiesHasRequisite.CompaniesId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompaniesHasRequisite", new { id = companiesHasRequisite.CompaniesId }, companiesHasRequisite);
        }

        // DELETE: api/CompaniesHasRequisite/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompaniesHasRequisite(int id)
        {
            if (_context.CompaniesHasRequisites == null)
            {
                return NotFound();
            }
            var companiesHasRequisite = await _context.CompaniesHasRequisites.FindAsync(id);
            if (companiesHasRequisite == null)
            {
                return NotFound();
            }

            _context.CompaniesHasRequisites.Remove(companiesHasRequisite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompaniesHasRequisiteExists(int id)
        {
            return (_context.CompaniesHasRequisites?.Any(e => e.CompaniesId == id)).GetValueOrDefault();
        }
    }
}
