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
    public class CompanyTypeController : ControllerBase
    {
        private readonly Diplom_backContext _context;

        public CompanyTypeController(Diplom_backContext context)
        {
            _context = context;
        }

        // GET: api/CompanyTypeContoller
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyType>>> GetCompanyTypes()
        {
          if (_context.CompanyTypes == null)
          {
              return NotFound();
          }
            return await _context.CompanyTypes.ToListAsync();
        }

        // GET: api/CompanyTypeContoller/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyType>> GetCompanyType(int id)
        {
          if (_context.CompanyTypes == null)
          {
              return NotFound();
          }
            var companyType = await _context.CompanyTypes.FindAsync(id);

            if (companyType == null)
            {
                return NotFound();
            }

            return companyType;
        }

        // PUT: api/CompanyTypeContoller/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyType(int id, CompanyType companyType)
        {
            if (id != companyType.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyTypeExists(id))
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

        // POST: api/CompanyTypeContoller
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyType>> PostCompanyType(CompanyType companyType)
        {
          if (_context.CompanyTypes == null)
          {
              return Problem("Entity set 'Diplom_backContext.CompanyTypes'  is null.");
          }
            _context.CompanyTypes.Add(companyType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyType", new { id = companyType.Id }, companyType);
        }

        // DELETE: api/CompanyTypeContoller/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyType(int id)
        {
            if (_context.CompanyTypes == null)
            {
                return NotFound();
            }
            var companyType = await _context.CompanyTypes.FindAsync(id);
            if (companyType == null)
            {
                return NotFound();
            }

            _context.CompanyTypes.Remove(companyType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyTypeExists(int id)
        {
            return (_context.CompanyTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
