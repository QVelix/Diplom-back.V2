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
    public class DealController : ControllerBase
    {
        private readonly Diplom_backContext _context;

        public DealController(Diplom_backContext context)
        {
            _context = context;
        }

        // GET: api/DealContoller
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deal>>> GetDeals()
        {
          if (_context.Deals == null)
          {
              return NotFound();
          }
            return await _context.Deals.ToListAsync();
        }

        // GET: api/DealContoller/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deal>> GetDeal(int id)
        {
          if (_context.Deals == null)
          {
              return NotFound();
          }
            var deal = await _context.Deals.FindAsync(id);

            if (deal == null)
            {
                return NotFound();
            }

            return deal;
        }

        // PUT: api/DealContoller/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeal(int id, Deal deal)
        {
            if (id != deal.Id)
            {
                return BadRequest();
            }

            _context.Entry(deal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealExists(id))
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

        // POST: api/DealContoller
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deal>> PostDeal(Deal deal)
        {
          if (_context.Deals == null)
          {
              return Problem("Entity set 'Diplom_backContext.Deals'  is null.");
          }
            _context.Deals.Add(deal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeal", new { id = deal.Id }, deal);
        }
        
        [HttpPost("{search}")]
        public async Task<ActionResult<IEnumerable<Deal>>> SearchDeal(string search)
        {
            if (_context.Deals == null)
            {
                return NotFound();
            }

            var deals = _context.Deals.Where(d =>
                d.Name.Contains(search) || d.Number.Contains(search));

            if (deals == null)
            {
                return NotFound();
            }

            return deals.ToList();
        }

        // DELETE: api/DealContoller/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeal(int id)
        {
            if (_context.Deals == null)
            {
                return NotFound();
            }
            var deal = await _context.Deals.FindAsync(id);
            if (deal == null)
            {
                return NotFound();
            }

            _context.Deals.Remove(deal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DealExists(int id)
        {
            return (_context.Deals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
