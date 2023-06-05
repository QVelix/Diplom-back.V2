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
    public class RequisiteTypeController : ControllerBase
    {
        private readonly Diplom_backContext _context;

        public RequisiteTypeController(Diplom_backContext context)
        {
            _context = context;
        }

        // GET: api/RequisiteType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequisiteType>>> GetRequisiteTypes()
        {
          if (_context.RequisiteTypes == null)
          {
              return NotFound();
          }
            return await _context.RequisiteTypes.ToListAsync();
        }

        // GET: api/RequisiteType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequisiteType>> GetRequisiteType(int id)
        {
          if (_context.RequisiteTypes == null)
          {
              return NotFound();
          }
            var requisiteType = await _context.RequisiteTypes.FindAsync(id);

            if (requisiteType == null)
            {
                return NotFound();
            }

            return requisiteType;
        }

        // PUT: api/RequisiteType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequisiteType(int id, RequisiteType requisiteType)
        {
            if (id != requisiteType.Id)
            {
                return BadRequest();
            }

            _context.Entry(requisiteType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequisiteTypeExists(id))
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

        // POST: api/RequisiteType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequisiteType>> PostRequisiteType(RequisiteType requisiteType)
        {
          if (_context.RequisiteTypes == null)
          {
              return Problem("Entity set 'Diplom_backContext.RequisiteTypes'  is null.");
          }
            _context.RequisiteTypes.Add(requisiteType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequisiteType", new { id = requisiteType.Id }, requisiteType);
        }

        // DELETE: api/RequisiteType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequisiteType(int id)
        {
            if (_context.RequisiteTypes == null)
            {
                return NotFound();
            }
            var requisiteType = await _context.RequisiteTypes.FindAsync(id);
            if (requisiteType == null)
            {
                return NotFound();
            }

            _context.RequisiteTypes.Remove(requisiteType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequisiteTypeExists(int id)
        {
            return (_context.RequisiteTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
